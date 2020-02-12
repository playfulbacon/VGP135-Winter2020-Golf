using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public GameObject GameOverMenuHolder;
    public Button playAgainButton;
    public Button selectLevelButton;
    [SerializeField]
    public bool flag; 

    void Start()
    {
        SetGameOverMenu(false);

        LevelManager levelManager = FindObjectOfType<LevelManager>();
        playAgainButton.onClick.AddListener(levelManager.RestartLevel);
        selectLevelButton.onClick.AddListener(levelManager.SelectLevel);
    }

    public void SetGameOverMenu(bool setActive)
    {
        flag = setActive;
        GameOverMenuHolder.SetActive(setActive);
    }
}
