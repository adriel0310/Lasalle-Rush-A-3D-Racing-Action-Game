using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalLevelDropOff : MonoBehaviour
{
    GameManager gameManagerscript;
    QuestReceiver questReceiverScript;
    public List <GameObject> objectsToDespawn;
    //The unique identifier of the GameObject to despawn
    public string objectId;
    bool allDespawned = true;
    public int buildingtracker;

    [SerializeField] TextMeshProUGUI PickDrop;
   
   void Start()
   {
    gameManagerscript = GameObject.Find("GameManager").GetComponent<GameManager>();
    questReceiverScript = GameObject.Find("QuestReceiver").GetComponent<QuestReceiver>();
   }

   public void trackbuilding()
   {

   }
    public IEnumerator OnTriggerEnter(Collider other)
    {
        if(gameManagerscript.currentPassenger == 17){

        
            if (other.CompareTag("Player"))
            {
                PickDrop.text = "+1 BUILDING";
                PickDrop.enabled = true;
                yield return new WaitForSeconds(2f);
                PickDrop.enabled = false;

                Debug.Log("may delay dapat");
                if(gameManagerscript.currentPassenger == 17){
                    
                    GameObject objectToDespawn = null;
                    foreach (GameObject obj in objectsToDespawn)
                    {
                        if (obj.name == objectId)
                        {
                            objectToDespawn = obj;
                            print(objectToDespawn);
                            break;
                        }
                    }

                    // Deactivate the chosen GameObject
                    if (objectToDespawn != null)
                    {
                        objectToDespawn.SetActive(false);
                    }

                    foreach (GameObject obj in objectsToDespawn)
                    {
                        if (obj.activeSelf)
                        {
                            allDespawned = false;
                        }
                        
                    }
                }
            }
        
        }       
    }

}
