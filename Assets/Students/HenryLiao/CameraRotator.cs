using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float rotateSpeed = 10.0f;

    private bool rotateEnabled = true;
    private float currentYRotation = 0.0f;

    private void LateUpdate()
    {
        if (rotateEnabled && Input.GetMouseButton(0))
        {
            float dragAmountX = Input.GetAxis("Mouse X");
            currentYRotation += dragAmountX * rotateSpeed;
            Vector3 oldRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(oldRotation.x, currentYRotation, oldRotation.z);
        }
    }

    public void SetEnabled(bool enabled)
    {
        rotateEnabled = enabled;
    }

    public float GetCurrentYRotation()
    {
        return currentYRotation;
    }

    public void SetCurrentYRotation(float yDegreesInWorldSpace)
    {
        currentYRotation = yDegreesInWorldSpace;
        Vector3 oldRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(oldRotation.x, currentYRotation, oldRotation.z);
    }

}
