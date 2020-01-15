using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    public float moveDistance = 5f;
    public float speed = 10f;
    Vector3 target1, target2;
    bool isMovingBack = false;

    void Start()
    {
        target1 = transform.position + (transform.right * moveDistance / 2);
        target2 = transform.position - (transform.right * moveDistance / 2);
    }

    void Update()
    {
        Vector3 target = isMovingBack ? target2 : target1;
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position == target)
            isMovingBack = !isMovingBack;
    }
}
