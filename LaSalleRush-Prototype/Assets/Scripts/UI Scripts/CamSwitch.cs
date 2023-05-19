using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CamSwitch : MonoBehaviour{

      public GameObject [] cameras;
      public GameObject [] canvas;
      public GameObject [] tutorial; 
      public GameObject continueImage;
      public GameObject exitImage;
      

      public GameObject arrow;

      public GameManager timer;
      public GameObject control; 
      public GameObject tutorialButton;
      SpawnManager spawnManagerScript;
      public TutorialScript tutorialScript;
      public TextMeshProUGUI allScoresTextComponent;
      public TMP_InputField nameInputField;

      AudioManager audioManagerScript;

    public void Start(){
        audioManagerScript = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        tutorialScript = GameObject.Find("TutorialMode").GetComponent<TutorialScript>();
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
        canvas[7].SetActive(false);
        canvas[8].SetActive(false);
        canvas[9].SetActive(false);
        canvas[10].SetActive(false);
        canvas[11].SetActive(false);
        canvas[12].SetActive(false);
        canvas[13].SetActive(false);
        canvas[15].SetActive(false);
        canvas[15].SetActive(false);
        continueImage.SetActive(false);
        exitImage.SetActive(false);
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
        canvas[7].SetActive(false);
        canvas[8].SetActive(false);
        canvas[9].SetActive(false);
        canvas[10].SetActive(false);
        canvas[11].SetActive(false);
        canvas[12].SetActive(false);
        canvas[13].SetActive(false);
        tutorialButton.SetActive(true);
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
        canvas[7].SetActive(false);
        canvas[8].SetActive(false);
        canvas[9].SetActive(false);
        canvas[10].SetActive(false);
        canvas[11].SetActive(false);
        canvas[12].SetActive(false);
        canvas[13].SetActive(false);
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
        canvas[7].SetActive(false);
        canvas[8].SetActive(false);
        canvas[9].SetActive(false);
        canvas[10].SetActive(false);
        canvas[11].SetActive(false);
        canvas[12].SetActive(false);
        canvas[13].SetActive(false);
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
        canvas[7].SetActive(false);
        canvas[8].SetActive(false);
        canvas[9].SetActive(false);
        canvas[10].SetActive(false);
        canvas[11].SetActive(false);
        canvas[12].SetActive(false);
        canvas[13].SetActive(false);
     }

     public void Leaderboards(){
      cameras[0].SetActive(false);
        cameras[1].SetActive(true);
        canvas[0].SetActive(false);
        canvas[1].SetActive(false);
        canvas[2].SetActive(false);
        canvas[3].SetActive(false);
        canvas[4].SetActive(false);
        canvas[5].SetActive(false);
        canvas[6].SetActive(false);
        canvas[7].SetActive(false);
        canvas[8].SetActive(false);
        canvas[9].SetActive(false);
        canvas[10].SetActive(false);
        canvas[11].SetActive(false);
        canvas[12].SetActive(false);
        canvas[13].SetActive(false);
        canvas[14].SetActive(false);
        canvas[15].SetActive(true);
        canvas[16].SetActive(false);
     }

     public void Tutorial(){
        GameObject tutorialBtn = GameObject.Find("TutorialBtn");
         if (tutorialBtn != null)
         {
            tutorialBtn.SetActive(true); // Set the TutorialBtn game object to active temporarily

            TutorialScript tutorialScript = tutorialBtn.GetComponent<TutorialScript>();
            if (tutorialScript != null)
            {
               Debug.Log("access");
               Time.timeScale = 1;
               tutorialScript.StartTutorial();
            }

            tutorialBtn.SetActive(false); // Set the TutorialBtn game object back to inactive
         }

        Time.timeScale = 1;
        control.SetActive(true);
        cameras[0].SetActive(true);
        cameras[1].SetActive(false);
        canvas[0].SetActive(false);
        canvas[1].SetActive(false);
        canvas[2].SetActive(false);
        canvas[3].SetActive(false);
        canvas[4].SetActive(false);
        canvas[5].SetActive(false);
        canvas[6].SetActive(false);
        canvas[7].SetActive(false);
        canvas[8].SetActive(false);
        canvas[9].SetActive(false);
        canvas[10].SetActive(false);
        canvas[11].SetActive(false);
        canvas[12].SetActive(false);
        canvas[13].SetActive(false);
        canvas[16].SetActive(false);
        canvas[17].SetActive(true);
        arrow.SetActive(false);
        timer.enabled = false;

      }

   public void DisplayAllScoresBtn()
   {
      const int rankWidth = 5;
      const int scoreWidth = 10;

      int nameWidth = nameInputField.characterLimit;

      string allScoresText = "";
      var playerScores = PlayerPrefs.GetString("PlayerNames").Split(',')
         .Select(key => new { Name = key, Score = PlayerPrefs.GetInt(key) })
         .Where(ps => ps.Score > 0) // Only include players with a score greater than 0
         .OrderByDescending(ps => ps.Score)
         .ToList();

      int rank = 1;
      foreach (var ps in playerScores)
      {
         string rankText = $"{rank}.";
         string nameText = $"{ps.Name}";
         string scoreText = $"{ps.Score}";

         rankText = rankText.PadRight(rankWidth);
         nameText = nameText.PadRight(nameWidth);
         scoreText = scoreText.PadLeft(scoreWidth);

         allScoresText += $"{rankText} {nameText} {scoreText}\n";

         rank++;
      }

      allScoresText = allScoresText.TrimEnd(); // Remove the last newline character
      allScoresTextComponent.text = allScoresText;

      Time.timeScale = 0;
   }

     public void Start_Game(){
        Time.timeScale = 1;
        spawnManagerScript.FirstLevel();
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
        canvas[7].SetActive(false);
        canvas[8].SetActive(false);
        canvas[9].SetActive(false);
        canvas[10].SetActive(false);
        canvas[11].SetActive(false);
        canvas[12].SetActive(false);
        canvas[13].SetActive(false);
        arrow.SetActive(true);
        timer.enabled = true;
        
        audioManagerScript.ToggleEngineSound(true);
      }

      public void Free_Mode(){
        Time.timeScale = 1;
        control.SetActive(true);
        cameras[0].SetActive(true);
        cameras[1].SetActive(false);
        canvas[0].SetActive(false);
        canvas[1].SetActive(false);
        canvas[2].SetActive(false);
        canvas[3].SetActive(false);
        canvas[4].SetActive(false);
        canvas[5].SetActive(false);
        canvas[6].SetActive(false);
        canvas[7].SetActive(false);
        canvas[8].SetActive(false);
        canvas[9].SetActive(false);
        canvas[10].SetActive(false);
        canvas[11].SetActive(false);
        canvas[12].SetActive(false);
        canvas[13].SetActive(false);
        canvas[16].SetActive(true);
        timer.enabled = false;
      }

      public void SplashScreen(){
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
        canvas[7].SetActive(false);
        canvas[8].SetActive(false);
        canvas[9].SetActive(false);
        canvas[10].SetActive(false);
        canvas[11].SetActive(false);
        canvas[12].SetActive(false);
        canvas[13].SetActive(false);
      }
}