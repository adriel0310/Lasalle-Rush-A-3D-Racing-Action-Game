using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem instance;
    public List<Quest> quests = new List<Quest>();
    Quest activeQuest;
    public bool pickedup;
    GameManager gameManagerscript;
    SpawnManager spawnManagerscript;

    QuestReceiver questReceiverScript;
    void Start()
    {
        gameManagerscript = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManagerscript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        questReceiverScript = GameObject.Find("QuestReceiver").GetComponent<QuestReceiver>();
    }
    
    void Awake()
    {
        instance = this;
    }
    
    public void AddQuest() //For adding quests only
    {
        if(activeQuest == null)
        {
            activeQuest = quests[Random.Range(0,quests.Count)];
            print("Passenger Picked Up");
        }
    }
    public int ReadActiveQuest()
    {
        return activeQuest.id;
    }

    public int ReadPoints()
    {
        return activeQuest.points;
    }

    public void CompleteQuest(int _id)
    {
        if(activeQuest == null)
        {
            return;
        }

        if(activeQuest.id == _id)
        {
            print("Quest Complete");
            print("Your points" + activeQuest.points);
            print(activeQuest);
            gameManagerscript.AddTime1();
            activeQuest = null;
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            pickedup = true;
            questReceiverScript.droppedoff = false;
            print(pickedup);
        }  
      
        //Check for Current Level and Passenger and Spawn
        if(gameManagerscript.currentlevel == 1)
        {
            //1st passenger
            gameManagerscript.currentPassenger = 1;

            spawnManagerscript.PickupPoints[0].SetActive(false); // Rotonda-pickup despawn
            print("Rotonda De-spawned");
            spawnManagerscript.DropOffPoints[0].SetActive(true); // Chapel-dropoff spawn
             print("Chapel Dropoff Spawned");

        }
            
        if(gameManagerscript.currentlevel == 2)
        {
            //2nd passenger
            if(gameManagerscript.currentPassenger == 1)
            {
                spawnManagerscript.PickupPoints[1].SetActive(false); // ERS-pickup despawn
                print("ERS Pickup De-spawned Level 2");
                spawnManagerscript.DropOffPoints[1].SetActive(true); // ICTC-dropoff spawn
                print("ICTC Dropoff Spawned Level 2");
                
                gameManagerscript.currentPassenger += 1; //currentpassenger = 2
            }
            
            //3rd passenger 
            if(spawnManagerscript.DropOffPoints[1].activeSelf == false & gameManagerscript.currentlevel == 2 & gameManagerscript.currentPassenger == 2 ) //Check if dropoff prefab is not active, current level and current passenger is equal
                {
                    spawnManagerscript.PickupPoints[2].SetActive(false); //NBS- pickup despawn
                    print("NBS Pickup De-spawned Level 2");
                    spawnManagerscript.DropOffPoints[2].SetActive(true); // Square - dropoff Spawn
                    print("Square Dropoff Spawned Level 2");
                    gameManagerscript.currentPassenger += 1; //currentpassenger = 3
                }
        }
        if(gameManagerscript.currentlevel == 3)
        {
            //4th passenger
            if(gameManagerscript.currentPassenger == 3)
            {
                spawnManagerscript.PickupPoints[3].SetActive(false); // COS-pickup despawn
                print("COS Pickup De-spawned Level 3");
                spawnManagerscript.DropOffPoints[3].SetActive(true); // Severino De Las Alas Hall -dropoff spawn
                print("Severino De Las Alas Hall Dropoff Spawned Level 3");
                
                gameManagerscript.currentPassenger += 1; //currentpassenger = 4
            }
            
            //5th passenger 
            if(spawnManagerscript.DropOffPoints[3].activeSelf == false & gameManagerscript.currentlevel == 3 & gameManagerscript.currentPassenger == 4 ) //Check if dropoff prefab is not active, current level and current passenger is equal
                {
                    spawnManagerscript.PickupPoints[4].SetActive(false); //Botanical Graden- pickup despawn
                    print("Botanical Garden Pickup De-spawned Level 3");
                    spawnManagerscript.DropOffPoints[4].SetActive(true); // Gregoria Montoya Hall - dropoff Spawn
                    print("Gregoria Montoya Hall Drop-off Spawned Level 3");
                    gameManagerscript.currentPassenger += 1; //currentpassenger = 5
                }
            
            //6th passenger 
            if(spawnManagerscript.DropOffPoints[4].activeSelf == false & gameManagerscript.currentlevel == 3 & gameManagerscript.currentPassenger == 5 ) //Check if dropoff prefab is not active, current level and current passenger is equal
                {
                    spawnManagerscript.PickupPoints[5].SetActive(false); //CBAA- pickup despawn
                    print("CBAA Pickup De-spawned Level 3");
                    spawnManagerscript.DropOffPoints[5].SetActive(true); //Ayuntamiento - dropoff Spawn
                    print("Ayuntamiento Drop-off Spawned Level 3");
                    gameManagerscript.currentPassenger += 1; //currentpassenger = 6
                } 
        }

        if(gameManagerscript.currentlevel == 4)
        {
            //7th passenger
            if(gameManagerscript.currentPassenger == 6)
            {
                spawnManagerscript.PickupPoints[0].SetActive(false); // Rotonda-pickup despawn
                print("Rotonda Pickup De-spawned Level 4");
                spawnManagerscript.DropOffPoints[6].SetActive(true); // Clothing warehouse-dropoff spawn
                print("Clothing warehouse Drop-off Spawned Level 4");
                
                gameManagerscript.currentPassenger += 1; //currentpassenger = 7
            }
            
            //8th passenger 
            if(spawnManagerscript.DropOffPoints[6].activeSelf == false & gameManagerscript.currentlevel == 4 & gameManagerscript.currentPassenger == 7 ) //Check if dropoff prefab is not active, current level and current passenger is equal
                {
                    spawnManagerscript.PickupPoints[6].SetActive(false); //CTHM- pickup despawn
                    print("CTHM Pickup De-spawned Level 4");
                    spawnManagerscript.DropOffPoints[7].SetActive(true); //ULS - dropoff Spawn
                    print("ULS Drop-off Spawned Level 4");
                    gameManagerscript.currentPassenger += 1; //currentpassenger = 8
                }
            
            //9th passenger 
            if(spawnManagerscript.DropOffPoints[7].activeSelf == false & gameManagerscript.currentlevel == 4 & gameManagerscript.currentPassenger == 8 ) //Check if dropoff prefab is not active, current level and current passenger is equal
                {
                    spawnManagerscript.PickupPoints[7].SetActive(false); //Gate 3- pickup despawn
                    print("Gate 3 Pickup De-spawned Level 4");
                    spawnManagerscript.DropOffPoints[8].SetActive(true); //Museo - dropoff Spawn
                    print("Museo Drop-off Spawned Level 4");
                    gameManagerscript.currentPassenger += 1; //currentpassenger = 9
                } 
        }

        if(gameManagerscript.currentlevel == 5)
        {
            //10th passenger
            if(gameManagerscript.currentPassenger == 9)
            {
                spawnManagerscript.PickupPoints[8].SetActive(false); // JFH-pickup despawn
                print("JFH Pickup De-spawned Level 5");
                spawnManagerscript.DropOffPoints[9].SetActive(true); // Gate 3-dropoff spawn
                print("Gate 3 Drop-off Spawned Level 5");
                
                gameManagerscript.currentPassenger += 1; //currentpassenger = 10
            }
            
            //11th passenger 
            if(spawnManagerscript.DropOffPoints[9].activeSelf == false & gameManagerscript.currentlevel == 5 & gameManagerscript.currentPassenger == 10 ) //Check if dropoff prefab is not active, current level and current passenger is equal
                {
                    spawnManagerscript.PickupPoints[9].SetActive(false); //University pool- pickup despawn
                    print("University pool Pickup De-spawned Level 5");
                    spawnManagerscript.DropOffPoints[10].SetActive(true); //PCH - dropoff Spawn
                    print("PCH Drop-off Spawned Level 5");
                    gameManagerscript.currentPassenger += 1; //currentpassenger = 11
                }
            
            //12th passenger 
            if(spawnManagerscript.DropOffPoints[10].activeSelf == false & gameManagerscript.currentlevel == 5 & gameManagerscript.currentPassenger == 11 ) //Check if dropoff prefab is not active, current level and current passenger is equal
                {
                    spawnManagerscript.PickupPoints[10].SetActive(false); //FCH- pickup despawn
                    print("FCH Pickup De-spawned Level 5");
                    spawnManagerscript.DropOffPoints[11].SetActive(true); //RCC - dropoff Spawn
                    print("RCC Drop-off Spawned Level 5");
                    gameManagerscript.currentPassenger += 1; //currentpassenger = 12
                } 
            
            //13th passenger 
            if(spawnManagerscript.DropOffPoints[11].activeSelf == false & gameManagerscript.currentlevel == 5 & gameManagerscript.currentPassenger == 12 ) //Check if dropoff prefab is not active, current level and current passenger is equal
                {
                    spawnManagerscript.PickupPoints[11].SetActive(false); //ULS- pickup despawn
                    print("ULS Pickup De-spawned Level 5");
                    spawnManagerscript.DropOffPoints[12].SetActive(true); //Mila's - dropoff Spawn
                    print("Mila's Drop-off Spawned Level 5");

                    gameManagerscript.currentPassenger += 1; //currentpassenger = 13
                } 
        }

        if(gameManagerscript.currentlevel == 6)
        {
            //14th passenger
            if(gameManagerscript.currentPassenger == 13)
            {
                spawnManagerscript.PickupPoints[7].SetActive(false); // Gate 3-pickup despawn
                print("Gate 3 Pickup De-spawned Level 6");
                spawnManagerscript.DropOffPoints[13].SetActive(true); // Gate 2-dropoff spawn
                print("Gate 2 Drop-off Spawned Level 6");
                gameManagerscript.currentPassenger += 1; //currentpassenger = 14
            }
            
            //15th passenger 
            if(spawnManagerscript.DropOffPoints[13].activeSelf == false & gameManagerscript.currentlevel == 6 & gameManagerscript.currentPassenger == 14 ) //Check if dropoff prefab is not active, current level and current passenger is equal
                {
                    spawnManagerscript.PickupPoints[12].SetActive(false); //Mariano alvarez hall- pickup despawn
                    print("Mariano alvarez hall Pickup De-spawned Level 6");
                    spawnManagerscript.DropOffPoints[14].SetActive(true); //Grandstand - dropoff Spawn
                    print("Grandstand Drop-off Spawned Level 6");
                    gameManagerscript.currentPassenger += 1; //currentpassenger = 15
                }
            //16th Passenger
            if(spawnManagerscript.DropOffPoints[14].activeSelf == false & gameManagerscript.currentlevel == 6 & gameManagerscript.currentPassenger == 15 ) //Check if dropoff prefab is not active, current level and current passenger is equal
                {
                    spawnManagerscript.PickupPoints[13].SetActive(false); //Grandstand- pickup despawn
                    print("Grandstand Pickup De-spawned Level 6");
                    spawnManagerscript.DropOffPoints[15].SetActive(true); //Gate 1 - dropoff Spawn
                    print("Gate 1 Drop-off Spawned Level 6");
                    gameManagerscript.currentPassenger += 1; //currentpassenger = 16
                }
            //17th Passenger
            if(spawnManagerscript.DropOffPoints[15].activeSelf == false & gameManagerscript.currentlevel == 6 & gameManagerscript.currentPassenger == 16 ) //Check if dropoff prefab is not active, current level and current passenger is equal
                {
                    spawnManagerscript.PickupPoints[0].SetActive(false); //Rotonda- pickup despawn
                    print("Rotonda Pickup De-spawned Level 6");
                    //spawnManagerscript.DropOffPoints[15].SetActive(true); //Gate 1 - dropoff Spawn
                    spawnManagerscript.spawnAll();
                    print("All Drop off points Spawned BAHALA KA NA KUNG SAAN KA PUPUNTA BASTA HINDI KA MABANGGA Level 6 UwU");
                    GameObject.Find("Directional Arrow").SetActive(false);
                    gameManagerscript.currentPassenger += 1; //currentpassenger = 17
                }
        }   
    }
    void OnTriggerExit(Collider col)
    {
       
    } 
}
