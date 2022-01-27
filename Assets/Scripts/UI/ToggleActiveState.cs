using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActiveState : MonoBehaviour
{
    [SerializeField] private GameObject[] toggleObjectsOn = null, toggleObjectsOff = null;
    public void ToggleObjects()
    {
        foreach (GameObject singleObject in toggleObjectsOff)
        {
            if (singleObject != null)
            {
                singleObject.SetActive(false);
            }
        }
        foreach (GameObject singleObject in toggleObjectsOn)
        {
            if (singleObject != null)
            {
                singleObject.SetActive(true);
            }
        }
    }
}
