using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour{

    public GameObject [] cameras;
    public GameObject [] canvas;
    public GameManager timer;
    public GameObject control;

    void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible =true;
        control.SetActive(false);
        cameras[0].SetActive(false);
        cameras[1].SetActive(true);
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);
        canvas[2].SetActive(false);
        canvas[3].SetActive(false);
        canvas[4].SetActive(false);
        canvas[5].SetActive(false);
        canvas[6].SetActive(false);
    }

    void Update(){
    }

    public void Play(){
        Debug.Log("hi");
        canvas[0].SetActive(false);
        canvas[1].SetActive(true);
        canvas[2].SetActive(false);
        canvas[3].SetActive(false);
        canvas[4].SetActive(false);
        canvas[5].SetActive(false);
        canvas[6].SetActive(false);
     }

     public void Back(){
        cameras[0].SetActive(false);
        cameras[1].SetActive(true);
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);
        canvas[2].SetActive(false);
        canvas[3].SetActive(false);
        canvas[4].SetActive(false);
        canvas[5].SetActive(false);
        canvas[6].SetActive(false);
     }

     public void Options_Volume(){
        cameras[0].SetActive(false);
        cameras[1].SetActive(true);
        canvas[0].SetActive(false);
        canvas[1].SetActive(false);
        canvas[2].SetActive(false);
        canvas[3].SetActive(true);
        canvas[4].SetActive(false);
        canvas[5].SetActive(false);
        canvas[6].SetActive(false);
     }

     public void Options_Controls(){
        cameras[0].SetActive(false);
        cameras[1].SetActive(true);
        canvas[0].SetActive(false);
        canvas[1].SetActive(false);
        canvas[2].SetActive(false);
        canvas[3].SetActive(false);
        canvas[4].SetActive(true);
        canvas[5].SetActive(false);
        canvas[6].SetActive(false);
     }

     public void Start_Game(){
        control.SetActive(true);
        cameras[0].SetActive(true);
        cameras[1].SetActive(false);
        canvas[0].SetActive(false);
        canvas[1].SetActive(false);
        canvas[2].SetActive(true);
        canvas[3].SetActive(false);
        canvas[4].SetActive(false);
        canvas[5].SetActive(true);
        canvas[6].SetActive(false);
        timer.enabled = true;
      }
}