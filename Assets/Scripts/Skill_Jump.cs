using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Jump : MonoBehaviour
{
    int currentLevel = 0;
    float jumpVelocity = 0.0f;
    float maxDistance = 0.251f;
    bool isJumping = false;
    bool toJump = false;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SetSkillLevel(currentLevel + 1);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            SetSkillLevel(currentLevel - 1);
        }

        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, maxDistance))
        {
            isJumping = false;
        }

        if (currentLevel > 0 && toJump && !isJumping)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
            isJumping = true;
            toJump = false;
        }
    }

    void Update()
    {
        if (currentLevel > 0 && !isJumping && Input.GetButtonDown("Jump"))
        {
            toJump = true;
        }
    }

    public void SetSkillLevel(int level)
    {
        currentLevel = Mathf.Clamp(level, 0, 3);
        if (currentLevel > 0)
        {
            jumpVelocity = 2.0f + (currentLevel * 3.0f);
        }
        else
        {
            jumpVelocity = 0.0f;
        }
    }
}
