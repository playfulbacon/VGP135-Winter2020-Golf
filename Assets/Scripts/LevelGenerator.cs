using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject goalPrefab;
    public GameObject planePrefab;
    public GameObject pickup_SpeedUpPrefab;
    public GameObject pickup_SizeUpPrefab; 
    public GameObject obstaclePrefab;

    private int gridSize = 15;
    private float yOffSet = 0.3f;     
    List<Vector2> reservedPositions = new List<Vector2>();
    List<Vector2> freeGridSpaces = new List<Vector2>();

    private void Awake()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for(int y = 0; y < gridSize; ++y)
        {
            for (int x = 0; x < gridSize; x++)
            {
                freeGridSpaces.Add(new Vector2(x, y));
            }
        }

        GameObject ball = Instantiate(ballPrefab);
        RandomlyPositionObjectOnGrid(ball);
        ball.transform.position += Vector3.up * 2f;

        //Create plane based on grid size
        GameObject plane = Instantiate(planePrefab);
        plane.transform.localScale = new Vector3(gridSize / 5f, 1, gridSize / 5f);

        GameObject goal = Instantiate(goalPrefab);
        RandomlyPositionObjectOnGrid(goal);

      
        for (int i = 0; i < 5; i++)
        {
            GameObject pickUp_Speed = Instantiate(pickup_SpeedUpPrefab);
            RandomlyPositionObjectOnGrid(pickUp_Speed);
            pickUp_Speed.transform.position += Vector3.up * yOffSet; 
        }

        for (int i = 0; i < 7; i++)
        {
            GameObject pickUp_SizeUp = Instantiate(pickup_SizeUpPrefab);
            RandomlyPositionObjectOnGrid(pickUp_SizeUp);
            if(i % 2 == 0)
            {
                pickUp_SizeUp.GetComponent<Pickup_ResizeBall>().changeSize = ChangeSize.Increase;
            }
            else
            {
                pickUp_SizeUp.GetComponent<Pickup_ResizeBall>().changeSize = ChangeSize.Decrease;
            }
            pickUp_SizeUp.GetComponent<Pickup_ResizeBall>().sizeMultiplier = Random.Range(2, 5);
            pickUp_SizeUp.transform.position += Vector3.up * yOffSet;

        }

        for (int i = 0; i < 30; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefab);
            RandomlyPositionObjectOnGrid(obstacle);
        }
    }

    void RandomlyPositionObjectOnGrid(GameObject gameObject)
    {
        if (freeGridSpaces.Count == 0)
        {
            Debug.Log("no free spaces left in the grid");
            return;
        }
        Vector2 gridSpace = freeGridSpaces[Random.Range(0, freeGridSpaces.Count)];
        freeGridSpaces.Remove(gridSpace);
        Vector3 gridPosition = new Vector3(-gridSize / 2 + gridSpace[0] - 0, 0, -gridSize / 2 + gridSpace[1]);
        gameObject.transform.position = gridPosition;
    }
}
