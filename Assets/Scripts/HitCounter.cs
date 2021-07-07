using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitCounter : MonoBehaviour
{
    public Action<int> OnSetHits;
    public int Hits { get; private set; }

    private void Awake()
    {
        FindObjectOfType<BallController>().OnHit += Hit;
        ReduceHitPickup[] reduceHitPickups = FindObjectsOfType<ReduceHitPickup>();
        foreach (ReduceHitPickup pickup in reduceHitPickups)
        {
            pickup.OnReduceHitPickup += ReduceHit;
        }
    }

    void Start()
    {
        
    }

    void Hit(Vector3 hitDirection)
    {
        SetHits(Hits + 1);
    }

    void ReduceHit()
    {
        if (Hits > 0)
        {
            SetHits(Hits - 1);
        }
    }

    void SetHits(int set)
    {
        Hits = set;
        OnSetHits?.Invoke(Hits);
    }
}
