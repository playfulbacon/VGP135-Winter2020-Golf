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
    private bool pauseOpen;
    private Text goalMessage;

    void Start()
    {
        SetGoalMenu(false);
        pauseOpen = false;
        goalMessage = goalMenuHolder.GetComponentInChildren<Text>();

        levelManager = FindObjectOfType<LevelManager>();
        playAgainButton.onClick.AddListener(levelManager.RestartLevel);
        nextLevelButton.onClick.AddListener(levelManager.GoToNextScene);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseOpen)
        {
            goalMessage.gameObject.SetActive(false);
            nextLevelButton.gameObject.SetActive(false);
            SetGoalMenu(true);
            pauseOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseOpen)
        {
            goalMessage.gameObject.SetActive(true);
            nextLevelButton.gameObject.SetActive(true);
            SetGoalMenu(false);
            pauseOpen = false;
        }
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
