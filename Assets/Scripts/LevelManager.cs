using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Awake()
    {
       BallHealth[] ballHealths = FindObjectsOfType<BallHealth>();
        foreach (BallHealth ballHealth in ballHealths)
        {
            ballHealth.OnDeath += BallDeath;
        }
    }
    
    void BallDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
