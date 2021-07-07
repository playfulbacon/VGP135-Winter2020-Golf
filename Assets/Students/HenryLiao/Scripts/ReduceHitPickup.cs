using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReduceHitPickup : Pickup
{
    public Action OnReduceHitPickup;
    public override void OnPickup()
    {
        base.OnPickup();
        OnReduceHitPickup?.Invoke();
    }
}
