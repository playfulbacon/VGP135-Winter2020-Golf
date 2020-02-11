using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class HitCounter : MonoBehaviour
{
    public Action<int> OnSetHits;
    public int HitMax=10;
    public Action OnDeath;
    public int Hits { get; private set; }

    private void Awake()
    {
        FindObjectOfType<BallController>().OnHit += Hit;
    }
    void Hit(Vector3 hitDirection)
    {
        SetHits(Hits + 1);
    }
    void SetHits(int set)
    {
        Hits = set;
        OnSetHits?.Invoke(Hits);
        if (Hits >= HitMax)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
