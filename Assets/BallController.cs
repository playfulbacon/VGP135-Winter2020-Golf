﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallController : MonoBehaviour
{
    public Action OnTouchDown, OnStartDrag, OnTouchUp;
    public Action<Vector3, float> OnDrag;
    public Action<Vector3> OnHit;

    Ball[] balls;
    float aimingSlowdown = 0.2f;
    bool isDragging = false;
    Vector3 hitDirection;
    bool isPressed = false;
    Vector3 mouseStartPosition, dragStartPos;

    int hits = 0;

    void Start()
    {
        balls = FindObjectsOfType<Ball>();    

        foreach(Ball ball in balls)
        {
            OnTouchDown += ball.MouseDown;
            OnStartDrag += ball.StartDrag;
            OnDrag += ball.Drag;
            OnHit += ball.Hit;
        }
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = aimingSlowdown;
            isPressed = true;
            dragStartPos = Input.mousePosition;
            OnTouchDown?.Invoke();
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
                    OnStartDrag?.Invoke();
                }

                hitDirection = -(mousePos - dragStartPos).normalized;
                hitDirection = new Vector3(hitDirection.x, 0f, hitDirection.y);
            }
        }

        if (isDragging)
        {
            float dragDistance = (Input.mousePosition - mouseStartPosition).magnitude;
            OnDrag?.Invoke(hitDirection, dragDistance);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1f;

            foreach (Ball ball in balls)
                ball.MouseUp();

            if (isDragging)
            {
                OnHit?.Invoke(hitDirection);
            }

            isPressed = false;
            isDragging = false;
        }
    }
}
