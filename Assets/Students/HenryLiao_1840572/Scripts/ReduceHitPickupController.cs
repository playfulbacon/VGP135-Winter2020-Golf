using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceHitPickupController : MonoBehaviour
{
	const float spinSpeed = 50.0f;

	private void Update()
	{
		transform.Rotate(new Vector3(0.0f, spinSpeed, 0.0f) * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Ball"))
		{
			Ball ball = other.GetComponentInParent<Ball>();
			ball.ReduceHit();
			gameObject.SetActive(false);
		}
	}
}
