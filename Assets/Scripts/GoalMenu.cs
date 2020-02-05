using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GoalMenu : MonoBehaviour
{
    public GameObject PlayAgainButton;
    public GameObject NextLevelButton;
    public string levelSelectSceneName;
    public GameObject goalMenuHolder;

    void Start()
    {
        SetGoalMenu(false);
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        PlayAgainButton.onClick.AddListener(levelManager.RestartLevel);
        NextLevelButton.onClick.AddListener(levelManager.GoToNextLevel);
    }

    public void SetGoalMenu(bool value)
    {
        goalMenuHolder.SetActive(value);
    }

    public void PlayAgainButtonDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(levelSelectSceneName);
    }
}
