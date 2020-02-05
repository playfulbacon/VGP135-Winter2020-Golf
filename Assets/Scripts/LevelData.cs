using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public enum Difficulty { easy, medium, hard };
    public string sceneName;
    public string uiName;
    public Difficulty difficulty;
}
