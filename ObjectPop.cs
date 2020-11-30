using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPop : MonoBehaviour
{
    [SerializeField] private GameObject popEffect=null;
    private Transform target;
    private int tapCount;
    [SerializeField] private float maxDoubleTapTime=0.5f;
    private float newTime;
    void Update()
    {
        if (Time.time > newTime)
        {
            tapCount = 0;
        }
        if (Input.touchCount == 1)
        {
            //Object Popping
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                tapCount += 1;
            }

            //Search for object
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit, 500))
                {
                    if (hit.transform.tag == "Crown" || hit.transform.tag == "Cloud" || hit.transform.tag == "Tube" || hit.transform.tag == "Shard")
                    {
                        target = hit.transform;
                    }
                }
            }

            if (tapCount == 1)
            {
                newTime = Time.time + maxDoubleTapTime;
            }
            else if (tapCount == 2 && Time.time <= newTime)
            {
                Pop();

                tapCount = 0;
            }
        }
    }
    private void Pop()
    {    
        if (target != null)
        {
            Instantiate(popEffect, target.position, Quaternion.identity);
            Destroy(target.gameObject);
            target = null;
        }   
    }
}
