using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float initialHitSpeed;
	public int health;

	public GameObject powerIndicatorBase;
	public GameControl gameControl;
	public MeshRenderer meshRenderer;

	private new Rigidbody rigidbody;
	private Vector3 startDragPosition = new Vector3();
	private Vector3 currentDragPosition = new Vector3();
	private Vector3 hitDirection = new Vector3();
	private bool isDragging = false;
	private float hitPower = 0.0f;
	private GameObject powerIndicator;
	private int maxHealth;


	void Start()
	{
		maxHealth = health;
		rigidbody = GetComponent<Rigidbody>();
		powerIndicator = powerIndicatorBase.transform.GetChild(0).gameObject;
		powerIndicatorBase.SetActive(false);
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && !rigidbody.isKinematic)
		{
			isDragging = true;
			startDragPosition = Input.mousePosition;
			powerIndicatorBase.SetActive(true);
		}

		if (isDragging)
		{
			currentDragPosition = Input.mousePosition;
			hitDirection = new Vector3(startDragPosition.x - currentDragPosition.x, 0.0f, startDragPosition.y - currentDragPosition.y).normalized;
			hitPower = Mathf.Lerp(0.0f, 1.0f, (startDragPosition - currentDragPosition).magnitude / ((Screen.width + Screen.height) * 0.1f));

			Vector3 indicatorRotation = new Vector3(0.0f, Vector3.SignedAngle(Vector3.forward, hitDirection, Vector3.up), 0.0f);
			powerIndicatorBase.transform.position = transform.position + hitDirection * (transform.localScale.x * 2.5f);
			powerIndicatorBase.transform.eulerAngles = indicatorRotation;
			powerIndicator.transform.localScale = new Vector3(1.0f, 1.0f, hitPower);
			powerIndicator.transform.position = transform.position + hitDirection * Mathf.Lerp(transform.localScale.x, transform.localScale.x * 2.5f, hitPower) + new Vector3(0.0f, 0.1f, 0.0f);
			powerIndicator.transform.eulerAngles = indicatorRotation;
		}

		if (Input.GetMouseButtonUp(0) && isDragging)
		{
			isDragging = false;
			powerIndicatorBase.SetActive(false);
			rigidbody.velocity = hitDirection * initialHitSpeed * hitPower;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Obstacle"))
		{
			health -= 20;
			meshRenderer.material.color = Color.Lerp(Color.red, Color.white, (float) health / maxHealth);
			if (health < 0)
			{
				gameControl.RestartLevel();
			}
		}
	}
}
