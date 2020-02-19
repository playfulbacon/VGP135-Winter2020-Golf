using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCounterUI : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Text hitCounterText;

    private void Awake()
    {
        FindObjectOfType<HitCounter>().OnSetHits += SetHitCounter;
        SetHitCounter(0);
    }

    void Start()
    {
        
    }

    void SetHitCounter(int hits)
    {
        hitCounterText.text = hits.ToString();
    }
}
