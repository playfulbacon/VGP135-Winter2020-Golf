using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupExample : Pickup
{
    GameObject Obstacle;
    void Start()
    {
        
    }

    void Update()
    {

    }

    public override void OnPickup(Ball ball)
    {
        base.OnPickup(ball);
        print("pickup example");
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Obstacle = GameObject.FindGameObjectWithTag("obstacles");
            Obstacle.SetActive(false);
        }
    }

}
