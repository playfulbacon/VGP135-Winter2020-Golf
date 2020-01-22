using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePath : MonoBehaviour
{
    [SerializeField]
    Transform pathPointHolder;
    [SerializeField]
    float speed = 5f;
    int targetPathPointIndex = 1;
    List<Vector3> pathPoints = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        pathPoints.Add(transform.position);
        foreach(Transform child in pathPointHolder)
        {
            pathPoints.Add(child.position);
        }

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
            Vector3 targetPosition = pathPoints[targetPathPointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * speed);             

            if(transform.position == targetPosition)
            {
                targetPathPointIndex = GetNextPathPointIndex();
            }

            yield return new WaitForFixedUpdate();
            
        }        
    }

    int GetNextPathPointIndex()
    {
        int newIndex = targetPathPointIndex;
        if(newIndex < pathPoints.Count - 1)
        {
            newIndex++;
        }
        else
        {
            newIndex = 0;
        }
        return newIndex;
    }

    private void OnDrawGizmos()
    {                
        for(int i = 1; i < pathPoints.Count; ++i)
        {
            Gizmos.DrawLine(pathPoints[i], pathPoints[i - 1]);
        }
    }
}
