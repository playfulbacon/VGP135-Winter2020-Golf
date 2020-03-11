using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Fire : MonoBehaviour
{
    public KeyCode levelUpKey = KeyCode.F;
    public KeyCode levelDownKey = KeyCode.G;

    float fireDuration = 0.0f;
    float fireCooldown = 5.0f;

    Ball ball;
    ParticleSystem ps;
    int currentLevel;
    float stopFireTime = 0.0f;
    float fireReadyTime = 0.0f;

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
        if (Input.GetKeyDown(levelUpKey))
        {
            SetSkillLevel(currentLevel + 1);
        }
        else if (Input.GetKeyDown(levelDownKey))
        {
            SetSkillLevel(currentLevel - 1);
        }

        if (!isFire)
        {
            if (currentLevel > 0 && Input.GetKeyDown(KeyCode.Alpha1) && Time.time > fireReadyTime)
            {
                ps.Play();
                isFire = true;
                fireReadyTime = Time.time + fireCooldown + fireDuration;
                stopFireTime = Time.time + fireDuration;
            }
        }
        else
        {
            if (Time.time > stopFireTime)
            {
                ps.Stop();
                isFire = false;
            }
        }

        ps.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
    }

    public void SetSkillLevel(int level)
    {
        currentLevel = Mathf.Clamp(level, 0, 3);
        fireDuration = currentLevel;
    }

    public float GetTimeUntilCooldown()
    {
        return Mathf.Clamp(fireReadyTime - Time.time, 0.0f, fireCooldown);
    }
}
