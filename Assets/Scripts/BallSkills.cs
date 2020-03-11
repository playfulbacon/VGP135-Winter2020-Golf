using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSkills : MonoBehaviour
{
    Ball ball;
    ParticleSystem ps;
    public bool fireSkill = false;

    private void Awake()
    {
        ball = GetComponent<Ball>();
        ps = ball.GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {
        if (ps != null)
        {
            Instantiate(ps);
            ps.Stop();
        }
    }
    
    void Update()
    {
        if (!fireSkill)
        {
            if (Input.GetKeyDown("1"))
            {
                ps.Play();
                fireSkill = true;
            }
        }
        else
        {
            if (Input.GetKeyDown("1"))
            {
                ps.Stop();
                fireSkill = false;
            }
        }
        ps.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
    }
}
