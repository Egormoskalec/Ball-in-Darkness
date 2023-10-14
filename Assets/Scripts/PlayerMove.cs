using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Transform CameraCenter;
    public float TorqueValue;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = 500f;
    }

    void Update()
    {
        _rigidbody.AddTorque(CameraCenter.right * Input.GetAxis("Vertical") * TorqueValue);
        _rigidbody.AddTorque(-CameraCenter.forward * Input.GetAxis("Horizontal") * TorqueValue);
    }
}
