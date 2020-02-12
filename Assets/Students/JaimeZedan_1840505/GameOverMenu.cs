using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public GameObject GameOverMenuHolder;
    public Button playAgainButton;
    public Button selectLevelButton;

    void Start()
    {
        SetGameOverMenu(false);

        LevelManager levelManager = FindObjectOfType<LevelManager>();
        playAgainButton.onClick.AddListener(levelManager.RestartLevel);
        selectLevelButton.onClick.AddListener(levelManager.GoToLevelSelect);
    }

    public void SetGameOverMenu(bool setActive)
    {
        GameOverMenuHolder.SetActive(setActive);
    }
}
