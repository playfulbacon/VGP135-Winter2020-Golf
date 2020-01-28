﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChangeSize
{
    Increase,
    Decrease
}

public class PowerUp : MonoBehaviour
{
    GameObject powerUp;
    GameObject powerModel;
    public ChangeSize changeSize;
    public int sizeMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        powerUp = this.gameObject;
        powerModel = this.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //powerModel.transform.rotation *= 25f;
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

        Destroy(powerUp);
    }
}
