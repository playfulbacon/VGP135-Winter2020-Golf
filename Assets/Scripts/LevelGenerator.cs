using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float minrandomGoalRange = 5f;
    public float maxrandomGoalRange = 5f;
    public float minobstacleRange = 5f;
    public float maxobstacleRange = 5f;
    public GameObject ballPrefab;
    public GameObject goalPrefab;
    public GameObject planePrefab;
    public GameObject obstaclePrefab;
    public int gridSize= 10;
    Dictionary<Vector2, GameObject> positionObjectDictionary = new Dictionary<Vector2, GameObject>();
    List<Vector2> freeGridSpaces = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void GenerateLevel()
        {
        for (int y = 0; y < gridSize; y++)
        {
            for(int x =0;x< gridSize; x++)
            {
                freeGridSpaces.Add(new Vector2(x,y));
            }
        }

        GameObject ball = Instantiate(ballPrefab);
        Instantiate(ballPrefab);
        GameObject plane = Instantiate(planePrefab);
        plane.transform.localScale = new Vector3(gridSize / 5f, 1, gridSize / 5f);
        GameObject goal = Instantiate(goalPrefab);

        RandomlyPositionObjectOnGrid(goal);

        for (int  i = 0;  i < 5;  i++)
        {
            GameObject obsacle = Instantiate(obstaclePrefab);


            RandomlyPositionObjectOnGrid(obsacle);
        }
    }

    void RandomlyPositionObjectOnGrid(GameObject gameObject)
    {
        Vector2 gridSpace = freeGridSpaces[Random.Range(0, freeGridSpaces.Count)];

        freeGridSpaces.Remove(gridSpace);

        Vector3 gridPosition = new Vector3(-gridSize/2 + gridSpace[0], 0, gridSize/2 + gridSpace[0]);
        gameObject.transform.position = gridPosition;
    }
}
