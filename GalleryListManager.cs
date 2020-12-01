using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryListManager : MonoBehaviour
{
    [SerializeField]
    private GameObject imageHolderTemplate=null;

    private List<GameObject> imageHolders = new List<GameObject>();

    private bool mustBeUpdated = false;

    //Listeners
    void OnEnable()
    {
        UpdateNextOpening();
    }

    void UpdateNextOpening()
    {
        mustBeUpdated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mustBeUpdated)
        {
            DeleteOldHolders();
            CreateGalleryImageHolders();
            mustBeUpdated = false;
        }
    }
    void DeleteOldHolders()
    {
        //Deletes each holder
        foreach(GameObject holder in imageHolders)
        {
            Destroy(holder);
        }
        //Clears the list to free up memory of potential junk space
        imageHolders.Clear();
    }
    void CreateGalleryImageHolders()
    {
        for(int i=0; i < GalleryManager.GetPicturesList().Count; i++)
        {
            //GetDirectory
            string directoryPath = GalleryManager.GetPicturesList()[i];

            //Instantiate holder with information
            GameObject holder = Instantiate(imageHolderTemplate,Vector3.zero,Quaternion.identity,this.transform);

            holder.GetComponent<ImageHolderInformation>().RecieveParameters(i, directoryPath);

            //Add to deletable list
            imageHolders.Add(holder);
        }
    }

    //void Start()
    //{
    //    StartCoroutine(MyOperation());
    //}
    //IEnumerator MyOperation()
    //{
    //    yield return WaitForEndOfFrame();
    //}
}
