using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallHitManager : MonoBehaviour
{
    [SerializeField]
    Text hitCounterUI;
    int hit = 0;

    private void Awake()
    {
        GetComponent<Ball>().OnHit += Hit;    
    }

    void Start()
    {
        hitCounterUI.text = "Hit:" + hit.ToString();
    }

    public void Hit()
    {
        SetHit(hit + 1);
    }

    public void ReduceHit()
    {
        SetHit(hit - 1);
    }

    public void SetHit(int set)
    {
        hit = (int)Mathf.Clamp(set, 0, float.MaxValue);
        hitCounterUI.text = "Hit:" + hit.ToString();
    }
}
