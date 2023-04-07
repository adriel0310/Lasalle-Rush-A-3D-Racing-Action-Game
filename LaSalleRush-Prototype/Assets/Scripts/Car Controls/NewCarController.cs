using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private float horizontalInput;
    public float verticalInput;
    private float steerAngle;
    private float currentbreakForce;
    private float removebreakForce;
    private bool isBreaking;
    private bool removeBreak;
    public float maxSpeed = 25f; //Speed Limiter

    //public ParticleSystem pickupEffect;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    public Rigidbody carRB;
    
    public Vector3 _centerOfMass;

    private void Start()
    {
        carRB = GetComponent<Rigidbody>();
        carRB.centerOfMass = _centerOfMass;
    }
    private void FixedUpdate()
    {
        GetInputs();
        HandleMotor(); //For the wheels
        HandleSteering(); //Steer the wheels
        UpdateWheels();
    }

    private void GetInputs()

    {
        horizontalInput = Input.GetAxis(HORIZONTAL);

        //Forward Acceleration Input with Max Speed Limiter
        if(carRB.velocity.magnitude <= maxSpeed)
        {
        verticalInput = Input.GetAxisRaw(VERTICAL);
        }
        else
        {
        verticalInput =  -1f;
        }
  
    }

    private void HandleMotor()
    {           
        rearLeftWheelCollider.motorTorque = verticalInput * motorForce;
        rearRightWheelCollider.motorTorque = verticalInput * motorForce;

        var directionCheck = transform.InverseTransformDirection(carRB.velocity);
        //Debug.Log(directionCheck);

        if(directionCheck.z > 0 && verticalInput == -1)
        {
            ApplyBreaking();
            //Debug.Log("PREEEEEENOOOOOOOO");
        }

        else if(directionCheck.z < 0 && verticalInput == -1 || verticalInput == 1 || verticalInput == 0)
        {
            RemoveBreaking();
            //Debug.Log("ATRAAAAAAAAASSSSSSSSSS");
        } 
    }
    private void ApplyBreaking()
    {
        currentbreakForce = 200 * breakForce * Time.deltaTime;  
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce; 
    }

    private void RemoveBreaking()
    {
        currentbreakForce = 0;
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }


    
    private void HandleSteering()  
    {
        var currentSteerAngle = maxSteerAngle *horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider,frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider,frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider,rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider,rearLeftWheelTransform);
    }
    private void UpdateSingleWheel(WheelCollider wheelCollider,Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos , out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    public void Interact()
    {
        Input.GetKeyDown("f");
    }

   
}
