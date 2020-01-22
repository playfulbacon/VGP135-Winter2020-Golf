using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    Rigidbody rb;
    bool isPressed = false;
    bool isDragging = false;
    public Transform aimPrefab;
    Vector3 hitDirection;
    float hitMaxForce = 1000f;

    [SerializeField]
    float currentForce = 0f;

    Vector3 mouseStartPosition;
    Vector3 mouseFinalPosition;

    float forcePercentage = 0.0f;

    float maxForceDistance = 200.0f;

    float timeRatio = 0.2f;

    float currentForceDistance;

    float aimPrefabZLength;
    Vector2 dragStartPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aimPrefab = Instantiate(aimPrefab);
        aimPrefabZLength = aimPrefab.transform.localScale.z;
        aimPrefab.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.isKinematic = true;
            isPressed = true;

            Time.timeScale = timeRatio;

            dragStartPos = Input.mousePosition;
        }

        if (isPressed)
        {
            Vector2 mousePos = Input.mousePosition;

            if (Vector3.Distance(mousePos, dragStartPos) > 0.5f)
            {
                if (!isDragging)
                {
                    mouseStartPosition = Input.mousePosition;

                    isDragging = true;

                    aimPrefab.gameObject.SetActive(true);
                }

                hitDirection = -(mousePos - dragStartPos).normalized;
                hitDirection = new Vector3(hitDirection.x, 0f, hitDirection.y);
                aimPrefab.transform.forward = hitDirection;
                aimPrefab.position = transform.position - hitDirection * 0.5f;
            }
        }

        if (isDragging)
        {
            mouseFinalPosition = Input.mousePosition;
            currentForceDistance = (mouseFinalPosition - mouseStartPosition).magnitude;

            forcePercentage = currentForceDistance / maxForceDistance;

            if (forcePercentage > 1.0f)
                forcePercentage = 1.0f;

            aimPrefab.GetComponent<Aimer>().forceQuad.transform.localScale = new Vector3(aimPrefab.localScale.x, aimPrefab.localScale.y, -(aimPrefabZLength * forcePercentage));
            //aimPrefab.localScale = new Vector3(aimPrefab.localScale.x, aimPrefab.localScale.y, -(aimPrefabZLength * forcePercentage));
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentForce = hitMaxForce * forcePercentage;

            rb.isKinematic = false;
            isPressed = false;
            aimPrefab.gameObject.SetActive(false);

            if (isDragging)
                rb.AddForce(hitDirection * currentForce);

            isDragging = false;
            currentForce = 0.0f;

            Time.timeScale = 1.0f;
        }

        Time.fixedDeltaTime = .02f * Time.timeScale;
        //Debug.Log(Time.timeScale);
    }

    public void OnTriggerEnter(Collider other)
    {
        Goal goal = other.attachedRigidbody?.GetComponent<Goal>();
        if (goal)
        {
            goal.OnHit();
            rb.isKinematic = true;
        }

        Collectable collectable = other.attachedRigidbody?.GetComponent<Collectable>();
        if (collectable)
        {
            collectable.OnCollect();
        }
    }
}
