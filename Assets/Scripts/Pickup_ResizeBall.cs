﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChangeSize
{
    Increase,
    Decrease
}

public class Pickup_ResizeBall : Pickup
{
    public ChangeSize changeSize;
    public int sizeMultiplier;

    void Start()
    {
        
    }

    public override void OnPickup(Ball ball)
    {
        base.OnPickup(ball);
        
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        if (changeSize == ChangeSize.Increase)
        {
            ball.transform.localScale *= sizeMultiplier;
            rb.mass *= sizeMultiplier;
        }
        else if (changeSize == ChangeSize.Decrease)
        {
            ball.transform.localScale /= sizeMultiplier;
            rb.mass /= sizeMultiplier;
        }
    }
}
