using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSkills : MonoBehaviour
{
    Ball ball;
    
    ParticleSystem ps;
    private bool isFire;

    public bool mIsFire
    {
        get { return isFire; }
        set { isFire = value; }
    }

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
        // Fire Skill
        if (!isFire)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ps.Play();
                isFire = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ps.Stop();
                isFire = false;
            }
        }
        ps.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
    }
}
