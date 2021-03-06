﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Text highScoreText;

    [SerializeField]
    private int highScore = 100;
    [SerializeField]
    private int currentScore;
    private Scene scene;
    public bool isGoalReached { get; set; }
    private ScoreManager scoreManager;


    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        scoreManager = FindObjectOfType<ScoreManager>();
        Debug.Log(scene.buildIndex.ToString());

        FindObjectOfType<Goal>().OnGoal += SaveScore;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore" + scene.buildIndex.ToString()))
        {
            highScore = PlayerPrefs.GetInt("HighScore" + scene.buildIndex.ToString());
        }
        else
        {
            highScore = 100;
        }
        DisplayHighScore();
    }

    public void DisplayHighScore()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore" + scene.buildIndex.ToString());
    }

    public void SaveScore()
    {
        currentScore = (int)(scoreManager.GetScore());

        if (currentScore < highScore)
        {
            PlayerPrefs.SetInt("HighScore" + scene.buildIndex.ToString(), highScore);
            PlayerPrefs.Save();
        }
    }
}
