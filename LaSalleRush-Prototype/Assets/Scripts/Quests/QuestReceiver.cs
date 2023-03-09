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
            //1st passenger
            //For Spawning next pick up points
            if(gameManagerscript.currentlevel == 1)
            {
                //QuestSystem.instance.CompleteQuest(questId);
                spawnManagerscript.DropOffPoints[0].SetActive(false); //Chapel-dropoff despawn
            
                if(droppedoff == true & gameManagerscript.currentlevel == 1){
                    
                    gameManagerscript.AddTime1();
                    gameManagerscript.currentlevel += 1;
                    
                    // spawns for level 2
                    spawnManagerscript.PickupPoints[1].SetActive(true); //ERS-pickup Spawn
                }
            }
            
            if(gameManagerscript.currentlevel == 2) //Level 2
            {
                //2nd passenger
                if(gameManagerscript.currentPassenger == 2)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 2 & gameManagerscript.currentPassenger == 2 )
                    {
                        spawnManagerscript.DropOffPoints[1].SetActive(false); //ICTC-dropoff despawn
                        spawnManagerscript.PickupPoints[2].SetActive(true); //NBS- pickup spawn
                        gameManagerscript.AddTime23();  
                    }
                    
                }
                //3rd Passenger
                if(gameManagerscript.currentPassenger == 3)
                {

                    if(droppedoff == true & gameManagerscript.currentlevel == 2 & gameManagerscript.currentPassenger == 3 )
                    {
                        //LEVEL FINISHED 
                        //Add Score System and UI 

                        gameManagerscript.AddTime23();
                        spawnManagerscript.DropOffPoints[2].SetActive(false); // Square - dropoff despawn
                        spawnManagerscript.PickupPoints[3].SetActive(true); //COS- pickup spawn
                        gameManagerscript.currentlevel += 1;
                    }
                }   
            }

            if(gameManagerscript.currentlevel == 3) //Level 3
            {
                //4th passenger
                if(gameManagerscript.currentPassenger == 4)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 3 & gameManagerscript.currentPassenger == 4)
                    {
                        spawnManagerscript.DropOffPoints[3].SetActive(false); //Severino De Las Alas Hall -dropoff despawn
                        spawnManagerscript.PickupPoints[4].SetActive(true); //Botanical Garden - pickup spawn
                        gameManagerscript.AddTime23();
                    }
                    
                }
                //5th Passenger
                if(gameManagerscript.currentPassenger == 5)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 3 & gameManagerscript.currentPassenger == 5 )
                    {
                        gameManagerscript.AddTime23();
                        spawnManagerscript.DropOffPoints[4].SetActive(false); // Gregoria Montoya Hall - dropoff despawn
                        spawnManagerscript.PickupPoints[5].SetActive(true); //COS- pickup spawn
                    }
                }   
            }
    }
}
