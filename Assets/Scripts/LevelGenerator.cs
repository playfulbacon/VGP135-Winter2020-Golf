using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject goalPrefab;
    public GameObject planePrefab;
    public GameObject obstaclePrefab;
    private int gridSize = 10;
    List<Vector2> freeGridSpaces = new List<Vector2>();

    private void Awake()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        // populate the free grid spaces array
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                freeGridSpaces.Add(new Vector2(x, y));
            }
        }

        GameObject ball = Instantiate(ballPrefab);
        RandomlyPositionObjectOnGrid(ball);
        ball.transform.position += Vector3.up * 2f;

        // create plane and set size
        GameObject plane = Instantiate(planePrefab);
        plane.transform.localScale = new Vector3(gridSize / 5f, 1f, gridSize / 5f);

        // create goal and randomize position
        GameObject goal = Instantiate(goalPrefab);
        RandomlyPositionObjectOnGrid(goal);

        // create obstacles and randomize position
        for (int i = 0; i < 25; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefab);
            RandomlyPositionObjectOnGrid(obstacle);
        }
    }

    private void RandomlyPositionObjectOnGrid(GameObject gameObject)
    {
        if (freeGridSpaces.Count == 0)
        {
            Debug.LogError("no free spaces left in the grid!");
            return;
        }

        Vector2 gridSpace = freeGridSpaces[Random.Range(0, freeGridSpaces.Count)];
        freeGridSpaces.Remove(gridSpace);
        Vector3 gridPosition = new Vector3(-gridSize/2 + gridSpace[0], 0, -gridSize/2 + gridSpace[1]);
        gameObject.transform.position = gridPosition;
    }
}
