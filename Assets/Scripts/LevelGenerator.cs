using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float minGoalRange = 5f;    
    public float maxGoalRange = 15f;
    public GameObject ballPrefab;
    public GameObject goalPrefab;
    public GameObject planePrefab;

    private void Awake()
    {
        GenerateLevel();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateLevel()
    {
        Instantiate(ballPrefab);

        //GameObject goal = Instantiate(goalPrefab);
  
        Instantiate(goalPrefab);
        Instantiate(planePrefab);

    }
}
