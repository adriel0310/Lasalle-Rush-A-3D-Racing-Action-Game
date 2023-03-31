using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnManager : MonoBehaviour
{
    public List<GameObject> DropOffPoints;
    public void CheckTag(){
        
        GameObject gate1 = GameObject.Find("Gate 1 (Dropoff)");
        if (gate1)
        {
             gate1.SetActive(false);
        }

        GameObject pch = GameObject.Find("PCH");
        if (pch)
        {
            pch.SetActive(false);
        }

        //foreach(GameObject dropoffpoint in DropOffPoints){
            //if (GameObject.FindGameObjectWithTag("Chapel"))
            //{
                //dropoffpoint.SetActive(false);
               // GameObject.FindGameObjectWithTag("Chapel").SetActive(false);
           // }
            
           // else if (GameObject.FindGameObjectWithTag("ICTC")){
                //dropoffpoint.SetActive(false);
           // }

           // else if (GameObject.FindGameObjectWithTag("Square")){
                //dropoffpoint.SetActive(false);
           // }

            //else if (dropoffpoint.tag == "Severino De Las Alas Hall"){
                //dropoffpoint.SetActive(false);
            //}

            //else if (dropoffpoint.tag == "Gregoria Montoya Hall"){
                //dropoffpoint.SetActive(false);
            //}

           // else if (dropoffpoint.tag == "Ayuntamiento"){
                //dropoffpoint.SetActive(false);
            //}

            //else if (dropoffpoint.tag == "Clothing Warehouse"){
                //dropoffpoint.SetActive(false);
            //}

           // else if (dropoffpoint.tag == "ULS(Dropoff)"){
                //dropoffpoint.SetActive(false);
           //}

            //else if (dropoffpoint.tag == "Museo De La Salle"){
                //dropoffpoint.SetActive(false);
           // }

           // else if (dropoffpoint.tag == "Gate 3"){
                //dropoffpoint.SetActive(false);
           // }

            //if (GameObject.Find("PCH")){
              //  Debug.Log("PCH");
                //GameObject.Find("PCH").SetActive(false);
            //}


            //else if (dropoffpoint.tag == "RCC"){
                //dropoffpoint.SetActive(false);
           // }

            //else if (dropoffpoint.tag == "Mila's Diner"){
                //dropoffpoint.SetActive(false);
            //}

            //else if (dropoffpoint.tag == "Gate 2"){
                //dropoffpoint.SetActive(false);
           // }   

           // else if (dropoffpoint.tag == "Grandstand"){
                //dropoffpoint.SetActive(false);
            //}

           // if (GameObject.Find("Gate 1 (Dropoff)")){
             //   Debug.Log("Gate 1");
               // GameObject.Find("Gate 1 (Dropoff)").SetActive(false);
            //}

        //}
    }

}
    

