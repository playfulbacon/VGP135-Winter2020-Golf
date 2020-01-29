using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{   
    public float multiplier = 2.4f;
    public float waittime = 3.0f;

    private bool activated = false; 
    
     void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Ball"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    public bool isActive()
    {
        return activated;
    }

    IEnumerator Pickup(Collider player)
    {
        activated = true;
        Ball modifyball = player.GetComponentInParent<Ball>();

        //Passes in speed multiplier onto the current force and max force of the ball increasing speed
        modifyball.ModifySpeed(multiplier);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Powerup is activated for only a certain duration 
        yield return new WaitForSeconds(waittime);

        modifyball.ResetStats();
        //Debug.Log("Powerup Pickedup");

        Destroy(gameObject);
    }
}
