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
    float speedMultiplier = 1f;
    [SerializeField]
    float currentForce = 0f;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float accuracyValue = 0.0f;
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

    public void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
    }

    public void ResetSpeedMultiplie()
    {
        speedMultiplier = 1f;
    }

    public void Drag(Vector3 hitDirection, float dragDistance)
    {
        aimPrefab.transform.forward = hitDirection;
        aimPrefab.position = transform.position - hitDirection * 0.5f;

        forcePercentage = dragDistance / maxForceDistance;

        if (forcePercentage > 1.0f)
            forcePercentage = 1.0f;

        aimPrefab.GetComponent<Aimer>().SetPercentage(forcePercentage);

        currentForce = hitMaxForce * forcePercentage * speedMultiplier;
    }

    public void MouseUp()
    {
        rb.isKinematic = false;
        aimPrefab.gameObject.SetActive(false);
    }

    public void Hit(Vector3 hitDirection)
    {
        rb.AddForce(HitDirectionWithAccuracy(hitDirection) * currentForce);

        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource)
        {
            audioSource.pitch = Mathf.Lerp(3f, 1f, currentForce / hitMaxForce);
            GetComponent<AudioSource>()?.Play();
        }
    }

    public void SetAccuracy(float value)
    {
        accuracyValue = Mathf.Clamp01(value);
    }

    private Vector3 HitDirectionWithAccuracy(Vector3 hitdirection)
    {
        float angleRange = (1.0f - accuracyValue) * 45.0f;
        return Quaternion.Euler(0.0f, Random.Range(-angleRange, angleRange), 0.0f) * hitdirection;
    }
}
