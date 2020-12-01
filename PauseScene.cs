using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour
{
    public virtual void ResumeTime()
    {
        //Setting time scale like this "un-freezes" time on everything
        Time.timeScale = 1;
    }

    //Pauses the game
    public virtual void PauseTime()
    {
        //Setting time scale like this "freezes" time on everything
        Time.timeScale = 0;
    }
}
