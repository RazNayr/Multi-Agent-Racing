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

    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;

    private void Start()
    {
        Rigidbody carRigidbody = GetComponent<Rigidbody>();
        carRigidbody.velocity = new Vector3(0, 0, -30);
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
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
}
