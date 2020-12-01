using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void PictureTakenDelegate(string directoryPath); //Define the method signature
    public static event PictureTakenDelegate onPictureTaken; //Define the event 

    //Fire the event for any subscribed
    public static void PictureTaken(string directoryPath)
    {
        onPictureTaken?.Invoke(directoryPath);
    }

    public delegate void PictureDeleteDelegate(); //Define the method signature
    public static event PictureDeleteDelegate onPictureDelete; //Define the event 

    //Fire the event for any subscribed
    public static void PictureDelete()
    {
        onPictureDelete?.Invoke();
    }

    public delegate void PictureSelectedDelegate(int identifier); //Define the method signature
    public static event PictureSelectedDelegate onPictureSelected; //Define the event 

    //Fire the event for any subscribed
    public static void PictureSelected(int identifier)
    {
        onPictureSelected?.Invoke(identifier);
    }
}
