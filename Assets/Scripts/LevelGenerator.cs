using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float minGoalDistFromOrigin = 10.0f;
    public GameObject ballPrefab;
    public GameObject goalPrefab;
    public GameObject planePrefab;
    public GameObject obstacleCubePrefab;
    public int gridSize = 20;

    List<Vector2> freeGridSpaces = new List<Vector2>();

    private void Awake()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int i = 0; i < gridSize; ++i)
        {
            for (int j = 0; j < gridSize; ++j)
            {
                freeGridSpaces.Add(new Vector2(i, j));
            }
        }

        freeGridSpaces.Remove(new Vector2(0, 0));

        //Instantiate Major Gameobjects.
        Transform ballTransform = Instantiate(ballPrefab).transform;
        Transform goalTransform = Instantiate(goalPrefab).transform;
        Transform planeTransform = Instantiate(planePrefab).transform;

        //Randomize position of goal.
        RandomizeAndSetPosition(goalTransform.gameObject);

        //Set playable ground to scale.
        planeTransform.localScale = new Vector3(gridSize / 5, 1, gridSize /5);

        for (int i = 0; i < 50; ++i)
        {
            GameObject obstacle = Instantiate(obstacleCubePrefab);
            RandomizeAndSetPosition(obstacle);
        }
    }

    bool RandomizeAndSetPosition(GameObject gameObject)
    {
        if (freeGridSpaces.Count == 0)
        {
            Debug.Log("No More Free Space");
            return false;
        }

        Vector2 gridSpace = freeGridSpaces[Random.Range(0, freeGridSpaces.Count)];
        freeGridSpaces.Remove(gridSpace);
        Vector3 randomizedPos = new Vector3(-gridSize / 2 + gridSpace.x, 0.0f, -gridSize / 2 + gridSpace.y);
        gameObject.transform.position = randomizedPos;
        return true;
    }
}
