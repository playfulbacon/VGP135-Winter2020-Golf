using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalMenu : MonoBehaviour
{
    public GameObject goalMenuHolder;


    void Start()
    {
        SetGoalMenu(false);
    }

    public void SetGoalMenu(bool value)
    {
        goalMenuHolder.SetActive(value);
    }

    public void PlayAgainButtonDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelectButtonDown(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}
