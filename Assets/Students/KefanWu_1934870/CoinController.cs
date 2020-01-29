
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    public float SpinSpeed;
    private float startHeight = 0.0f;
    private float bounce = 0.0f;
    private bool collected = false;


    // Update is called once per frame
    void Update()
 
    {
        transform.Rotate(Vector3.right, SpinSpeed * Time.deltaTime);
        if (collected)
        {
            bounce += Time.deltaTime * 10.0f;
            Vector3 postion = transform.position;
            postion.y = startHeight + Mathf.Sin(bounce) * 2.0f;
            transform.position = postion;
            if (bounce >= Mathf.PI)
            {
                gameObject.SetActive(false);
            }
        }
    }


    public void Collect()
    {
        startHeight = transform.position.y;
        SpinSpeed *= 10.0f;
        collected = true;
    }
}