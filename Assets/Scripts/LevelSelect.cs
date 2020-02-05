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
        foreach (LevelData levelData in levels)
        {
            print(levelData.sceneName);
            LevelSelectButton button = Instantiate(levelSelectButton, levelSelectButton.transform.parent);
            
          button.levelNameText.text = levelData.uiName;
            button.difficultyText.text = levelData.difficulty.ToString();

            button.GetComponent<Button>().onClick.AddListener(delegate { LevelManager.LoadScene(levelData.sceneName)});
        }
        levelSelectButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
