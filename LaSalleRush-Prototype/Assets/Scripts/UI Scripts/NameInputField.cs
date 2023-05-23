using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

public class NameInputField : MonoBehaviour
{
    public TMP_InputField nameInputField;

    void Start()
    {
        // Limit the number of characters that can be entered
        nameInputField.characterLimit = 10;

        // Add a listener to the onValidateInput event
        nameInputField.onValidateInput += ValidateInput;
    }

    char ValidateInput(string text, int charIndex, char addedChar)
    {
        // Allow only letters and spaces
        if (!Regex.IsMatch(addedChar.ToString(), @"^[a-zA-Z\s]*$"))
        {
            return '\0'; // Reject the input
        }
      
        return addedChar; // Accept the input
    }
}
