using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class LevelManager : MonoBehaviour
{
    public enum Score
    {
        [Description("Albatross")]
        Albatross = -3,
        [Description("Eagle")]
        Eagle = -2,
        [Description("Birdie")]
        Birdie = -1,
        [Description("Par")]
        Par = 0,
        [Description("Bogie")]
        Bogie = 1,
        [Description("Double Bogie")]
        DoubleBogie = 2,
        [Description("Triple Bogie")]
        TripleBogie = 3,
    }

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
        FindObjectOfType<GameOverMenu>().SetGameOverMenu(true);
    }  

    public void GoToNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex < SceneManager.sceneCountInBuildSettings)
            sceneIndex++;
        else
            sceneIndex = SceneManager.GetSceneByName(defaultSceneName).buildIndex;

        SceneManager.LoadScene(sceneIndex);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public Score GetScore()
    {
        return (Score)FindObjectOfType<HitCounter>().Hits - FindObjectOfType<Level>().levelData.par;
    }
}
