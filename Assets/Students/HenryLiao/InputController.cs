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
        SetRotatingCam(false);
    }

    private void Update()
    {
        bool _isRotatingCam = Input.touchCount == 2 || Input.GetKey(DebugKey);

        if (isRotatingCam != _isRotatingCam)
        {
            SetRotatingCam(_isRotatingCam);
        }
    }

    private void SetRotatingCam(bool set)
    {
        isRotatingCam = set;
        cameraRotator.SetEnabled(isRotatingCam);
        ballController.SetEnabled(!isRotatingCam);
    }
}
