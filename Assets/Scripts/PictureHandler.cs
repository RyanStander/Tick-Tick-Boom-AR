using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PictureHandler : MonoBehaviour
{    
    private Camera currentCamera;
    private bool isTakingPicture = false;

    private void Awake()
    {
        //If not already using itself
        if(currentCamera==null)
        {
            currentCamera = GetComponent<Camera>();
        }
    }

    public void TakePicture()
    {
        // Capture a texture of the current scene with certain parameters
        currentCamera.targetTexture = RenderTexture.GetTemporary(Screen.width, Screen.height,24);

        //For the OnPostRender
        isTakingPicture = true;
    }
    private void OnPostRender()
    {
        if (isTakingPicture)
        {
            isTakingPicture = false;
            SavePNG();
        }
    }
    private void SavePNG()
    {
        //If file directory does not exist, create
        if (!Directory.Exists(Application.persistentDataPath + "/Pictures"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Pictures");
        }
        //DirectoryPath
        string pictureFilePath = GetPictureOutputDirectory();

        //Texture 
        RenderTexture renderTexture = currentCamera.targetTexture;

        //Format the texture to a 2D texture
        Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false); //ARGB32 allows for transparency

        //Read the pixels
        renderResult.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);

        byte[] byteArray = renderResult.EncodeToPNG();
        File.WriteAllBytes(pictureFilePath, byteArray);

        //Cleanup
        RenderTexture.ReleaseTemporary(renderTexture);

        //De-capture the texture of the current scene
        currentCamera.targetTexture = null;

        //Fire off the new image path for any listeners (Gallery Manager)
        EventManager.PictureTaken(pictureFilePath);

        Debug.Log("Saved screenshot to: " + pictureFilePath+", and has been fired off to the event manager!");
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
    private string GetPictureOutputDirectory()
    {
        //If file directory does not exist, create
        if (!Directory.Exists(Application.persistentDataPath + "/Pictures"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Pictures");
        }

        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
                return string.Format("{0}/Pictures/{1}{2}.png",
                    Application.dataPath,
                    "TickTickBoom_",
                    System.DateTime.Now.ToString("yyyyMMdd_HHmmssff"));

            case RuntimePlatform.Android:
                return string.Format("{0}/Pictures/{1}{2}.png",
                    Application.persistentDataPath,
                    "TickTickBoom_",
                    System.DateTime.Now.ToString("yyyyMMddy_HHmmssff"));

            default:
                return string.Format("{0}/Pictures/{1}{2}.png",
                    System.IO.Directory.GetParent(Application.dataPath).FullName,
                    "TickTickBoom_",
                    System.DateTime.Now.ToString("yyyyMMdd_HHmmssff"));
        }
    }
}
