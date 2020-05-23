using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    [Header("UI")]
    public AudioMixer audioMixer;
    public GameObject settingsUI;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sFXVolumeSlider;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    // public Toggle fullScreenToggle;

    [Header("Volume")]
    public float masterVolume;
    public float musicVolume;
    public float sFXVolume;

    //Resolution
    Resolution[] resolutions;
   
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        //Getters for Audio
        masterVolumeSlider.value = masterVolume;
        musicVolumeSlider.value = musicVolume;
        sFXVolumeSlider.value = sFXVolume;
        audioMixer.GetFloat("Master", out masterVolume);
        audioMixer.GetFloat("Music", out musicVolume);
        audioMixer.GetFloat("Sounds", out sFXVolume);

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    //Update on the music
    void Update()
    {
        masterVolume = masterVolumeSlider.value;
        musicVolume = musicVolumeSlider.value;
        sFXVolume = sFXVolumeSlider.value;
        audioMixer.SetFloat("Master", masterVolume);
        audioMixer.SetFloat("Music", musicVolume);
        audioMixer.SetFloat("Sounds", sFXVolume);
    }
    //Set Resolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Quality
    public void SetQuality(int qualitySet)
    {
        QualitySettings.SetQualityLevel(qualitySet);
    }

    //FullScreen
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
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
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
