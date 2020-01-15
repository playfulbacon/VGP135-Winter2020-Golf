using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public string levelSelectSceneName;
    public GameObject pauseMenuHolder;
    public GameObject pauseButtonHolder;
    public bool isPaused = false;

    private void Awake()
    {
        SetPauseMenu(false);
    }

    public void OnPause()
    {
        SetPauseMenu(true);
        Time.timeScale = 0.0f;
    }

    public void OnContinue()
    {
        SetPauseMenu(false);
        Time.timeScale = 1.0f;
    }

    public void SetPauseMenu(bool value)
    {
        isPaused = value;
        pauseMenuHolder.SetActive(value);
        pauseButtonHolder.SetActive(!value);

        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
            ball.enabled = !value;
    }

    public void ReplayBtnMenu() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void OnLevelSelect()
    {
        SceneManager.LoadScene(levelSelectSceneName);
    }
}
