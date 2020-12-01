using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void LeaveGame()
    {
        Debug.Log("User is trying to leave the Application!");

        //exits the game
        Application.Quit();
        Debug.Log("User has left the Application!");
    }
}
