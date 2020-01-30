using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    int par = 3;

    [SerializeField]
    Text parText;

    private void Awake()
    {
       BallHealth[] ballHealths = FindObjectsOfType<BallHealth>();
        foreach (BallHealth ballHealth in ballHealths)
        {
            ballHealth.OnDeath += BallDeath;
        }

        parText.text = "PAR " + par.ToString();
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
