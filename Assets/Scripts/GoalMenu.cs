using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalMenu : MonoBehaviour
{
    public GameObject goalMenuHolder;
    public Button playAgainButton;
    public Button nextLevelButton;
    private LevelManager levelManager;
    int finalScore;

    void Start()
    {
        SetGoalMenu(false);
        FindObjectOfType<HighScoreUI>().isGoalReached = false;
        levelManager = FindObjectOfType<LevelManager>();
        playAgainButton.onClick.AddListener(levelManager.RestartLevel);
        nextLevelButton.onClick.AddListener(levelManager.GoToNextScene);
    }

    public void SetGoalMenu(bool value)
    {
        goalMenuHolder.SetActive(value);
        FindObjectOfType<HighScoreUI>().isGoalReached = true;
    }

    public void SetScoreText()
    {
        if (FindObjectOfType<HitCounter>().Hits == 1)
        {
            goalMenuHolder.GetComponentInChildren<Text>().text = "Hole-In-One";
        }
        else
        {
            if ((int)levelManager.GetScore() > 3)
            {
                goalMenuHolder.GetComponentInChildren<Text>().text = "+" + (int)(levelManager.GetScore()); ;
            }
            else if ((int)levelManager.GetScore() < -3)
            {
                goalMenuHolder.GetComponentInChildren<Text>().text = "-" + (int)(levelManager.GetScore()); ;
            }
            else
            {
                goalMenuHolder.GetComponentInChildren<Text>().text = levelManager.GetScore().ToString();
            }
        }

    }
}
