using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State { Idle,Pursue, Attack};
    State state = State.Idle;
    Ball[] balls;
    Ball pursuingBall;
    Rigidbody rb;
    enemyanimatorhelper enemyanimatorhelper;
    private void Awake()
    {
        enemyanimatorhelper = GetComponentInChildren<enemyanimatorhelper>();
        enemyanimatorhelper.OnAttack += OnAttacke;
        enemyanimatorhelper.onAttackComplate += OnAttackComplate;
    }
    void OnAttacke()
    {

    }
    void OnAttackComplate()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        balls = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
