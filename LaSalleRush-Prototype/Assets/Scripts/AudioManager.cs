using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AudioManager: MonoBehaviour
{
   // References to individual audio sources
    public AudioSource engineSound;
    public AudioSource backgroundMusic;

    //VOLUME SLIDER
    [SerializeField] Slider volumeSlider; 
    [SerializeField] Slider sfxSlider; 

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            BGLoad();
        }

        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 1);
            SFXLoad();
        }
    }


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

    public void ChangeMusicVolume(){
        backgroundMusic.volume = volumeSlider.value;
        BGSave();
    }
    public void ChangeSFXVolume(){
        engineSound.volume = sfxSlider.value;
        SFXSave();
    }

    private void BGLoad(){
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void BGSave(){
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    private void SFXLoad(){
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void SFXSave(){
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }

}




