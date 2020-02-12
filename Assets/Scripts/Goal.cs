using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponentInParent<Ball>();
        AudioSource audioSource = GetComponent<AudioSource>();

        if (ball)
        {
            if (audioSource)
            {
                GetComponent<AudioSource>()?.Play();
            }
            ball.GetComponent<Rigidbody>().isKinematic = true;
            FindObjectOfType<GoalMenu>()?.SetGoalMenu(true);
        }
    }
}
