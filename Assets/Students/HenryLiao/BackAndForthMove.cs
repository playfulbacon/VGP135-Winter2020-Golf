using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForthMove : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float moveSpeed = 10.0f;

    private Vector3 target;
    void Start()
    {
        target = startPos;
    }

    void Update()
    {
        if (transform.position == startPos)
        {
            target = endPos;
        }
        else if (transform.position == endPos)
        {
            target = startPos;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
}
