using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseui;
    public GameObject optionsvolumeui;
    public GameObject optionscontrolsui;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("pause");
            Time.timeScale = 0;
            pauseui.SetActive(true);
            optionsvolumeui.SetActive(false);
            optionscontrolsui.SetActive(false);
        }
    }

    public void ResumeBtn(){
            Debug.Log("resume");
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
            pauseui.SetActive(true);
            optionsvolumeui.SetActive(false);
            optionscontrolsui.SetActive(false);
        }   
}