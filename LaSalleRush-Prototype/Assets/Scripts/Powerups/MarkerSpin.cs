using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerSpin : MonoBehaviour
{
    public float spinSpeed = 80f;
    public float floatHeight = 0.5f;
    public float minFloatHeight = 0f;
    public float floatSpeed = 4f;
    public float floatAmplitude = 0.2f;

    void Start()
    {
        floatHeight += transform.position.y; // Add the current Y position to the floatHeight variable
        StartCoroutine(SpinAndFloat());
    }

    IEnumerator SpinAndFloat()
    {
        while (true)
        {
            // Spin the object around its Y-axis
            transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);

            // Move the object up and down
            float newY = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude + floatHeight;

            // Apply minimum float height
            if (newY < minFloatHeight) {
                newY = minFloatHeight;
            }
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            yield return null;
        }
    }
}
