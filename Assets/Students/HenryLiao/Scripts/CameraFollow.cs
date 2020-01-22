using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform playerTransform;
	public Vector3 offset;
	public float smoothTime;

	private Vector3 velocity = Vector3.zero;

	void LateUpdate()
    {
		Vector3 desiredPos = playerTransform.position + offset;
		transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);
    }
}
