using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePicture : MonoBehaviour
{
    public void DeletePictureConfirm()
    {
        //Fire off the new image path for any listeners (Gallery Manager)
        EventManager.PictureDelete();
    }
}
