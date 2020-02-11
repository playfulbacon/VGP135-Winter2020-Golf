using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Vector3 spinDirection;
    public float spinSpeed;

    private void Start()
    {
        spinDirection.Normalize();
    }

    private void Update()
    {
        transform.Rotate(spinDirection * spinSpeed * Time.deltaTime, Space.World);
    }
}
