using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject[] tutorial;
    public GameObject[] keys;
    public GameObject tutorialButton;

    int currentTutorialIndex = 0;

    public void StartTutorial()
    {
        if (tutorialButton.activeSelf)
        {
            StartCoroutine(ShowNextTutorial(2f));
            Debug.Log("access sa tutorial script");
            
            StartCoroutine(StartTutorialCoroutine());
            Debug.Log("nagstart tutorial coroutine");
        }
        else
        {
            StartCoroutine(StartTutorialCoroutine());
        }
    }

    public IEnumerator StartTutorialCoroutine()
    {
        Debug.Log("access start tutorial");
        yield return new WaitUntil(() => !tutorialButton.activeSelf);

        StartCoroutine(ShowNextTutorial(2f));
        //Debug.Log("access start tutorial");
    }

    public IEnumerator ShowNextTutorial(float delay)
    {
        Debug.Log("ShowNextTutorial");
        if (currentTutorialIndex < tutorial.Length)
        {
            Debug.Log(currentTutorialIndex);
            tutorial[currentTutorialIndex].SetActive(true);

            if (currentTutorialIndex == 0 && keys.Length > 0)
            {
                yield return new WaitForSeconds(delay); // Wait for the specified delay
                keys[0].SetActive(true); // Show the first key after the delay
                Debug.Log("First key is active");
            }

            if (currentTutorialIndex == tutorial.Length - 1 && keys.Length > 1)
            {
                keys[1].SetActive(true); // Show the second key on the final tutorial
                Debug.Log("Second key is active");
            }
        }
    }


}
