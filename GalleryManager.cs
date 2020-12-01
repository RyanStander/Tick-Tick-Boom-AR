using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class GalleryManager : MonoBehaviour
{
    //private static Dictionary<int, string> pictures = new Dictionary<int, string>();
    private static List<string> pictures= new List<string>();

    private static int selectedPicture = 0;

    //Listeners
    void OnEnable()
    {
        EventManager.onPictureSelected += UpdateSelectedPicture;
        EventManager.onPictureTaken += AddToPictures;
        EventManager.onPictureDelete += RemoveFromPictures;
    }
    void OnDisable()
    {
        EventManager.onPictureSelected -= UpdateSelectedPicture;
        EventManager.onPictureTaken -= AddToPictures;
        EventManager.onPictureDelete -= RemoveFromPictures;
    }
    private void UpdateSelectedPicture(int identifier)
    {
        selectedPicture = identifier;
    }

    private void Awake()
    {
        GalleryStartUp();
    }

    public void AddToPictures(string givenDirectory)
    {
        //ListMethod
        pictures.Add(givenDirectory);
    }
    public void RemoveFromPictures()
    {
        //If file being removed exists
        if (File.Exists(pictures[selectedPicture]))
        {
            //Delete the file
            File.Delete(pictures[selectedPicture]);

            //Remove from the list
            pictures.RemoveAt(selectedPicture);
        }
    }

    public static List<string> GetPicturesList()
    {
        return pictures;
    }

    private void GalleryStartUp()
    {
        if (pictures!=null)
        {
            //Import images after cleaning list
            pictures.Clear();

            //Get files in directory sorted by date and file type
            foreach (string pictureFP in Directory.GetFiles(
                GetPicturesDirectory()
                , "*.png")
                .OrderBy(f => new FileInfo(f).LastWriteTime)
                .ToList())
            {
                pictures.Add(pictureFP);
            }
        }
    }
    private string GetPicturesDirectory()
    {
        //If file directory does not exist, create
        if (!Directory.Exists(Application.persistentDataPath + "/Pictures"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Pictures");
        }

        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
                return string.Format("{0}/Pictures",
                    Application.dataPath);

            case RuntimePlatform.Android:
                return string.Format("{0}/Pictures",
                    Application.persistentDataPath);

            default:
                return string.Format("{0}/Pictures",
                    System.IO.Directory.GetParent(Application.dataPath).FullName);
        }
    }

    public static int GetSelectedPicture()
    {
        return selectedPicture;
    }
}
