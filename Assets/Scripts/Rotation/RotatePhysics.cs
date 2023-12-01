using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RotatePhysics : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float strength = 100;
    [SerializeField] private float rotationX, rotationY;
    private bool applyForce;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            applyForce = true;
            rotationX = Input.GetAxis("Mouse X") * strength;
            rotationY = Input.GetAxis("Mouse Y") * strength;
        }
        else
        {
            applyForce = false;
        }

    }

    private void FixedUpdate()
    {
        if (applyForce)
        {
            rb.AddTorque(rotationX,-rotationY,0);
        }
    }
}
