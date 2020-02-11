using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitCounterUI : MonoBehaviour
{

    [SerializeField]
    UnityEngine.UI.Text hitCounterText;

    private void Awake()
    {
        FindObjectOfType<HitCounter>().OnSetHits += SetHitCounter;
        SetHitCounter(0);
    }

    void SetHitCounter(int hits)
    {
        hitCounterText.text = hits.ToString();   
    }

}
