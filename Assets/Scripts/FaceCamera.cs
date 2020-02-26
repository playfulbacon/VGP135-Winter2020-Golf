using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    void Update()
    {
        Vector3 facingCameraDirection = (transform.position - Camera.main.transform.position);
        transform.forward = facingCameraDirection;
    }
}
