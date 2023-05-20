using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
      public GameObject[] powerUpObjects;
      Spinner spinnerScript;

    void Start()
    {
        spinnerScript = GameObject.Find("Spinner").GetComponent<Spinner>();
        DeactivatePowerUps();
    }

    public void ActivatePowerUps()
    {
        foreach (GameObject powerUp in powerUpObjects)
        {
            if (!powerUp.activeSelf)
            {
                powerUp.SetActive(true);
            }
        }
    }

    public void DeactivatePowerUps()
    {
        foreach (GameObject powerUp in powerUpObjects)
        {
            if (powerUp.activeSelf)
            {
                powerUp.SetActive(false);
            }
        }
    }

}
