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
                        spawnManagerscript.PickupPoints[5].SetActive(true); //CBAA- pickup spawn
                    }
                }  
                //6th Passenger
                if(gameManagerscript.currentPassenger == 6)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 3 & gameManagerscript.currentPassenger == 6)
                    {
                        spawnManagerscript.DropOffPoints[5].SetActive(false); //Ayuntamiento -dropoff despawn
                        spawnManagerscript.PickupPoints[0].SetActive(true); //Rotonda - pickup spawn
                        gameManagerscript.AddTime23();
                        gameManagerscript.currentlevel += 1;
                    }
                    
                } 
            }
            if(gameManagerscript.currentlevel == 4) //Level 4
            {
                //7th passenger
                if(gameManagerscript.currentPassenger == 7)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 4 & gameManagerscript.currentPassenger == 4)
                    {
                        spawnManagerscript.DropOffPoints[6].SetActive(false); //Clothing warehouse-dropoff despawn
                        spawnManagerscript.PickupPoints[6].SetActive(true); //CTHM - pickup spawn
                        gameManagerscript.AddTime4();
                    }
                }
                //8th passenger
                if(gameManagerscript.currentPassenger == 8)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 4 & gameManagerscript.currentPassenger == 8)
                    {
                        spawnManagerscript.DropOffPoints[7].SetActive(false); //ULS -dropoff despawn
                        spawnManagerscript.PickupPoints[7].SetActive(true); //Gate 3 - pickup spawn
                        gameManagerscript.AddTime4();
                    }    
                }
                //9th passenger
                if(gameManagerscript.currentPassenger == 9)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 4 & gameManagerscript.currentPassenger == 4)
                    {
                        spawnManagerscript.DropOffPoints[8].SetActive(false); //Museo -dropoff despawn
                        spawnManagerscript.PickupPoints[8].SetActive(true); //JFH - pickup spawn
                        gameManagerscript.AddTime4();
                        gameManagerscript.currentlevel += 1;
                    }   
                }
                }
            if(gameManagerscript.currentlevel == 5) //Level 5
            {
                //10th passenger
                if(gameManagerscript.currentPassenger == 10)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 5 & gameManagerscript.currentPassenger == 10)
                    {
                        spawnManagerscript.DropOffPoints[9].SetActive(false); //Gate 3 -dropoff despawn
                        spawnManagerscript.PickupPoints[9].SetActive(true); //University pool-pickup spawn
                        gameManagerscript.AddTime5();
                    }
                }
                //11th passenger
                if(gameManagerscript.currentPassenger == 11)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 5 & gameManagerscript.currentPassenger == 11)
                    {
                        spawnManagerscript.DropOffPoints[10].SetActive(false); //PCH-dropoff despawn
                        spawnManagerscript.PickupPoints[10].SetActive(true); //FCH-pickup spawn
                        gameManagerscript.AddTime5();
                    }
                }
                //12th passenger
                if(gameManagerscript.currentPassenger == 12)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 5 & gameManagerscript.currentPassenger == 12)
                    {
                        spawnManagerscript.DropOffPoints[11].SetActive(false); //RCC-dropoff despawn
                        spawnManagerscript.PickupPoints[11].SetActive(true); //ULS-pickup spawn
                        gameManagerscript.AddTime5();
                    }
                }
                //13th passenger
                if(gameManagerscript.currentPassenger == 13)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 5 & gameManagerscript.currentPassenger == 13)
                    {
                        spawnManagerscript.DropOffPoints[12].SetActive(false); //Mila's-dropoff despawn
                        spawnManagerscript.PickupPoints[7].SetActive(true); //Gate 3-pickup spawn
                        gameManagerscript.AddTime5();
                        gameManagerscript.currentlevel += 1;
                    }
                }
            }
            if(gameManagerscript.currentlevel == 6) //Level 6
            {
                //14th passenger
                if(gameManagerscript.currentPassenger == 14)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 6 & gameManagerscript.currentPassenger == 14)
                    {
                        spawnManagerscript.DropOffPoints[13].SetActive(false); //Gate 2-dropoff despawn
                        spawnManagerscript.PickupPoints[12].SetActive(true); //Mariano Alvarez-pickup spawn
                        gameManagerscript.AddTime6();
                    }
                }
            }
    }
}
