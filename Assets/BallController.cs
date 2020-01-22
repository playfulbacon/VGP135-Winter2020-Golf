using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Ball[] balls;
    float aimingSlowdown = 0.2f;
    bool isDragging = false;
    Vector3 hitDirection;
    bool isPressed = false;
    Vector3 mouseStartPosition, dragStartPos;

    void Start()
    {
        balls = FindObjectsOfType<Ball>();    
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = aimingSlowdown;
            isPressed = true;
            dragStartPos = Input.mousePosition;

            // MouseDown
            foreach (Ball ball in balls)
                ball.MouseDown();
        }

        if (isPressed)
        {
            Vector3 mousePos = Input.mousePosition;

            if (Vector3.Distance(mousePos, dragStartPos) > 0.5f)
            {
                if (!isDragging)
                {
                    mouseStartPosition = Input.mousePosition;
                    isDragging = true;

                    foreach (Ball ball in balls)
                        ball.StartDrag();
                }

                hitDirection = -(mousePos - dragStartPos).normalized;
                hitDirection = new Vector3(hitDirection.x, 0f, hitDirection.y);
            }
        }

        if (isDragging)
        {
            float dragDistance = (Input.mousePosition - mouseStartPosition).magnitude;
            // Drag
            foreach (Ball ball in balls)
                ball.Drag(hitDirection, dragDistance);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1f;

            foreach (Ball ball in balls)
                ball.MouseUp();

            if (isDragging)
            {
                foreach (Ball ball in balls)
                    ball.Hit(hitDirection);
            }

            isPressed = false;
            isDragging = false;
        }
    }
}
