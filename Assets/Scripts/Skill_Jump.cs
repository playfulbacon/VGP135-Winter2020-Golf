using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Jump : MonoBehaviour
{
    public KeyCode levelUpKey = KeyCode.J; 
    public KeyCode levelDownKey = KeyCode.K;

    int currentLevel = 0;
    float jumpForce = 0.0f;
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

        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, maxDistance))
        {
            isJumping = false;
        }

        if (currentLevel > 0 && toJump && !isJumping)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isJumping = true;
            toJump = false;
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
            jumpForce = 2.0f + (currentLevel * 3.0f);
        }
        else
        {
            jumpForce = 0.0f;
        }
    }
}
