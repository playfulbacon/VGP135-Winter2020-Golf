﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow;
    public float followSpeed = 5f;
    Vector3 velocity;
    void Start()
    {
        if (objectToFollow == null)
            objectToFollow = FindObjectOfType<Ball>().gameObject;
    }

    void Update()
    {
        Vector3 targetPosition = objectToFollow.transform.position;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, Time.deltaTime * followSpeed);
    }
}
