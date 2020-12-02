using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPop : MonoBehaviour
{
    [SerializeField] private GameObject solidPopEffect=null;
    [SerializeField] private GameObject cloudPopEffect = null;
    private Transform target;
    private string targetTag;
    private int tapCount;
    [SerializeField] private float maxDoubleTapTime=0.5f;
    private float newTime;
    void Update()
    {
        //If outside of tapping time
        if (Time.time > newTime)
        {
            tapCount = 0;
            target = null;
        }
        if (Input.touchCount == 1)
        {
            //Object Popping
            Touch touch = Input.GetTouch(0);

            //IF tapping once
            if (touch.phase == TouchPhase.Ended)
            {
                tapCount += 1;
            }

            //Search for target object
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit, 500))
                {
                    targetTag = hit.transform.tag;
                    if (targetTag == "Crown" || targetTag == "Cloud" || targetTag == "Tube" || targetTag == "Shard")
                    {
                        //Set the target to the transform
                        target = hit.transform;
                    }
                }
            }

            //If tapping was only once
            if (tapCount == 1)
            {
                newTime = Time.time + maxDoubleTapTime;
            }
            //If tapping happened twice and is within time
            else if (tapCount == 2 && Time.time <= newTime)
            {
                Pop();

                //Reset count
                tapCount = 0;
            }
        }
    }
    private void Pop()
    {    
        if (target != null)
        {
            if (targetTag == "Crown" || targetTag == "Tube" || targetTag == "Shard")
            {
                Instantiate(solidPopEffect, target.position, Quaternion.identity);
            }
            else
            {
                Instantiate(cloudPopEffect, target.position, Quaternion.identity);
            }            
            Destroy(target.gameObject);
            target = null;
        }   
    }
}
