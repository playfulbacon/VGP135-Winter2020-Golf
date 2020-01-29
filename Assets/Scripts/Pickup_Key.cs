using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Key : Pickup
{
    [SerializeField]
    GameObject wall;

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
        // turn off the wall
        wall.SetActive(false);
    }
}
