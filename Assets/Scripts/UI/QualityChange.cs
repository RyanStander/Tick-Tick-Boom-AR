using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QualityChange : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI qualityText=null;

    private void Start()
    {
        qualityText.SetText(PlayerPrefs.GetString("Quality", "Low"));
    }
    public void IncreaseQuality()
    {
        QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel()+1, true);
        qualityText.SetText(QualitySettings.names[QualitySettings.GetQualityLevel()]);
        PlayerPrefs.SetString("Quality", QualitySettings.names[QualitySettings.GetQualityLevel()]);
    }
    public void DecreaseQuality()
    {
        QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel()-1, true);
        qualityText.SetText(QualitySettings.names[QualitySettings.GetQualityLevel()]);
        PlayerPrefs.SetString("Quality", QualitySettings.names[QualitySettings.GetQualityLevel()]);
    }
}
