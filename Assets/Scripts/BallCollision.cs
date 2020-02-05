using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private BallHealth saveBallHealth;

    // Start is called before the first frame update
    void Start()
    {
        saveBallHealth = GetComponent<BallHealth>();
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
            saveBallHealth.TakeDamage(obstacle.damage);
        }
    }
}
