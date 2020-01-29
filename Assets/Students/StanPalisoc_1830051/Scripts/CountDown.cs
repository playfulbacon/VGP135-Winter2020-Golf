using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private float timeLeft = 3.0f;
    public Text countdown; 
    // Start is called before the first frame update
    void Start()
    {    
       timeLeft = this.GetComponentInChildren<PowerUp>().waittime;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<PowerUp>().isActive())
        {
            StartCoroutine(DecrementTime());
        }
        countdown.text = ("" + timeLeft);      
    }

    IEnumerator DecrementTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--; 
        }                   
        
    }

}
