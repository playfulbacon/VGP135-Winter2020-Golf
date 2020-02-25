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
    float obstacleCudeSize = 0;

    private void Awake()
    {
        if (gridSize % 2 == 0)
        {
            ++gridSize;
        }

        obstacleCudeSize = (obstacleCubePrefab.gameObject.transform.localScale.x + obstacleCubePrefab.gameObject.transform.localScale.z) / 2;

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

        GenerateMaze();

        //Instantiate Major Gameobjects.
        Transform ballTransform = Instantiate(ballPrefab).transform;
        Transform goalTransform = Instantiate(goalPrefab).transform;
        Transform planeTransform = Instantiate(planePrefab).transform;

        //Randomize position of goal.
        RandomizeAndSetPosition(goalTransform.gameObject);

        //Set playable ground to scale.
        planeTransform.localScale = new Vector3(gridSize / 5, 1, gridSize / 5);
        planeTransform.position = new Vector3(gridSize / 2, 0, gridSize / 2) * 2;

        //Set Ball position.
        freeGridSpaces.Remove(new Vector2(gridSize / 2, gridSize / 2));
        ballTransform.position = new Vector3(gridSize / 2, 0, gridSize / 2) * 2;
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
        Vector3 randomizedPos = new Vector3(gridSpace.x, 0.0f, gridSpace.y) * obstacleCudeSize;
        gameObject.transform.position = randomizedPos;
        return true;
    }

    void GenerateMaze()
    {
        List<Vector2> pathpoints = new List<Vector2>();
        pathpoints.Add(new Vector2(gridSize / 2, gridSize / 2));
        pathpoints.Add(new Vector2(gridSize / 2, gridSize / 2 + 1));
        pathpoints.Add(new Vector2(gridSize / 2, gridSize / 2 + 2));
        int currentpoint = 2;

        //Generate maze path.
        while (true)
        {
            if (currentpoint == 0)
            {
                break;
            }

            //Determine all possible ways the path can turn.
            List<Vector2> possiblePaths = new List<Vector2>();

            Vector2 top = new Vector2(pathpoints[currentpoint].x, pathpoints[currentpoint].y + 2);
            Vector2 left = new Vector2(pathpoints[currentpoint].x - 2, pathpoints[currentpoint].y);
            Vector2 bot = new Vector2(pathpoints[currentpoint].x, pathpoints[currentpoint].y - 2);
            Vector2 right = new Vector2(pathpoints[currentpoint].x + 2, pathpoints[currentpoint].y);

            if (top.y < gridSize - 1 && !pathpoints.Contains(top))
            {
                possiblePaths.Add(top);
            }
            if (left.x > 0 && !pathpoints.Contains(left))
            {
                possiblePaths.Add(left);
            }
            if (bot.y > 0 && !pathpoints.Contains(bot))
            {
                possiblePaths.Add(bot);
            }
            if (right.x < gridSize - 1 && !pathpoints.Contains(right))
            {
                possiblePaths.Add(right);
            }

            //If there are atleast 1 possible path to continue, continue the path. Otherwise, track backward and branch into new possible paths.
            if (possiblePaths.Count != 0)
            {
                Vector2 randomSelectedPath = possiblePaths[Random.Range(0, possiblePaths.Count)];
                if (randomSelectedPath == top)
                {
                    pathpoints.Insert(currentpoint + 1, top);
                    pathpoints.Insert(currentpoint + 1, new Vector2(top.x, top.y - 1));
                    currentpoint += 2;
                }
                else if (randomSelectedPath == left)
                {
                    pathpoints.Insert(currentpoint + 1, left);
                    pathpoints.Insert(currentpoint + 1, new Vector2(left.x + 1, left.y));
                    currentpoint += 2;
                }
                else if (randomSelectedPath == bot)
                {
                    pathpoints.Insert(currentpoint + 1, bot);
                    pathpoints.Insert(currentpoint + 1, new Vector2(bot.x, bot.y + 1));
                    currentpoint += 2;
                }
                else if (randomSelectedPath == right)
                {
                    pathpoints.Insert(currentpoint + 1, right);
                    pathpoints.Insert(currentpoint + 1, new Vector2(right.x - 1, right.y));
                    currentpoint += 2;
                }
            }
            else
            {
                currentpoint -= 2;
            }
        }

        for(int row = 0; row < gridSize; ++row)
        {
            for (int col = 0; col < gridSize; ++col)
            {
                Vector2 gridSpace = new Vector2(row, col);
                if (!pathpoints.Contains(gridSpace) && freeGridSpaces.Contains(gridSpace))
                {
                    GameObject obstacle = Instantiate(obstacleCubePrefab);
                    freeGridSpaces.Remove(gridSpace);
                    obstacle.transform.position = new Vector3( gridSpace.x, 0.0f, gridSpace.y) * obstacleCudeSize;
                }
            }
        }
    }


    int GetIndex(int row, int col)
    {
        return row * gridSize + col;
    }
}