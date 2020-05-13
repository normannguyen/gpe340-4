//Norman Nguyen
//Main Menu: Main Menu with button script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //PlayGame - Restart
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Quit
    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
}
