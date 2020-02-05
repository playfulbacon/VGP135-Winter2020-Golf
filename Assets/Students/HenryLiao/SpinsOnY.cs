using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinsOnY : MonoBehaviour
{
    public float spinSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, spinSpeed, 0.0f) * Time.deltaTime, Space.World);
    }
}
