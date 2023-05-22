using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeColor : MonoBehaviour
{
    public Color[] bodycolors;
    public Material bodyMat;

    public GameObject NotEnoughLRCoins;
    public GameObject ColorBought;
    public CustomizationScript customizationScript;

    int money;
    private int selectedColorIndex = -1;
    private List<int> boughtColorIndices = new List<int>(); // List to store the bought color indices

    public float duration = 3f;

    private Color previousColor; // Variable to store the previous color

    GameManager GamemanagerScript;

    private void Awake()
    {
        
        //Remove Bought Colors (For Testing Only)
        //RemoveBoughtColorIndices();

        ApplyDefaultColor();
        // Load the bought color indices from PlayerPrefs
        string boughtColorIndicesString = PlayerPrefs.GetString("BoughtColorIndices");
        if (!string.IsNullOrEmpty(boughtColorIndicesString))
        {
            string[] indicesArray = boughtColorIndicesString.Split(',');
            for (int i = 0; i < indicesArray.Length; i++)
            {
                int index;
                if (int.TryParse(indicesArray[i], out index))
                {
                    boughtColorIndices.Add(index);
                }
            }
        }
    }

    private void OnDestroy()
    {
        // Save the bought color indices to PlayerPrefs
        string boughtColorIndicesString = string.Join(",", boughtColorIndices);
        PlayerPrefs.SetString("BoughtColorIndices", boughtColorIndicesString);
        PlayerPrefs.Save();
    }

    public void RemoveBoughtColorIndices()
    {
        PlayerPrefs.DeleteKey("BoughtColorIndices");
        PlayerPrefs.Save();
    }

    public void ChangeBodyColor(int colorIndex)
    {
    money = PlayerPrefs.GetInt("CustomizationLRCoins");
    // Check if the chosen color is already applied to the bodyMat
    if (boughtColorIndices.Contains(colorIndex))
    {
        bodyMat.color = bodycolors[colorIndex];
        Debug.Log("Color has already been bought and applied");
    }
    
    if (selectedColorIndex != colorIndex)
    {
        previousColor = bodyMat.color;
        selectedColorIndex = colorIndex; // Store the selected color for preview purposes only
        // bodyMat.color = bodycolors[colorIndex];
    }
    else
    {
        Debug.Log("Color is already chosen by the player");
    }
    }

    public void BuyColor(int colorIndex)
    {
       if(money >= 1000 && !boughtColorIndices.Contains(colorIndex))
       {
            StartCoroutine(ColorAlreadyBought(ColorBought));
            money -= 1000;
            bodyMat.color = bodycolors[colorIndex];
            
            
            Debug.Log("Color bought and applied!");
            
            PlayerPrefs.SetInt("CustomizationLRCoins",money);

            customizationScript.customizeLRCoinsText.text = money + "LR Coins";

            customizationScript.customizeLRCoins = PlayerPrefs.GetInt("CustomizationLRCoins");

            // Set the flag to indicate color selection and application
            boughtColorIndices.Add(colorIndex); // Add the bought color index to the list
       } 

         if (boughtColorIndices.Contains(colorIndex))
        {
            Debug.Log("Color has already been bought and applied");
            
        }

        else
        {

            Debug.Log("Not enough LR coins to purchase the color.");

            // Revert to the previous color if not enough LR coins
            bodyMat.color = previousColor;
            StartCoroutine(NotEnoughtLR(NotEnoughLRCoins));
            //bodyMat.color = bodycolors[selectedColorIndex];
        }
    }
    public void ApplyColor()
    {
        // Get the current color index from bodyMat.color
        int colorIndex = System.Array.IndexOf(bodycolors, bodyMat.color);
        if (selectedColorIndex != -1)
        {
            //BuyColor(colorIndex);
            BuyColor(selectedColorIndex);
            selectedColorIndex = -1; // Reset the selected color index after applying
        }

        else
        {
            Debug.Log("No color selected");
        }
    }

    public void ApplyDefaultColor()
    {
        int colorIndex = 0;
        bodyMat.color = bodycolors[colorIndex];
        boughtColorIndices.Add(colorIndex);

    }

    private IEnumerator NotEnoughtLR(GameObject NotEnoughLR)
    {
        NotEnoughLR.SetActive(true);
        yield return new WaitForSecondsRealtime(duration);
        
        NotEnoughLR.SetActive(false);

    }

    private IEnumerator ColorAlreadyBought(GameObject ColorBought)
    {
        ColorBought.SetActive(true);
        yield return new WaitForSecondsRealtime(duration);
        
        ColorBought.SetActive(false);

    }
}

