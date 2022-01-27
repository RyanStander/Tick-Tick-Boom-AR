using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SharePicture : MonoBehaviour
{
	[SerializeField]
	private string shareMessage = "Check out this cool picture I took with TickTickBoom!";

	//To be adapted
	public void ClickShareButton()
    {
		//DictionaryMethod
		//GalleryManager.GetPicturesDictionary().TryGetValue(GalleryManager.GetSelectedPicture(), out string directory);
		//StartCoroutine(ExportGivenPicture(directory));

		//ListMethod
		StartCoroutine(ExportGivenPicture(GalleryManager.GetPicturesList()[GalleryManager.GetSelectedPicture()])); 
    }

	//The code below was based on the following repositorys example: https://github.com/yasirkula/UnityNativeShare
	//However it has been changed and adapted to our type of application
	private IEnumerator ExportGivenPicture(string givenImagePath)
	{
		yield return new WaitForEndOfFrame();

		new NativeShare().AddFile(givenImagePath)
			.SetSubject("TickTickBOOM").SetText(shareMessage)
			.SetCallback((result, shareTarget) => Debug.Log("Shared result: " + result + ", with selected app: " + shareTarget))
			.Share();
	}
}
