using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UpdateGridProperties : MonoBehaviour
{
    [SerializeField]
    private RectTransform layoutSize = null;
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

        //Target cell width
        float targetWidth = (layoutSize.rect.width / layoutGridGroup.constraintCount)-((layoutGridGroup.spacing.x/2)* layoutGridGroup.constraintCount) + layoutGridGroup.padding.top/2;

        float targetHeight = (layoutSize.rect.height * (targetWidth / layoutSize.rect.width));

        //Set the target size
        layoutGridGroup.cellSize = new Vector2(targetWidth, targetHeight);
    }

}
