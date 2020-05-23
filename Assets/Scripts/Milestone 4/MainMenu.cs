//Norman Nguyen
//Main Menu: Main Menu with button script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //PlayGame - Restart
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    //Quit
    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
}
