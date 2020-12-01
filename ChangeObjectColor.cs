using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectColor : MonoBehaviour
{
    public Renderer[] visualCaps;
    public Material[] materials;
    private int currentMaterial=0;

    public void RandomizeColor()
    {
        currentMaterial++;

        if (currentMaterial == materials.Length)
        {
            currentMaterial = 0;
        }
        
        foreach (Renderer cap in visualCaps)
        {
            cap.material = materials[currentMaterial];
        }
    }
}
