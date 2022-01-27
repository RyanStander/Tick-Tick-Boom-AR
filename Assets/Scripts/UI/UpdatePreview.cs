using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class UpdatePreview : MonoBehaviour
{
    //Listeners
    void OnEnable()
    {
        UpdatePicturePreview();
    }

    void UpdatePicturePreview()
    {
        //ListMethod
        if (GalleryManager.GetPicturesList().ElementAtOrDefault(GalleryManager.GetSelectedPicture()) != null)
        {
            this.GetComponent<RawImage>().texture = LoadPNG(GalleryManager.GetPicturesList()[GalleryManager.GetSelectedPicture()]);
        }
    }

    public static Texture2D LoadPNG(string filePath)
    {
        Texture2D texture = null;
        byte[] fileData;

        //Ensures the file exists
        if (File.Exists(filePath))
        {
            //Reads the bytes
            fileData = File.ReadAllBytes(filePath);
            //Texture to return
            texture = new Texture2D(1, 1);
            //Will auto resize based on loaded data
            texture.LoadImage(fileData);
        }
        return texture;
    }
}
