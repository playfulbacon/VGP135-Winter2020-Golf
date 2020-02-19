﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    private GoalMenu goalMenu;
    private LevelSelect levelSelect;

    void Start()
    {
        goalMenu = FindObjectOfType<GoalMenu>();
        levelSelect = FindObjectOfType<LevelSelect>();
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

            
            goalMenu?.SetScoreText();
            goalMenu?.SetGoalMenu(true);
            
        }
    }
}
