using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    bool isDragged;
    Transform targetObject;
    float distanceFromTarget;
    Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        Vector3 v3;

        if (Input.touchCount != 1)
        {
            isDragged = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Cloud"|| hit.collider.tag =="Crown" || hit.collider.tag == "Tube" || hit.collider.tag == "Shard"))
            {
                targetObject = hit.transform;
                distanceFromTarget = hit.transform.position.z - Camera.main.transform.position.z;
                v3 = new Vector3(pos.x, pos.y, distanceFromTarget);
                v3 = Camera.main.ScreenToWorldPoint(v3);
                offset = targetObject.position - v3;
                isDragged = true;
                hit.transform.gameObject.GetComponent<FloatingObject>().Dragged();
                hit.transform.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        if (isDragged && touch.phase == TouchPhase.Moved)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromTarget);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            targetObject.position = v3 + offset;
        }
        if (isDragged && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            isDragged = false;
        }
    }
}
