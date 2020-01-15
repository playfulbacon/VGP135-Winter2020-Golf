using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesUI : MonoBehaviour
{
    public Text coinsText;

    private void Awake()
    {
        CollectableManager.instance.OnSetCoins += OnSetCoins;
    }

    void OnSetCoins(int num)
    {
        coinsText.text = num.ToString();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
