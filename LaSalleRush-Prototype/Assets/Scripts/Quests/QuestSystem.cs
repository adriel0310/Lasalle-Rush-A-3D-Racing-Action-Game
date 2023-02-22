using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem instance;
    public List<Quest> quests = new List<Quest>();
    Quest activeQuest;
    public bool PlayerIsHere;
    GameManager gameManagerscript;


    void Start()
    {
        gameManagerscript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void Awake()
    {
        instance = this;
    }
    
    void AddQuest() //For adding quests only
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
            PlayerIsHere = false;
            activeQuest = null;
            print(activeQuest);
            gameManagerscript.AddTime();
            
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            AddQuest();
            PlayerIsHere = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            //PlayerIsHere = false;
            if(gameManagerscript.currentlevel == 1){
                GameObject.FindGameObjectWithTag("Pickup").SetActive(false);
            }
            
            if(gameManagerscript.currentlevel == 2){
                GameObject.FindGameObjectWithTag("CTHM").SetActive(false);
            }
        }
    } 
}
