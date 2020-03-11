using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public LevelSelectButton levelSelectButton;
    public LevelData[] levels;
    public LevelData selectedLevel;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        foreach(LevelData levelData in levels)
        {
            LevelSelectButton button = Instantiate(levelSelectButton, levelSelectButton.transform.parent);
            button.levelImage.sprite = levelData.levelimage;
            button.levelNameText.text = levelData.uiName;
            button.difficultyText.text = levelData.difficulty.ToString();

            button.GetComponent<Button>().onClick.AddListener(delegate { SelectLevel(levelData); });
        }

        levelSelectButton.gameObject.SetActive(false);
    }

    void SelectLevel(LevelData levelData)
    {
        selectedLevel = levelData;
        LevelManager.LoadScene(levelData.sceneName);
        gameObject.SetActive(false);
    }

    public void SetLevelSelect(bool value)
    {
        gameObject.SetActive(value);
    }
}
