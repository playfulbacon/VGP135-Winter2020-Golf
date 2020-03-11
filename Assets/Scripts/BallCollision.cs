using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public System.Action<Enemy> OnEnemyKill;
    BallHealth ballHealth;

    void Start()
    {
        ballHealth = GetComponent<BallHealth>();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            ballHealth.TakeDamage(obstacle.damage);
        }

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            float magnitude = GetComponent<Rigidbody>().velocity.magnitude;
            if (magnitude > 2.5f)
            {
                float enemyHealth = enemy.TakeDamage(enemy.maxHealth / 2);

                if (enemyHealth == 0)
                    OnEnemyKill?.Invoke(enemy);
            }
        }
    }
}
