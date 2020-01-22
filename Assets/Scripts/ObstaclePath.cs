using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePath : MonoBehaviour
{
    [SerializeField]
    Transform pathPointerHolder;
    List<Vector3> pathPoints = new List<Vector3>();

    [SerializeField]
    float speed = 5.0f;
    int targetPathPoinIndex = 1;
    bool goBack = false;
    void Start()
    {
        pathPoints.Add(transform.position);
        foreach (Transform child in pathPointerHolder)
            pathPoints.Add(child.position);

        StartCoroutine(MoveAlongPath());
    }

    void Update()
    {
        
    }

    IEnumerator MoveAlongPath()
    {
        while (true)
        {
            Vector3 targetPosition = pathPoints[targetPathPoinIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * speed);
            
            if (transform.position == targetPosition)
            {
                targetPathPoinIndex = GetNextPathIndex();
            }

            yield return new WaitForFixedUpdate();
        }
    }
    
    int GetNextPathIndex()
    {
        int newIndex = targetPathPoinIndex;

        if (goBack)
        {
            --newIndex;
            if (newIndex == 1)
            {
                newIndex = 1;
                goBack = false;
            }
        }
        else if (newIndex < pathPoints.Count - 1 && !goBack)
        {
            newIndex++;
        }
        else
        {
            goBack = true;
        }

        return newIndex;
    }
    private void OnDrawGizmos()
    {
        List<Vector3> pathPoints = new List<Vector3>();
        pathPoints.Add(transform.position);
        foreach (Transform child in pathPointerHolder)
            pathPoints.Add(child.position);

        for (int i = 1; i < pathPoints.Count; ++i)
        {
            Gizmos.DrawLine(pathPoints[i], pathPoints[i - 1]);
        }
    }
}
