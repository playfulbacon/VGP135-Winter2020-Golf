using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public System.Action<Enemy> OnEnemyKill;
    BallHealth ballHealth;
    Skill_Fire ballFire;

    void Start()
    {
        ballHealth = GetComponent<BallHealth>();
        ballFire = GetComponent<Skill_Fire>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obstacleObj = collision.gameObject;
        Obstacle obstacle = obstacleObj.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            if (!ballFire.mIsFire)
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

            if (magnitude > 2.5f)
            {
                float damage = ballFire.mIsFire ? (enemy.maxHealth) : (enemy.maxHealth / 2f);
                float enemyHealth = enemy.TakeDamage(damage, ballFire.mIsFire);

                if (enemyHealth == 0)
                    OnEnemyKill?.Invoke(enemy);
            }
        }
    }
}