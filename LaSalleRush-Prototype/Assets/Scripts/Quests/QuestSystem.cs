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
            spawnManagerscript.DropOffPoints[0].SetActive(true); // Chapel-dropoff spawn

        }
            
        if(gameManagerscript.currentlevel == 2)
        {
            //2nd passenger
            if(gameManagerscript.currentPassenger == 1)
            {
                spawnManagerscript.PickupPoints[1].SetActive(false); // ERS-pickup despawn
                spawnManagerscript.DropOffPoints[1].SetActive(true); // ICTC-dropoff spawn
                
                gameManagerscript.currentPassenger += 1; //currentpassenger = 2
            }
            
            //3rd passenger 
            if(spawnManagerscript.DropOffPoints[1].activeSelf == false & gameManagerscript.currentlevel == 2 & gameManagerscript.currentPassenger == 2 ) //Check if dropoff prefab is not active, current level and current passenger is equal
                {
                    spawnManagerscript.PickupPoints[2].SetActive(false); //NBS- pickup despawn
                    spawnManagerscript.DropOffPoints[2].SetActive(true); // Square - dropoff Spawn
                    gameManagerscript.currentPassenger += 1; //currentpassenger = 3
                }
        }
         if(gameManagerscript.currentlevel == 3)
        {
            //4th passenger
            if(gameManagerscript.currentPassenger == 3)
            {
                spawnManagerscript.PickupPoints[3].SetActive(false); // COS-pickup despawn
                spawnManagerscript.DropOffPoints[3].SetActive(true); // Severino De Las Alas Hall -dropoff spawn
                
                gameManagerscript.currentPassenger += 1; //currentpassenger = 4
            }
            
            //5th passenger 
            if(spawnManagerscript.DropOffPoints[3].activeSelf == false & gameManagerscript.currentlevel == 3 & gameManagerscript.currentPassenger == 4 ) //Check if dropoff prefab is not active, current level and current passenger is equal
                {
                    spawnManagerscript.PickupPoints[4].SetActive(false); //Botanical Graden- pickup despawn
                    spawnManagerscript.DropOffPoints[4].SetActive(true); // Gregoria Montoya Hall - dropoff Spawn
                    gameManagerscript.currentPassenger += 1; //currentpassenger = 5
                }
        }
           
    }
    void OnTriggerExit(Collider col)
    {
       
    } 
}
