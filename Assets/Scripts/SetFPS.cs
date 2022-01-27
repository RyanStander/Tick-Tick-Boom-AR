using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFPS : MonoBehaviour
{
    //Uncapped by default
    [SerializeField]
    private int targetFPS = -1;

    private void Awake()
    {
        Application.targetFrameRate = targetFPS;
    }
}
