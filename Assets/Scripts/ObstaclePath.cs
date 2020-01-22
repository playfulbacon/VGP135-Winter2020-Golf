using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePath : MonoBehaviour
{
    [SerializeField]
    Transform pathPointHolder = null;
    [SerializeField]
    float speed = 0.0f;

    int targetPathPointIndex = 1;
    List<Vector3> pathpoints = new List<Vector3>();

    private void Start()
    {
        pathpoints.Add(transform.position);
        foreach (Transform child in pathPointHolder)
        {
            pathpoints.Add(child.position);
        }

        StartCoroutine(MoveAlongPath());
    }

    IEnumerator MoveAlongPath()
    {
        while (true)
        {
            Vector3 targetTransform = pathpoints[targetPathPointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetTransform, speed * Time.deltaTime);
            if (transform.position == targetTransform)
            {
                targetPathPointIndex = GetNextPathPointIndex();
            }
            yield return new WaitForFixedUpdate();
        }
    }

    int GetNextPathPointIndex()
    {
        int resultIndex = targetPathPointIndex;
        if (resultIndex < pathpoints.Count - 1)
        {
            ++resultIndex;
        }
        else
        {
            resultIndex = 0;
        }
        return resultIndex;
    }

    private void OnDrawGizmos()
    {
        for (int i = 1; i < pathpoints.Count; ++i)
        {
            Gizmos.DrawLine(pathpoints[i], pathpoints[i - 1]);
        }
    }
}
