using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRotation : MonoBehaviour
{
    private Rigidbody2D rb;

    public float rotationSpeed = 100f;  // Rotation speed in degrees per second

    void Start()
    {
        // Get the Rigidbody2D component attached to the object
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Add angular velocity for rotation while falling
        // The `rotationSpeed` value controls the speed of the rotation
        rb.angularVelocity = rotationSpeed;
    }
}
