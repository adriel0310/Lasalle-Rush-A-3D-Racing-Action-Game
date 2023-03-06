using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestReceiver : MonoBehaviour
{
    //public List<Quest> quests = new List<Quest>();
    public int questId;
    
    public bool droppedoff;
    QuestSystem questScript;
    GameManager gameManagerscript;
    SpawnManager spawnManagerscript;


    void Start()
    {
         gameManagerscript = GameObject.Find("GameManager").GetComponent<GameManager>();
         spawnManagerscript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
         questScript = GameObject.Find("QuestSystem").GetComponent<QuestSystem>();
    }
    void OnTriggerEnter(Collider col)
    {
        
        if(col.CompareTag("Player"))
        {
            questScript.pickedup = false;
            droppedoff = true;
        }
            //For Spawning next pick up points
            if(gameManagerscript.currentlevel == 1)
            {
                //QuestSystem.instance.CompleteQuest(questId);
                spawnManagerscript.DropOffPoints[0].SetActive(false); //Despawn Milas
            
                if(droppedoff == true & gameManagerscript.currentlevel == 1){
                    
                    gameManagerscript.AddTime1();
                    gameManagerscript.currentlevel += 1;
                    
                    // spawns for level 2
                    spawnManagerscript.PickupPoints[1].SetActive(true); //CTHM
                }
            }
            
            if(gameManagerscript.currentlevel == 2)
            {
                if(gameManagerscript.currentPassenger == 2)
                {
                    spawnManagerscript.DropOffPoints[1].SetActive(false); // Despawn Chapel

                    if(droppedoff == true & gameManagerscript.currentlevel == 2 & gameManagerscript.currentPassenger == 2 )
                    {
                        gameManagerscript.AddTime23();

                    }
                }
            }
    }
}
