using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UpdateGridProperties : MonoBehaviour
{
    void OnEnable()
    {
        UpdateProperties();
    }
     void Start()
    {
        UpdateProperties();
    }
    private void UpdateProperties()
    {
        //Pictures are taken in screen size, therefore the size of a picture is the screen size
        GridLayoutGroup layoutGridGroup = this.GetComponent<GridLayoutGroup>();

        //Target cell width this.GetComponent<RectTransform>().rect.width
        float targetWidth = (Screen.width / layoutGridGroup.constraintCount);
        float targetHeight = (Screen.height * (targetWidth / Screen.width));

        //Set the target size
        layoutGridGroup.cellSize = new Vector2(targetWidth, targetHeight);
    }

}
