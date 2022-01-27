using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureSelectListenerObjectToggle : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.onPictureSelected += ToggleObjects;
    }
    void OnDisable()
    {
        EventManager.onPictureSelected -= ToggleObjects;
    }

    [SerializeField] private GameObject toggleObjectOn = null, toggleObjectOff = null;
    public void ToggleObjects(int notNeeded)
    {
        if (toggleObjectOn != null)
            toggleObjectOn.SetActive(true);
        if (toggleObjectOff != null)
            toggleObjectOff.SetActive(false);
    }
}
