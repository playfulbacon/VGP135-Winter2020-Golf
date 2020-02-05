using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticalpath : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform PathPointHolder;
    int targetPathPointIndex = 0;
    int currentPathPointIndex = 0;
    float speed = 5f;
    List<Vector3> pathPoints = new List<Vector3>();
    void Start()
    {
        pathPoints.Add(transform.position);
        foreach (Transform child in PathPointHolder)
            pathPoints.Add(child.position);
        StartCoroutine(MoveAlongPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveAlongPath()
    {
        while(true)
        {
            Vector3 targetposition = pathPoints[targetPathPointIndex];

           transform.position =Vector3.MoveTowards(transform.position, targetposition, Time.fixedDeltaTime * speed);

            if(transform.position == targetposition)
            {
                targetPathPointIndex++;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    int GetNextPathPointIndex()
    {
        int newIndex = targetPathPointIndex;
        if(newIndex < pathPoints.Count)
        {
            newIndex++;
        }
        else
            newIndex = 0;
        return newIndex;
    }


    private void OnDrawGizmos()
    {
        List<Transform> pathPoints = new List<Transform>();

        foreach (Transform child in PathPointHolder)
            pathPoints.Add(child);
        for (int i = 1; i < pathPoints.Count; ++i)
        {
            Gizmos.DrawLine(pathPoints[i].position, pathPoints[i - 1].position);
        }
    }

}
