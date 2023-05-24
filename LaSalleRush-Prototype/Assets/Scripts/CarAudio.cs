using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    Rigidbody RB;
    public AudioSource EngineSource;

    public AudioClip hornSound;
    public AudioSource HornaudioSource;

    public int GearShiftLength;
    public float PitchBoost;
    public float PitchRange;

    public float time;

//Private Variables
    float Temp1;
    int Temp2;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        HornaudioSource.clip = hornSound;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            HornaudioSource.PlayOneShot(hornSound);
        }
        
        float Speed = RB.velocity.magnitude;
        Temp1 = Speed / GearShiftLength;
        Temp2 = (int) Temp1;

        float Difference = Temp1 - Temp2;

        EngineSource.pitch = Mathf.Lerp(EngineSource.pitch, PitchBoost + (PitchRange * Difference), time);
    }

    

}
