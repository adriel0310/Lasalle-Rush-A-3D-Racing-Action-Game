using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class QuestReceiver : MonoBehaviour
{
    //public List<Quest> quests = new List<Quest>();
    public int questId;
    
    public bool droppedoff;
    QuestSystem questScript;
    GameManager gameManagerscript;
    SpawnManager spawnManagerscript;

    [SerializeField] TextMeshProUGUI PickUpPoint;
    [SerializeField] TextMeshProUGUI DropOffPoint;
    public GameObject PickUpPointlbl;
    public GameObject DropOffPointlbl;


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
            gameManagerscript.LevelObjective();
            questScript.pickedup = false;
            droppedoff = true;
        }
            //1st passenger
            //For Spawning next pick up points
            if(gameManagerscript.currentlevel == 1)
            {
                //QuestSystem.instance.CompleteQuest(questId);
                spawnManagerscript.DropOffPoints[0].SetActive(false); //Chapel-dropoff despawn
                print("Chapel Dropoff De-spawned");
            
                if(droppedoff == true & gameManagerscript.currentlevel == 1){
                    
                    gameManagerscript.AddLRCoins1();
                    gameManagerscript.LevelComplete(); //UI Will Appear
                    gameManagerscript.AddTime1();
                    gameManagerscript.currentlevel += 1;
                    
                    // spawns for level 2
                    spawnManagerscript.PickupPoints[1].SetActive(true); //ERS-pickup Spawn
                    print("ERS Pickup Spawned Level 2");
                    DropOffPointlbl.SetActive(false);
                    PickUpPointlbl.SetActive(true);
                    DropOffPoint.enabled = false;
                    PickUpPoint.enabled = true;
                    PickUpPoint.text = "ERS";

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
                        print("ICTC Dropoff De-spawned Level 2");
                        spawnManagerscript.PickupPoints[2].SetActive(true); //NBS- pickup spawn
                        print("NBS Pickup spawned Level 2");

                        gameManagerscript.AddLRCoins23();
                        gameManagerscript.AddTime23();
                          
                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "National Bookstore";   
                          
                    }
                    
                }
                //3rd Passenger
                if(gameManagerscript.currentPassenger == 3)
                {

                    if(droppedoff == true & gameManagerscript.currentlevel == 2 & gameManagerscript.currentPassenger == 3 )
                    {
                        //LEVEL FINISHED 
                        //Add Score System and UI 
                        gameManagerscript.AddLRCoins23();
                        gameManagerscript.LevelComplete();
                        gameManagerscript.AddTime23();
                        spawnManagerscript.DropOffPoints[2].SetActive(false); // Square - dropoff despawn
                        print("Square Dropoff De-spawned Level 2");
                        spawnManagerscript.PickupPoints[3].SetActive(true); //COS- pickup spawn
                        print("COS Pickup Spawned Level 3");
                        gameManagerscript.currentlevel += 1;

                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "COS";   
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
                        print("Severino De Las Alas Hall Dropoff De-spawned Level 3");
                        spawnManagerscript.PickupPoints[4].SetActive(true); //Botanical Garden - pickup spawn
                        print("Botanical Garden Pickup Spawned Level 3");
                        gameManagerscript.AddLRCoins23();
                        gameManagerscript.AddTime23();

                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "Botanical Garden";   

                    }
                    
                }
                //5th Passenger
                if(gameManagerscript.currentPassenger == 5)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 3 & gameManagerscript.currentPassenger == 5 )
                    {
                        gameManagerscript.AddLRCoins23();
                        gameManagerscript.AddTime23();
                        spawnManagerscript.DropOffPoints[4].SetActive(false); // Gregoria Montoya Hall - dropoff despawn
                        print("Gregoria Montoya Hall Dropoff De-spawned Level 3");
                        spawnManagerscript.PickupPoints[5].SetActive(true); //CBAA- pickup spawn
                        print("CBAA Pickup Spawned Level 3");

                        
                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "CBAA";  

                    }
                }  
                //6th Passenger
                if(gameManagerscript.currentPassenger == 6)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 3 & gameManagerscript.currentPassenger == 6)
                    {
                        spawnManagerscript.DropOffPoints[5].SetActive(false); //Ayuntamiento -dropoff despawn
                        print("Ayuntamiento Dropoff De-spawned Level 3");
                        spawnManagerscript.PickupPoints[0].SetActive(true); //Rotonda - pickup spawn
                        print("Rotonda Pickup Spawned Level 4");
                        gameManagerscript.AddLRCoins23();
                        gameManagerscript.AddTime23();
                        gameManagerscript.currentlevel += 1;

                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "Gate 1 Rotonda";  

                    }
                    
                } 
            }
            if(gameManagerscript.currentlevel == 4) //Level 4
            {
                //7th passenger
                if(gameManagerscript.currentPassenger == 7)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 4 & gameManagerscript.currentPassenger == 7)
                    {
                        spawnManagerscript.DropOffPoints[6].SetActive(false); //Clothing warehouse-dropoff despawn
                        print("Clothing warehouse Dropoff De-Spawned Level 4");
                        spawnManagerscript.PickupPoints[6].SetActive(true); //CTHM - pickup spawn
                        print("CTHM Pickup Spawned Level 4");
                        gameManagerscript.AddLRCoins4();
                        gameManagerscript.AddTime4();

                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "CTHM";  
                    }
                }
                //8th passenger
                if(gameManagerscript.currentPassenger == 8)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 4 & gameManagerscript.currentPassenger == 8)
                    {
                        spawnManagerscript.DropOffPoints[7].SetActive(false); //ULS -dropoff despawn
                        print("ULS Dropoff De-Spawned Level 4");
                        spawnManagerscript.PickupPoints[7].SetActive(true); //Gate 3 - pickup spawn
                        print("Gate 3 Pickup Spawned Level 4");
                        gameManagerscript.AddLRCoins23();
                        gameManagerscript.AddTime4();

                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "Gate 3";  
                    }    
                }
                //9th passenger
                if(gameManagerscript.currentPassenger == 9)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 4 & gameManagerscript.currentPassenger == 9)
                    {
                        spawnManagerscript.DropOffPoints[8].SetActive(false); //Museo -dropoff despawn
                        print("Museo Dropoff De-Spawned Level 4");
                        spawnManagerscript.PickupPoints[8].SetActive(true); //JFH - pickup spawn
                        print("JFH Pickup Spawned Level 5");
                        
                        gameManagerscript.AddLRCoins23();
                        gameManagerscript.AddTime4();
                        gameManagerscript.currentlevel += 1;

                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "JFH";  
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
                        print("Gate 3 Dropoff De-Spawned Level 5");
                        spawnManagerscript.PickupPoints[9].SetActive(true); //University pool-pickup spawn
                        print("University pool Pickup Spawned Level 5");

                        gameManagerscript.AddLRCoins5();
                        gameManagerscript.AddTime5();

                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "University Pool";  
                    }
                }
                //11th passenger
                if(gameManagerscript.currentPassenger == 11)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 5 & gameManagerscript.currentPassenger == 11)
                    {
                        spawnManagerscript.DropOffPoints[10].SetActive(false); //PCH-dropoff despawn
                        print("PCH Dropoff De-Spawned Level 5");
                        spawnManagerscript.PickupPoints[10].SetActive(true); //FCH-pickup spawn
                        print("FCH Pickup Spawned Level 5");

                        gameManagerscript.AddLRCoins5();
                        gameManagerscript.AddTime5();

                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "FCH";  
                    }
                }
                //12th passenger
                if(gameManagerscript.currentPassenger == 12)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 5 & gameManagerscript.currentPassenger == 12)
                    {
                        spawnManagerscript.DropOffPoints[11].SetActive(false); //RCC-dropoff despawn
                        print("RCC Dropoff De-Spawned Level 5");
                        spawnManagerscript.PickupPoints[11].SetActive(true); //ULS-pickup spawn
                        print("ULS Pickup Spawned Level 5");

                        gameManagerscript.AddLRCoins5();
                        gameManagerscript.AddTime5();

                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "Ugnayang La Salle";  
                    }
                }
                //13th passenger
                if(gameManagerscript.currentPassenger == 13)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 5 & gameManagerscript.currentPassenger == 13)
                    {
                        spawnManagerscript.DropOffPoints[12].SetActive(false); //Mila's-dropoff despawn
                        print("Mila's Dropoff De-Spawned Level 5");
                        spawnManagerscript.PickupPoints[7].SetActive(true); //Gate 3-pickup spawn
                        print("Gate 3 Pickup Spawned Level 6");

                        gameManagerscript.AddLRCoins5();
                        gameManagerscript.AddTime5();
                        gameManagerscript.currentlevel += 1;

                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "Gate 3"; 
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
                        print("Gate 2 Dropoff De-Spawned Level 6");
                        spawnManagerscript.PickupPoints[12].SetActive(true); //Mariano Alvarez-pickup spawn
                        print("Mariano Alvarez Pickup Spawned Level 6");
                        
                        gameManagerscript.AddLRCoins6();
                        gameManagerscript.AddTime6();

                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "Mariano Alvarez Hall"; 
                    }
                }

                if(gameManagerscript.currentPassenger == 15)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 6 & gameManagerscript.currentPassenger == 15)
                    {
                        spawnManagerscript.DropOffPoints[14].SetActive(false); //Grandstand-dropoff despawn
                        print("Grandstand Dropoff De-Spawned Level 6");
                        spawnManagerscript.PickupPoints[13].SetActive(true); //Grandstand-pickup spawn
                        print("Grandstand Pickup Spawned Level 6");
                        
                        gameManagerscript.AddLRCoins6();
                        gameManagerscript.AddTime6();

                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "Grandstand"; 
                    }
                }
                
                if(gameManagerscript.currentPassenger == 16)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 6 & gameManagerscript.currentPassenger == 16)
                    {
                        spawnManagerscript.DropOffPoints[15].SetActive(false); //Gate 1 -dropoff despawn
                        print("Gate 1 Dropoff De-Spawned Level 6");
                        spawnManagerscript.PickupPoints[0].SetActive(true); //Rotonda-pickup spawn
                        print("Gate 1 Pickup Spawned Level 6");

                        gameManagerscript.AddLRCoinsFinalPassenger();
                        gameManagerscript.AddTime6();

                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(true);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = true;
                        PickUpPoint.text = "Gate 1 Rotonda"; 
                    }
                }

                if(gameManagerscript.currentPassenger == 17)
                {
                    if(droppedoff == true & gameManagerscript.currentlevel == 6 & gameManagerscript.currentPassenger == 17)
                    {
                      
                        //spawnManagerscript.despawn(); //HAYS NAKA COMMENT WAG MO KALIMUTAN TANGGALIN ANG COMMENT

                        //spawnManagerscript.despawn();

                        //despawnManagerscript.CheckTag();
                        //despawnManagerscript.CheckTag1();
                        
                        print("Current Passenger" + gameManagerscript.currentPassenger);

                        gameManagerscript.AddLRCoinsFinalPassenger();
                        gameManagerscript.AddTime6();
                        print("FINAL LEVEL TO");
                        
                        DropOffPointlbl.SetActive(false);
                        PickUpPointlbl.SetActive(false);
                        DropOffPoint.enabled = false;
                        PickUpPoint.enabled = false;
                        
                    }
                }
            }
    }
}
