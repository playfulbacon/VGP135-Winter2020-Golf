using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public enum Difficulty { easy, medium, hard };
    public string sceneName;
    public string uiName;
    public Difficulty difficulty;
    public Sprite levelimage;
    public int par;
}
