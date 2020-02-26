using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCapture : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.S;

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
            CaptureScreen();
    }

    public void CaptureScreen()
    {
        UnityEngine.ScreenCapture.CaptureScreenshot("test.png");
    }
}
