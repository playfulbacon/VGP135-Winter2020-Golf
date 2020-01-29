using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{   
    public float multiplier = 2.4f;
    public float waittime = 3.0f;

    private bool activated = false;
    public UnityEngine.UI.Text countdown;

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
        modifyball.SetSpeedMultipler(multiplier);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Powerup is activated for only a certain duration 
        countdown.gameObject.SetActive(true);
        float t = 0;
        while (t < waittime)
        {
            t += Time.deltaTime;
            countdown.text = (waittime - t).ToString("F1");
            yield return null;
        }
        countdown.gameObject.SetActive(false);

        modifyball.ResetSpeedMultiplier();
        activated = false;        
        //Debug.Log("Powerup Pickedup");

        Destroy(gameObject);
    }
}
