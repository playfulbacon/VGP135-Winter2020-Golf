using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public HealthBarController healthBar;
    public GameObject respawnpoint; 
    

     void OnCollisionEnter(Collision collision)
    {
        //Check if it collides with an object of that tag, if it does subtract 10hp
        if(collision.gameObject.CompareTag("Obstacle"))
        {
          //  print("Collided");
            if(healthBar)
            {
               // print("reached");
                healthBar.TakeDamage(10.0f);
                if (healthBar.health <= 0.0f)
                {
                    healthBar.health = healthBar.startHealth;
                    this.transform.position = respawnpoint.transform.position;                    
                }
               
            }
        }
    }
}
