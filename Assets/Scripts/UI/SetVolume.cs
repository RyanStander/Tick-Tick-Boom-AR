using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer=null;
    private int _valueScalar=20;
    [SerializeField] private string exposedParamName=null;

    public void SetMasterVolume(float sliderValue)
    {
        mixer.SetFloat(exposedParamName, Mathf.Log10(sliderValue) * _valueScalar);
    }
    public void SetMusicVolume(float sliderValue)
    {
        mixer.SetFloat(exposedParamName, Mathf.Log10(sliderValue) * _valueScalar);
    }
    public void SetSFXVolume(float sliderValue)
    {
        mixer.SetFloat(exposedParamName, Mathf.Log10(sliderValue) * _valueScalar);
    }
}
