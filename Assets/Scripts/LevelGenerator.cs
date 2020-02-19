using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float minrandomGoalRange = 5f;
    public float maxrandomGoalRange = 5f;

    public float minrandomObjstacleRange = 5f;
    public float maxrandomObjstacleRange = 5f;

    public GameObject ballPrefab;
    public GameObject goalPrefab;
    public GameObject planePrefab;
    public GameObject obstaclePrefab;
    private int gridSize = 10;

    List<Vector2> freeGridSpaces;
    Dictionary<Vector2, GameObject> positionObjectDirctionary = new Dictionary<Vector2, GameObject>();
    

    public void Awake()
    {
        GenerateLevel();
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateLevel()
    {
        
        for(int y =0; y<gridSize;++y)
        {
            for(int x=0; x<gridSize;++x)
            {
                freeGridSpaces.Add(new Vector2(x,y));
            }
        }
        GameObject plane = Instantiate(planePrefab);
        GameObject ball = Instantiate(ballPrefab);

        
        plane.transform.localScale = new Vector3(gridSize/5f, 1,gridSize/5f);
        GameObject goal = Instantiate(goalPrefab);
        RandomlyPositionIbjectOnGrid(goal);

        for(int i =0;i<5;++i)
        {
            GameObject objstacle = Instantiate(obstaclePrefab);
            RandomlyPositionIbjectOnGrid(objstacle);
        }
    }
    private void RandomlyPositionIbjectOnGrid(GameObject gameObject)
    {
        if(freeGridSpaces.Count==0)
        {
            return;
        }
        Vector2 gridSpace = freeGridSpaces[Random.Range(0, freeGridSpaces.Count)];
        freeGridSpaces.Remove(gridSpace);
        Vector3 gridPosition = new Vector3(-gridSize/2 + gridSpace[0],  0, -gridSize / 2 + gridSpace[0]);
        gameObject.transform.position = gridPosition;

    }
}
