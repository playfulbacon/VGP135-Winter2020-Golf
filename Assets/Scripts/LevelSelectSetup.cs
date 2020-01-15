using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectSetup : MonoBehaviour
{
    public StudentLevelSelectInfo[] studentLevelSelectInfos;
    [System.Serializable]
    public class StudentLevelSelectInfo
    {
        public string studentName;
        public string[] levelNames;
    }

    public GameObject levelSelectHolePrefab;
    public float rowSpace = 1f, columnSpace = 1f;

    void Start()
    {
        int studentIndex = 0;
        foreach(StudentLevelSelectInfo studentLevelSelectInfo in studentLevelSelectInfos)
        {
            // generate level select holes
            int levelIndex = 0;
            foreach(string levelName in studentLevelSelectInfo.levelNames)
            {
                Vector3 spawnPosition = transform.position;
                spawnPosition.z += studentIndex * -rowSpace;
                spawnPosition.x += levelIndex * columnSpace;
                LevelSelectHole levelSelectHole = Instantiate(levelSelectHolePrefab, spawnPosition, Quaternion.identity, transform).GetComponent<LevelSelectHole>();

                levelSelectHole.authorName = studentLevelSelectInfo.studentName;
                levelSelectHole.sceneName = levelName;

                levelIndex++;
            }
            studentIndex++;
        }
    }

    void Update()
    {
        
    }
}
