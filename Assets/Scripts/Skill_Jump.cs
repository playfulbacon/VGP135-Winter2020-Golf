using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Jump : MonoBehaviour
{
    public float jumpVelocity;

    float maxDistance = 0.5f;
    bool isJumping = false;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, maxDistance))
        {
            isJumping = false;
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector3(0, jumpVelocity, 0), ForceMode.Impulse);
            isJumping = true; 
        }
    }


}
