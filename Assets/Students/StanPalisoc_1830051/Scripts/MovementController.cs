using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector3 startpoint;
    Vector3 endpoint; 
    public float distance; 
    public float speed;
    Vector3 target;

    private void Start()
    {
        Random random = new Random();
        startpoint = transform.position;
        endpoint = startpoint + (transform.rotation * new Vector3(distance, 0.0f, 0.0f));
        target = endpoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == endpoint)
        {
            target = startpoint;
        }
        if (transform.position == startpoint)
        {
            target = endpoint;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
    }
}
