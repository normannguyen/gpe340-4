using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;

    // Update is called once per frame
    void Update()
    {
        
    }

    //Set Music Volume
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("Music", volume);
    }

    //SetSFXVolume
    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("Sounds", volume);
    }
}
