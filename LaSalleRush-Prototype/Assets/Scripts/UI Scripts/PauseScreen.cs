using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseScreen : MonoBehaviour
{
    public GameObject pauseui;
    public GameObject optionsvolumeui;
    public GameObject optionscontrolsui;
    public GameObject leavegamescreen;
    AudioManager audioManagerScript;

    void Start()
    {
        audioManagerScript = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
            if(Input.GetKeyDown(KeyCode.Escape)){
                audioManagerScript.ToggleEngineSound(false);
                Debug.Log("pause");
                Time.timeScale = 0;
                pauseui.SetActive(true);
                optionsvolumeui.SetActive(false);
                optionscontrolsui.SetActive(false);
            }
        }
    

    public void ResumeBtn(){
            Debug.Log("resume");
            audioManagerScript.ToggleEngineSound(true);
            Time.timeScale = 1;
            pauseui.SetActive(false);
            optionsvolumeui.SetActive(false);
            optionscontrolsui.SetActive(false);
        }

    public void OptionsVolumeBtn(){
            Debug.Log("options volume");
            Time.timeScale = 0;
            pauseui.SetActive(false);
            optionsvolumeui.SetActive(true);
            optionscontrolsui.SetActive(false);
        }    

    public void OptionsControlsBtn(){
            Debug.Log("options controls");
            Time.timeScale = 0;
            pauseui.SetActive(false);
            optionsvolumeui.SetActive(false);
            optionscontrolsui.SetActive(true);
        }    

    public void BackToResume(){
            Debug.Log("back");
            Time.timeScale = 0;
            leavegamescreen.SetActive(false);
            pauseui.SetActive(true);
            optionsvolumeui.SetActive(false);
            optionscontrolsui.SetActive(false);
        }
}