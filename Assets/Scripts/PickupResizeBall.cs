using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChangeSize
{
    Increase,
    Decrease
}

public class PickupResizeBall : Pickup
{
    public ChangeSize changeSize;
    public int sizeMultiplier;

    void Start()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (changeSize == ChangeSize.Increase)
        {
            other.transform.localScale *= sizeMultiplier;
        }
        else if (changeSize == ChangeSize.Decrease)
        {
            other.transform.localScale /= sizeMultiplier;
        }

        Destroy(gameObject);
    }
}
