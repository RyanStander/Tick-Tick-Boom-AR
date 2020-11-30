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

    public delegate void GalleryManagerUpdatedDelegate(); //Define the method signature
    public static event GalleryManagerUpdatedDelegate onGalleryManagerUpdated; //Define the event 

    //Fire the event for any subscribed
    public static void GalleryManagerUpdated()
    {
        onGalleryManagerUpdated?.Invoke();
    }

    public delegate void PictureDeleteDelegate(int identifier); //Define the method signature
    public static event PictureDeleteDelegate onPictureDelete; //Define the event 

    //Fire the event for any subscribed
    public static void PictureDelete(int identifier)
    {
        onPictureDelete?.Invoke(identifier);
    }
}
