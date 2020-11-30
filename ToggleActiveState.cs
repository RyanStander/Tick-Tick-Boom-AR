using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActiveState : MonoBehaviour
{
    [SerializeField] private GameObject[] toggleObjectsOn = null, toggleObjectsOff = null;
    public void ToggleObjects()
    {
        if(toggleObjectsOff!=null)
        {
            foreach (GameObject singleObject in toggleObjectsOff)
            {
                singleObject.SetActive(false);
            }
        }
        if(toggleObjectsOn!=null)
        {
            foreach (GameObject singleObject in toggleObjectsOn)
            {
                singleObject.SetActive(true);
            }
        }
    }
}
