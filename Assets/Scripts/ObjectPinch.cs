using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPinch : MonoBehaviour
{
    [SerializeField]
    private float pinchSpeed = 0.25f;
    [Header("From origin to walls")]
    [Range(20f, 17f)]
    public float maximumDistance=19;
    [Header("From player to object")]
    [Range(0.5f,2f)]
    public float minimumDistance=1.5f;

    private GameObject selectedObject=null;

    void Update()
    {
        //If no input
        if (Input.touchCount < 1)
        {
            return;
        }

        //Get the target object of the potential pinch using raycast
        Touch firstTouch = Input.touches[0];
        if (firstTouch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(firstTouch.position);
            if (Physics.Raycast(ray, out RaycastHit hit) && (hit.collider.tag == "Cloud" || hit.collider.tag == "Crown" || hit.collider.tag == "Tube" || hit.collider.tag == "Shard"))
            {
                selectedObject = hit.collider.gameObject;
                
                //Tells the object to stop moving
                hit.transform.gameObject.GetComponent<FloatingObject>().Dragged();
                hit.transform.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        //If a second input is present, pinch is being used if an object is selected
        if (Input.touchCount < 2 || selectedObject == null)
        {
            return;
        }
        Touch secondTouch = Input.touches[1];
        //If the second input is moving
        if (secondTouch.phase == TouchPhase.Moved)
        {
            //Moving stuffs
            //Get the positions of the touch inputs within the previous fram
            Vector2 firstTouchPositionChange = firstTouch.position - firstTouch.deltaPosition;
            Vector2 secondTouchPositionChange = secondTouch.position - secondTouch.deltaPosition;

            //Gets the distance between the touches based on the changed positions
            float touchPositionDifferenceMagnitude = (firstTouchPositionChange - secondTouchPositionChange).magnitude;
            float touchDeltaMagnitude = (firstTouch.position - secondTouch.position).magnitude;

            //Gets the difference between the frames
            float deltaMagnitudeDifference = touchPositionDifferenceMagnitude - touchDeltaMagnitude;

            //Calculate the step or distance that can be moved
            float step = -pinchSpeed * deltaMagnitudeDifference*Time.deltaTime;

            //If within boundaries, move the object
            if (WithinClamp(step))
            {
                selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position, Camera.main.gameObject.transform.position, step);
            }
        }
        //If the first touch is lifted, stop the pinch
        if ((firstTouch.phase == TouchPhase.Ended || firstTouch.phase == TouchPhase.Canceled))
        {
            selectedObject = null;
        }
    }

    private bool WithinClamp(float step)
    {
        //Distance between player and object
        if (Vector3.Distance(selectedObject.transform.position, Camera.main.transform.position) < minimumDistance && step > 0) //If the distance is less than the radius, it is already within the circle.
        {
            Debug.Log("Cant get closer to user");
            return false;
        }
        //Distance between object and world border
        if (selectedObject.transform.position.magnitude > maximumDistance && step < 0)
        {
            Debug.Log("Cant go farther than limit");
            return false;
        }

        return true;
    }

}
