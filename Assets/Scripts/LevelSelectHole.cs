using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectHole : Goal
{
    public TextMesh sceneNameText;
    public TextMesh authorNameText;
    public string sceneName;
    public string authorName;

    void Start()
    {
        sceneNameText.text = sceneName;
        authorNameText.text = authorName;
    }

    public override void OnHit()
    {
        SceneManager.LoadScene(sceneName);
    }
}
