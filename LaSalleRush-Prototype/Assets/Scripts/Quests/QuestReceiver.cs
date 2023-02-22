using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestReceiver : MonoBehaviour
{
    //public List<Quest> quests = new List<Quest>();
    public int questId;
    QuestSystem quest;
    GameManager gameManagerscript;


    void Start()
    {
         gameManagerscript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            QuestSystem.instance.CompleteQuest(questId);
            
            //For Spawning next pick up points
            if(gameManagerscript.currentlevel == 1)
            {
                gameManagerscript.currentlevel += 1;
                GameObject.FindGameObjectWithTag("Dropoff").SetActive(false);
            }
            
            if(gameManagerscript.currentlevel == 2)
            {
                //GameObject.FindGameObjectWithTag("CTHM").SetActive(true);
            }

        }
    }
 
}
