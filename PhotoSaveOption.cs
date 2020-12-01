using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhotoSaveOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI photoOptionText = null;

    private int defaultSetting=1;
    //1=save to app
    //2=save to phone
    //3=save to both

    private void Start()
    {
        defaultSetting = PlayerPrefs.GetInt("PhotoSaveOption", 1);
        UpdateOption();
    }
    public void PhotoOptionLeft()
    {
        if (defaultSetting != 1)
        {
            defaultSetting--;
        }
        else
        {
            defaultSetting = 3;
        }
        UpdateOption();
    }
    public void PhotoOptionRight()
    {
        if (defaultSetting != 3)
        {
            defaultSetting++;
        }
        else
        {
            defaultSetting = 1;
        }
        UpdateOption();
    }

    private void UpdateOption()
    {
        switch (defaultSetting)
        {
            case 1:
                PlayerPrefs.SetInt("PhotoSaveOption", 1);
                photoOptionText.SetText("App");
                break;
            case 2:
                PlayerPrefs.SetInt("PhotoSaveOption", 2);
                photoOptionText.SetText("Phone");
                break;
            case 3:
                PlayerPrefs.SetInt("PhotoSaveOption", 3);
                photoOptionText.SetText("Both");
                break;
        }
    }
}
