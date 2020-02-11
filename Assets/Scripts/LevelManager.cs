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
        FindObjectOfType<GameOverMenu>()?.SetGameOverMenu(true);
    }

    public void GoToNextScene()
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

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    static public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
