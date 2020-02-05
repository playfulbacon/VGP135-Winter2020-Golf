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

    void Start()
    {
        SetGoalMenu(false);

        LevelManager levelManager = FindObjectOfType<LevelManager>();
        playAgainButton.onClick.AddListener(levelManager.RestartLevel);
        nextLevelButton.onClick.AddListener(levelManager.GoToNextLevel);
    }

    public void SetGoalMenu(bool value)
    {
        goalMenuHolder.SetActive(value);
    }
}
