using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="LeveData", menuName = "ScriptableObject/LevelData", order = 1)]
public class LevelData : MonoBehaviour
{
    public enum Difficulty { easy,medium,hard};
    public string sceneName;
    public string uiName;
    public Difficulty difficulty;
}
