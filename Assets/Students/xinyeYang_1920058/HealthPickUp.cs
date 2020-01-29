using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : Pickup
{
    public float health = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPickup()
    {
        base.OnPickup();
        FindObjectOfType<BallHealth>().AddHealth(health);
    }

}
