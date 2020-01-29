using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Pickup
{
    public float multiplier = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPickup(Ball ball)
    {
        //Passes in speed multiplier onto the current force and max force of the ball increasing speed
        ball.SetSpeedMultiplier(multiplier);
    }
}
