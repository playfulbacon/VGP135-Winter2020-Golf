using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public GameObject respawnPoint;

    public void Respawn (GameObject ball)
    {
        ball.transform.position = respawnPoint.transform.position;
        ball.transform.rotation = Quaternion.Euler(0, 0, 0);
        ball.GetComponent<BallHealth>().maxHealth = ball.GetComponent<BallHealth>().maxHealth;

    }
}
