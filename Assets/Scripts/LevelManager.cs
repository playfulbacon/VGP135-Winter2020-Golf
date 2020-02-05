using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string defaultSceneName = "MainMenu";

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
        RestartLevel();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            sceneIndex++;
        }
        else
        {
            sceneIndex = SceneManager.GetSceneByName(defaultSceneName).buildIndex;
        }
        SceneManager.LoadScene(sceneIndex);
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
