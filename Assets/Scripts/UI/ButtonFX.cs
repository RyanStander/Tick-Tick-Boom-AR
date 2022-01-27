using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceComponent=null;
    [SerializeField] AudioClip buttonClickSound=null;
    // Start is called before the first frame update
   
    public void ClickSound()
    {
        audioSourceComponent.PlayOneShot(buttonClickSound);
    }
}
