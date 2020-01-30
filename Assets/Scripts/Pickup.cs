using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField]
    ParticleSystem pickupParticles;

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

            if (pickupParticles != null)
                Instantiate(pickupParticles, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
