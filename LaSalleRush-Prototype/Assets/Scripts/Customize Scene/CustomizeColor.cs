using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeColor : MonoBehaviour
{
    public Color[] bodycolors;
    public Material bodyMat;
    public CustomizationScript customizationScript;

    int money;

     private Color previousColor; // Variable to store the previous color

    GameManager GamemanagerScript;

    public void ChangeBodyColor(int colorIndex)
    {
        money = PlayerPrefs.GetInt("CustomizationLRCoins");
            // Check if the chosen color is already applied to the bodyMat
            if (bodyMat.color != bodycolors[colorIndex])
            {
                previousColor = bodyMat.color;
                bodyMat.color = bodycolors[colorIndex];
            }
            else
            {
                Debug.Log("Color is already chosen by the player");
            }
             //bodyMat.color = bodycolors[colorIndex];   
    }

    public void BuyColor(int colorIndex)
    {
       if(money >= 50)
       {
            money -= 50;
            bodyMat.color = bodycolors[colorIndex];
            Debug.Log("Color bought and applied!");
            PlayerPrefs.SetInt("CustomizationLRCoins",money);

            customizationScript.customizeLRCoinsText.text = money + "LR Coins";

            customizationScript.customizeLRCoins = PlayerPrefs.GetInt("CustomizationLRCoins");
       } 

        else
        {
            Debug.Log("Not enough LR coins to purchase the color.");

            // Revert to the previous color if not enough LR coins
            bodyMat.color = previousColor;
        }

    }
}
