using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    BallHealth ballHealth;

    // Start is called before the first frame update
    void Start()
    {
        ballHealth = GetComponent<BallHealth>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            ballHealth.TakeDamage(obstacle.damage);
        }

    }
}
