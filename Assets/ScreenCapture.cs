using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCapture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            CaptureScreen();
    }

    public void CaptureScreen()
    {
        UnityEngine.ScreenCapture.CaptureScreenshot("test.png");
    }
}
