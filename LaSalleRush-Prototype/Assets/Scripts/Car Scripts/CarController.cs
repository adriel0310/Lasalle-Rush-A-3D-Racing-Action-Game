using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float lookSensitivity = 2.0f; // Mouse sensitivity for looking around
    public float lookSmoothness = 1.0f; // Smoothing factor for camera movement

    private Vector2 currentRotation; // Current camera rotation (in degrees)
    private Vector2 smoothRotation; // Smoothed camera rotation (in degrees)
    private Vector2 lookDelta; // Change in mouse position since last frame


    public enum Axel
    {
        Front,
        Rear
    }
     [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    private Rigidbody carRB;

    private void Start()
    {
        carRB = GetComponent<Rigidbody>();
        carRB.centerOfMass = _centerOfMass;
    }

    void Update()
    {
        GetInputs();
        //AnimateWheels();

        if (Input.GetMouseButton(1)) // If right mouse button is held down
        {
            // Get the change in mouse position since last frame
            lookDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            // Scale the change in mouse position by the look sensitivity
            lookDelta *= lookSensitivity;

            // Add the scaled change in mouse position to the current rotation
            currentRotation += lookDelta;

            // Clamp the rotation to prevent looking too far up or down
            currentRotation.y = Mathf.Clamp(currentRotation.y, -90.0f, 90.0f);

            // Smooth the camera rotation
            smoothRotation = Vector2.Lerp(smoothRotation, currentRotation, lookSmoothness * Time.deltaTime);

            // Apply the smoothed rotation to the camera transform
            transform.localRotation = Quaternion.Euler(-smoothRotation.y, smoothRotation.x, 0.0f);
        }
        
    }

    private void LateUpdate()
    {
        Move();
        Steer();
       
    }
    void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    void Move()
    {
        foreach(var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * 600 * maxAcceleration * Time.deltaTime;
        }
    }

    void Steer()
    {
        foreach(var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }


    void RotateWheels()
    {
       foreach(var wheel in wheels)
        {
            wheel.wheelModel.transform.Rotate(60 * 360 *Time.deltaTime,0,0);
        }
    }

    void AnimateWheels()
    {
        foreach(var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos; 
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }
}
