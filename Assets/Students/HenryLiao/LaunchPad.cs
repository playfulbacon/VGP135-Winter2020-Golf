using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    public float launchSpeed = 10.0f;
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody ball = other.GetComponentInParent<Rigidbody>();
        if (ball.name == "Ball")
        {
            ball.velocity += new Vector3(0.0f, launchSpeed, 0.0f);
        }
    }
}
