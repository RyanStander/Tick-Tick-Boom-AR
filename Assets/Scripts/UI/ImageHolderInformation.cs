using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

public class ImageHolderInformation : MonoBehaviour,IPointerClickHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private string imageDirectory;
    private int identifier;
    private bool isSelected = false;

    //Input/Drag related
    private ScrollRect scrollRectangle=null;
    private bool isDragInput = false;

    //Allows for dragging functionality
    public void OnBeginDrag(PointerEventData eventData)
    {
        scrollRectangle.OnBeginDrag(eventData);
        isDragInput = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        scrollRectangle.OnDrag(eventData);
        isDragInput = true;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        scrollRectangle.OnEndDrag(eventData);
        isDragInput = false;
    }

    //Click event if not dragging
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isDragInput)
        {
            SelectPicture();
            Debug.Log("Picture "+identifier+ " Selected");
        }
    }
    void Awake()
    {
        //Gets the scrolling rectangle
        scrollRectangle = GameObject.FindWithTag("ScrollingGallery").GetComponent<ScrollRect>();

        //If no tag was found, try to find the object by name
        if(scrollRectangle==null)
        {
            //Gets the scrolling rectangle
            scrollRectangle = GameObject.Find("ScrollingGallery").GetComponent<ScrollRect>();
        }
    }
    private void Start()
    {
        GetComponent<RawImage>().texture = LoadPNG(imageDirectory);
    }

    public void RecieveParameters(int givenIdentifier, string givenImageDirectory)
    {
        identifier = givenIdentifier;
        imageDirectory = givenImageDirectory;
    }

    public int GetIdentifier()
    {
        return identifier;
    }
    public string GetDirectory()
    {
        return imageDirectory;
    }
    public bool GetIsSelected()
    {
        return isSelected;
    }
    public void ToggleIsSelected() //Meant to be expanded into multi selection gallery
    {
        if (isSelected)
        {
            isSelected = false;
        }
        else
        {
            isSelected = true;
        }
    }
    public void SelectPicture()
    {
        EventManager.PictureSelected(identifier);
    }

    public Texture2D LoadPNG(string filePath)
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
