using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    public virtual void OnPickup(Ball ball)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponentInParent<Ball>();
        if (ball)
        {
            OnPickup(ball);
            Destroy(gameObject);
        }
    }
}
