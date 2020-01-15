using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void Start()
    {
        
    }

    public void OnCollect()
    {
        CollectableManager.instance.CollectCoin();
        Destroy(gameObject);
    }
}
