using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();

        HealBox healbox = collision.gameObject.GetComponent<HealBox>();

        if (obstacle != null)
        {
            GetComponent<BallHealth>().TakeDamage(obstacle.damage);
        }

        if (healbox != null)
        {
            GetComponent<BallHealth>().AddHealth(healbox.heal);
            Destroy(collision.gameObject);
        }
    }
}
