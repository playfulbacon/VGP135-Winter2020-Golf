using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private float timeLeft;
    public Text countdown; 
    // Start is called before the first frame update
    void Start()
    {    
       timeLeft = this.GetComponentInChildren<PowerUp>().waittime * 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<PowerUp>().isActive())
        {
            countdown.text = ("" + timeLeft);
            StartCoroutine(DecrementTime());
        }
        
    }

    IEnumerator DecrementTime()
    {
        while(timeLeft > 0)
        {
            timeLeft--;
            yield return new WaitForSeconds(1);     
        }                   
        
    }

}
