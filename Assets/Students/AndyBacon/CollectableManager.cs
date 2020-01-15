using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectableManager : MonoBehaviour
{
    public Action<int> OnSetCoins;
    public static CollectableManager collectableManager;
    public static CollectableManager instance
    {
        get
        {
            if (!collectableManager)
            {
                collectableManager = FindObjectOfType(typeof(CollectableManager)) as CollectableManager;

                if (!collectableManager)
                {
                    collectableManager = new GameObject("CollectableManager").AddComponent<CollectableManager>();
                }
            }

            return collectableManager;
        }
    }

    int coins = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SetCoins(0);
    }

    public void CollectCoin(int collect = 1)
    {
        SetCoins(coins + collect);
    }

    void SetCoins(int num)
    {
        coins = num;
        OnSetCoins?.Invoke(coins);
    }
}
