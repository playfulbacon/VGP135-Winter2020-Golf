using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : MonoBehaviour
{
    public float healthToAdd = 10.0f;

    public void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponentInParent<Ball>();
        if (ball)
        {
            ball.GetComponent<BallHealth>().AddHealth(healthToAdd);
            Destroy(gameObject);
        }
    }
}
