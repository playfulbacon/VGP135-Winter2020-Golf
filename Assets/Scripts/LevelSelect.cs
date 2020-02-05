using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public LevelSelectButton levelSelectButon;
    public LevelData[] levels;

    // Start is called before the first frame update
    void Start()
    {
        foreach (LevelData levelData in levels)
        {
            LevelSelectButton button = Instantiate(levelSelectButon, levelSelectButon.transform.parent);

            button.levelNameText.text = levelData.uiName;
            button.difficultyText.text = levelData.difficulty.ToString();

            button.GetComponent<Button>().onClick.AddListener(delegate { LevelManager.LoadScene(levelData.sceneName); });
        }

        levelSelectButon.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
