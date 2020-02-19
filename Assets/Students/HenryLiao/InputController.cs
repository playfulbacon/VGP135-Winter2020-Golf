using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public KeyCode DebugKey = KeyCode.C;

    private CameraRotator cameraRotator;
    private BallController ballController;

    private bool isRotatingCam;

    void Start()
    {
        cameraRotator = FindObjectOfType<CameraRotator>();
        ballController = FindObjectOfType<BallController>();
    }

    private void Update()
    {
        isRotatingCam = Input.touchCount == 2 || Input.GetKey(DebugKey);

        cameraRotator.SetEnabled(isRotatingCam);
        ballController.SetEnabled(!isRotatingCam);
    }
}
