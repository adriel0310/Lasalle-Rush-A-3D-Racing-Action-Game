using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeColor : MonoBehaviour
{
    public Color[] bodycolors;
    public Material bodyMat;

    GameManager GamemanagerScript;

    public void ChangeBodyColor(int colorIndex)
    {
        bodyMat.color = bodycolors[colorIndex];
    }
}
