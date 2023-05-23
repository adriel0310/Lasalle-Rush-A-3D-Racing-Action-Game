using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApp : MonoBehaviour
{
    public GameObject exitgameui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitPopup(){
        exitgameui.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DontQuit(){
        exitgameui.SetActive(false);
    }

}
