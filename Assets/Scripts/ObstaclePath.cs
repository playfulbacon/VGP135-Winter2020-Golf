using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePath : MonoBehaviour
{
    [SerializeField]
    Transform pathHolder;
    int targetPathPointIndex = 0;
    List<Vector3> pathPoints = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in pathHolder)
        {
            pathPoints.Add(child.position);
        }
        /*for (int i = 1; i < pathHolder.childCount; ++i)
        {
            Gizmos.DrawLine(pathPoints[i].position, pathPoints[i + 1].position);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator MoveAlongPath()
    {
        while(true)
        {
            Vector3 tragetPosition = pathPoints[targetPathPointIndex];

        }
    }

}
