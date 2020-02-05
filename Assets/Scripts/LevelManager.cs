using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string defaultSceneName = "balabla";
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

    internal static void LoadScene(string sceneName)
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        
    }

    public void baba()
    {
        int sceneindex = SceneManager.GetActiveScene().buildIndex;

        if (sceneindex < SceneManager.sceneCountInBuildSettings)
            sceneindex++;
        else
            sceneindex = SceneManager.GetSceneByName(defaultSceneName);

        SceneManager.LoadScene(sceneindex);
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToNextLevel()
    {

    }

}
