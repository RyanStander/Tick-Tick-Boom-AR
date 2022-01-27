using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActiveState : MonoBehaviour
{
    [SerializeField] private GameObject[] switchObjects = null;
    public void ToggleObjects()
    {
        foreach (GameObject singleObject in switchObjects)
        {
            if (singleObject != null)
            {
                singleObject.SetActive(!singleObject.activeInHierarchy);
            }
        }
    }
}
