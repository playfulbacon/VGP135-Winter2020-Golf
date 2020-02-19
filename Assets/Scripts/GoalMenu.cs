﻿using System;
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
    private LevelSelect levelSelect;

    void Start()
    {
        SetGoalMenu(false);

        levelManager = FindObjectOfType<LevelManager>();
        levelSelect = FindObjectOfType<LevelSelect>();
    }

    public void SetGoalMenu(bool value)
    {
        goalMenuHolder.SetActive(value);
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
                goalMenuHolder.GetComponentInChildren<Text>().text = "+" + ((int)(levelManager.GetScore())).ToString();
            }
            else if ((int)levelManager.GetScore() < -3)
            {
                goalMenuHolder.GetComponentInChildren<Text>().text = "-" + ((int)(levelManager.GetScore())).ToString();
            }
            else
            {
                goalMenuHolder.GetComponentInChildren<Text>().text = levelManager.GetScore().ToString();
            }
        }
    }
}
