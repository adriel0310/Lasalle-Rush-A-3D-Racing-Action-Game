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
            gameManagerscript.currentPassenger = 1;

            spawnManagerscript.PickupPoints[0].SetActive(false);
            spawnManagerscript.DropOffPoints[0].SetActive(true);
        }
            
        if(gameManagerscript.currentlevel == 2){
            
            spawnManagerscript.PickupPoints[1].SetActive(false); //Despawn CTHM
            spawnManagerscript.DropOffPoints[1].SetActive(true); //Spawn Chapel
            
            gameManagerscript.currentPassenger += 1;
            
        } 
    }
    void OnTriggerExit(Collider col)
    {
       
    } 
}
