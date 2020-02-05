using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public LevelSelectButton levelSelectButton;
    public LevelData[] levels;

    void Start()
    {
        foreach(LevelData levelData in levels)
        {
            LevelSelectButton button = Instantiate(levelSelectButton, levelSelectButton.transform.parent);

            button.levelNameText.text = levelData.uiName;
            button.levelDifficultyText.text = levelData.difficulty.ToString();

            button.GetComponent<Button>().onClick.AddListener(delegate { LevelManager.LoadScene(levelData.sceneName); });
        }   
        levelSelectButton.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
