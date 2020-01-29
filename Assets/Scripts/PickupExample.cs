using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupExample : Pickup
{
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
}
