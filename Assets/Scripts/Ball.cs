using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    Transform aimPrefab;
    float hitMaxForce = 1000f;
    [SerializeField]
    float currentForce = 0f;
    float forcePercentage = 0.0f;
    float maxForceDistance = 200.0f;
    float currentForceDistance;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aimPrefab = Instantiate(aimPrefab);
        aimPrefab.gameObject.SetActive(false);
    }

    public void MouseDown()
    {
        rb.isKinematic = true;
    }

    public void StartDrag()
    {
        aimPrefab.gameObject.SetActive(true);
    }

    public void Drag(Vector3 hitDirection, float dragDistance)
    {
        aimPrefab.transform.forward = hitDirection;
        aimPrefab.position = transform.position - hitDirection * 0.5f;

        forcePercentage = dragDistance / maxForceDistance;

        if (forcePercentage > 1.0f)
            forcePercentage = 1.0f;

        aimPrefab.GetComponent<Aimer>().SetPercentage(forcePercentage);

        currentForce = hitMaxForce * forcePercentage;
    }

    public void MouseUp()
    {
        rb.isKinematic = false;
        aimPrefab.gameObject.SetActive(false);
    }

    public void Hit(Vector3 hitDirection)
    {
        rb.AddForce(hitDirection * currentForce);
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
