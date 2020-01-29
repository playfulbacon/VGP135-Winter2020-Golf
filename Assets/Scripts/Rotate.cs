using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    Vector3 rotation;

    [SerializeField]
    float rotationSpeed = 90f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime, Space.World);
    }
}
