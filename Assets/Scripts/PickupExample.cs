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

    public override void OnPickup()
    {
        base.OnPickup();
        print("pickup example");
    }
    public void OnCollisionEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Obstacle = GameObject.FindGameObjectWithTag("obstacles");
            Obstacle.SetActive(false);
        }
    }

}
