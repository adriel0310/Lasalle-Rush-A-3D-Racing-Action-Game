using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseScreen : MonoBehaviour
{
    public GameObject pauseui;

    public GameObject freemodepauseui;
    public GameObject optionsvolumeui;
    public GameObject optionscontrolsui;
    public GameObject leavegamescreen;
    public GameObject leavegamefreemode;
    public GameObject freemodepanel;
    public GameObject ingamepanel;

    AudioManager audioManagerScript;

    void Start()
    {
        audioManagerScript = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(freemodepanel.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Escape)){
                
            audioManagerScript.ToggleEngineSound(false);
            Debug.Log("pause");
            Time.timeScale = 0;
            freemodepauseui.SetActive(true);
            optionsvolumeui.SetActive(false);
            optionscontrolsui.SetActive(false); 
        }
    
        }

         if(ingamepanel.activeSelf)
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
    } 
    

    public void ResumeBtn()
    {

         if(freemodepanel.activeSelf)
         {
            audioManagerScript.ToggleEngineSound(true);
            Debug.Log("pause");
            Time.timeScale = 1;
            freemodepauseui.SetActive(false);
            optionsvolumeui.SetActive(false);
            optionscontrolsui.SetActive(false); 
         }

         if(ingamepanel.activeSelf)

         {
            Debug.Log("resume");
            audioManagerScript.ToggleEngineSound(true);
            Time.timeScale = 1;
            pauseui.SetActive(false);
            optionsvolumeui.SetActive(false);
            optionscontrolsui.SetActive(false);
         }
    
    }

    public void OptionsVolumeBtn(){

        if(freemodepanel.activeSelf)
        {
            Debug.Log("options volume");
            Time.timeScale = 0;
            freemodepauseui.SetActive(false);
            optionsvolumeui.SetActive(true);
            optionscontrolsui.SetActive(false);
        }

        
        if(ingamepanel.activeSelf)
        {
            Debug.Log("options volume");
            Time.timeScale = 0;
            pauseui.SetActive(false);
            optionsvolumeui.SetActive(true);
            optionscontrolsui.SetActive(false);
        }
        }    

    public void OptionsControlsBtn(){
         if(freemodepanel.activeSelf)
        {
            Debug.Log("options controls");
            Time.timeScale = 0;
            freemodepauseui.SetActive(false);
            optionsvolumeui.SetActive(false);
            optionscontrolsui.SetActive(true);
        }

        
        if(ingamepanel.activeSelf)
        {
            Debug.Log("options controls");
            Time.timeScale = 0;
            pauseui.SetActive(false);
            optionsvolumeui.SetActive(false);
            optionscontrolsui.SetActive(true);
        }

    }    

    public void BackToResume(){

            if(freemodepanel.activeSelf)
            {
                Debug.Log("back");
                Time.timeScale = 0;
                leavegamefreemode.SetActive(false);
                freemodepauseui.SetActive(true);
                optionsvolumeui.SetActive(false);
                optionscontrolsui.SetActive(false);

            }

            
            if(ingamepanel.activeSelf)
            {
                Debug.Log("back");
                Time.timeScale = 0;
                leavegamescreen.SetActive(false);
                pauseui.SetActive(true);
                optionsvolumeui.SetActive(false);
                optionscontrolsui.SetActive(false);
            }



        }
}