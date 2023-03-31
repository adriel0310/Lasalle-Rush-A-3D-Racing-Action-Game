using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelDropOff : MonoBehaviour
{
    GameManager gameManagerscript;
    QuestReceiver questReceiverScript;
    public List <GameObject> objectsToDespawn;
    //The unique identifier of the GameObject to despawn
    public string objectId;
   
   void Start()
   {
    gameManagerscript = GameObject.Find("GameManager").GetComponent<GameManager>();
    questReceiverScript = GameObject.Find("QuestReceiver").GetComponent<QuestReceiver>();
   }
    private void OnTriggerEnter(Collider other)
    {

            if (other.CompareTag("Player"))
            {
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
            }
        }       
    }
}
