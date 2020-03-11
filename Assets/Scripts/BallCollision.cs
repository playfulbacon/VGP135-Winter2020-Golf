using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    BallHealth ballHealth;
    BallSkills ballSkills;

    void Start()
    {
        ballHealth = GetComponent<BallHealth>();
        ballSkills = GetComponent<BallSkills>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obstacleObj = collision.gameObject;
        Obstacle obstacle = obstacleObj.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            if (!ballSkills.mIsFire)
            {
                ballHealth.TakeDamage(obstacle.damage);
            }
            else
            {
                Destroy(obstacleObj);
            }
        }

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            float magnitude = GetComponent<Rigidbody>().velocity.magnitude;
            if (!ballSkills.mIsFire)
            {
                if (magnitude > 2.5f)
                {
                    enemy.TakeDamage(enemy.maxHealth / 2);
                }
            }
            else
            {
                enemy.TakeDamage(enemy.maxHealth);
                Instantiate(enemy.GetRoastChicken(), enemy.transform.position, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
            }
        }
    }
}