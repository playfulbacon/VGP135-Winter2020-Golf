using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    public float launchSpeed = 10.0f;
    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponentInParent<Ball>();
        if (ball)
        {
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.velocity += new Vector3(0.0f, launchSpeed, 0.0f);
        }
    }
}
