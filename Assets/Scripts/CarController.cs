using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Wheel Colliders")]
    public WheelCollider wheelFrontRight;
    public WheelCollider wheelFrontLeft;
    public WheelCollider wheelRearRight;
    public WheelCollider wheelRearLeft;

    [Header("Wheel Transforms")]
    public Transform transformWheelFrontRight;
    public Transform  transformWheelFrontLeft;
    public Transform transformWheelRearRight;
    public Transform transformWheelRearLeft;

    [Header("Car Properties")]
    public float maxSteerAngle = 30;
    public float speed = 50;

    float horizontalInput;
    float verticalInput;
    float steerAngle;

    bool startedRace = false;
    int currentLap = 0;
    float laptime = 0f;
    bool toppledOver = false;
    bool hitBorder = false;

    LapManager lapManager;

    private void Start()
    {
        lapManager = GameObject.Find("Lap Manager").GetComponent<LapManager>();
        Rigidbody carRigidbody = GetComponent<Rigidbody>();
        carRigidbody.velocity = new Vector3(0, 0, -30);
    }

    private void Update()
    {
        if (!toppledOver && !hitBorder)
        {
            UpdateLapTime();
            CheckIfToppledOver();
        }
    }

    private void UpdateLapTime()
    {
        if (startedRace)
            laptime += Time.deltaTime;
    }

    private void CheckIfToppledOver()
    {
        if(Vector3.Angle(transform.up, Vector3.up) > 75)
        {
            toppledOver = true;
        }
    }

    private void FixedUpdate()
    {
        if(!toppledOver && !hitBorder)
        {
            GetInput();
            Steer();
            Accelerate();
            UpdateWheelPoses();
        }
        
    }

    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        steerAngle = maxSteerAngle * horizontalInput;
        wheelFrontLeft.steerAngle = steerAngle;
        wheelFrontRight.steerAngle = steerAngle;
    }

    private void Accelerate()
    {
        wheelFrontLeft.motorTorque = verticalInput * speed;
        wheelFrontRight.motorTorque = verticalInput * speed;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(wheelFrontLeft, transformWheelFrontLeft);
        UpdateWheelPose(wheelFrontRight, transformWheelFrontRight);
        UpdateWheelPose(wheelRearLeft, transformWheelRearLeft);
        UpdateWheelPose(wheelRearRight, transformWheelRearRight);
    }

    private void UpdateWheelPose(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 newWheelPosition;
        Quaternion newWheelRotation;

        wheelCollider.GetWorldPose(out newWheelPosition, out newWheelRotation);

        wheelTransform.position = newWheelPosition;
        wheelTransform.rotation = newWheelRotation;

    }

    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "StartingLine")
        {
            if (!startedRace)
            {
                startedRace = true;
            }
            else
            {
                currentLap++;
                lapManager.UpdateCarLapTimes(gameObject.name, laptime);
                laptime = 0;
                
                if (currentLap == lapManager.numberOfLaps)
                    Destroy(this.gameObject);
            }
            
        }

    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Border")
        {
            hitBorder = true;
        }
    }
}
