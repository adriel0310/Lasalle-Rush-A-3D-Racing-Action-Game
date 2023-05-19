using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
   // References to individual audio sources
    public AudioSource engineSound;
    public AudioSource backgroundMusic;

    public void Initialize(AudioSource engine, AudioSource music)
    {
        engineSound = engine;
        backgroundMusic = music;
    }

    public void ToggleEngineSound(bool isOn)
    {
        if (engineSound != null)
        {
            engineSound.enabled = isOn;
        }
    }

    public void ToggleBackgroundMusic(bool isOn)
    {
        if (backgroundMusic != null)
        {
        backgroundMusic.enabled = isOn;
        }
    }

    public void SetBackgroundMusicVolume(float volume)
{
    if (backgroundMusic != null)
    {
        backgroundMusic.volume = volume;
    }
}

}




