using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [SerializeField]
    GameObject GolfBall;

    [SerializeField]
    GameObject PickUpBall;
    float timer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == GolfBall)
        {
            Activate();
            Destroy(PickUpBall);
        }
    }

    void Activate()
    {
        GolfBall.GetComponent<BallStatus>().Invincibility(timer);
    }
}
