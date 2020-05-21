using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
   
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality(int qualitySet)
    {
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Option()
    {

    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
