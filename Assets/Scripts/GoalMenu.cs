﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalMenu : MonoBehaviour
{
    [SerializeField]
    Button playAgainButton;

    [SerializeField]
    Button mainmenuButton;
    public GameObject goalMenuHolder;

    void Start()
    {
        SetGoalMenu(false);

        playAgainButton.onClick.AddListener(PlayAgainButtonDown);
        mainmenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    public void SetGoalMenu(bool value)
    {
        goalMenuHolder.SetActive(value);
    }

    public void PlayAgainButtonDown()
    {
      
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
