using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager: MonoBehaviour
{
   // References to individual audio sources
    public AudioSource engineSound;
    public AudioSource backgroundMusic;

    //VOLUME SLIDER
    public Slider volumeSlider; 
    [SerializeField] Slider sfxSlider; 

    


    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }

        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 1);
        }
        Load();
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

    public void Load(){
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    public void LoadMusicVolume()
    {
        //volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        backgroundMusic.volume = volumeSlider.value;
    }

    public void BGSave(){
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void SFXSave(){
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }

    public void LoadMusicVolume(float volume)
    {
        if (backgroundMusic != null)
        {
            volume = PlayerPrefs.GetFloat("musicVolume");
            backgroundMusic.volume = volume;
        }
    }

}




