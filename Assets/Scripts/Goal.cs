using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public System.Action OnGoal;

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

        if (ball)
        {
            FindObjectOfType<BallController>().SetEnabled(false);

            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource)
                GetComponent<AudioSource>()?.Play();

            ball.GetComponent<Rigidbody>().isKinematic = true;
     
            FindObjectOfType<InputController>().enabled = false;

            OnGoal?.Invoke();
        }
    }
}
