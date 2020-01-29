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

    public virtual void OnPickup()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponentInParent<Ball>();
        if (ball)
        {
            OnPickup();
            Destroy(gameObject);
        }
    }
}
