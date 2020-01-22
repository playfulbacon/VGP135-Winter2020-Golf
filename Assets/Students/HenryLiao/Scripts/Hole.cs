using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
	public GameControl gameControl;

	private void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player")
		{
			other.GetComponent<Rigidbody>().isKinematic = true;
			gameControl.CompleteLevel(3);
		}
	}
}
