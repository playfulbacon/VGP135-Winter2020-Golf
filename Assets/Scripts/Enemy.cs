﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State { Idle, Pursue, Attack, Knockback, Goal };
    State state = State.Idle;

    public int xpValue = 1;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float pursueRange = 4f;

    [SerializeField]
    float startAttackRange = 1f;

    [SerializeField]
    float attackRange = 1f;

    [SerializeField]
    float pursueSpeed = 1f;

    [SerializeField]
    float attackDamage = 10f;

    float health;

    public float maxHealth = 100f;

    Ball[] balls;

    Ball pursuingBall;

    Rigidbody rb;

    EnemyAnimatorHelper enemyAnimatorHelper;

    bool isAgro = false;

    GameObject roastChicken;

    private void Awake()
    {
        enemyAnimatorHelper = GetComponentInChildren<EnemyAnimatorHelper>();
        enemyAnimatorHelper.OnAttack += OnAttack;
        enemyAnimatorHelper.OnAttackComplete += OnAttackComplete;
        health = maxHealth;

        FindObjectOfType<Goal>().OnGoal += Goal;

        roastChicken = Resources.Load("prefabs/roastChicken") as GameObject;
    }

    private void Goal()
    {
        state = State.Goal;
        animator.SetBool("Run", false);
        animator.SetBool("Eat", false);
        pursuingBall = null;
    }

    public bool WillKill(float damage)
    {
        float newHealth = health;
        newHealth -= damage;
        return newHealth <= 0;
    }

    public float TakeDamage(float damage, bool isBallOnFire = false)
    {
        health -= damage;

        Color c = Color.black;
        c.r = Mathf.Lerp(0.75f, 0f, health / maxHealth);
        GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", c);

        isAgro = true;

        if (isAgro)
        {
            pursueRange *= 2;
            attackDamage *= 2;
            pursueSpeed *= 2;
        }

        if (health <= 0)
        {
            Kill(isBallOnFire);
            return 0;
        }
            
        if (state != State.Knockback)
        {
            OnAttackComplete();
            state = State.Knockback;
            Invoke("ExitKnockback", 0.5f);
        }

        return health;
    }

    void Kill(bool doRoastChicken = false)
    {
        if (doRoastChicken)
            Instantiate(roastChicken, transform.position, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));

        FindObjectOfType<Goal>().OnGoal -= Goal;
        Destroy(gameObject);
    }

    void OnAttack()
    {
        if (state == State.Goal)
            return;

        if (Vector3.Distance(transform.position, pursuingBall.transform.position) <= attackRange)
            pursuingBall.GetComponent<BallHealth>().TakeDamage(attackDamage);
    }

    void OnAttackComplete()
    {
        animator.SetBool("Eat", false);
        pursuingBall = null;
        state = State.Idle;
    }

    void ExitKnockback()
    {
        state = State.Idle;
    }

    void Start()
    {
        balls = FindObjectsOfType<Ball>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        TextMesh debugText = GetComponentInChildren<TextMesh>();
        if (debugText)
            debugText.text = state.ToString();

        switch (state)
        {
            case State.Idle:
                Update_StateIdle();
                break;

            case State.Pursue:
                Update_StatePursue();
                break;

            case State.Attack:
                Update_StateAttack();
                break;

            default:
                break;
        }
    }


    void Update_StateAttack()
    {
        if (Vector3.Distance(transform.position, pursuingBall.transform.position) <= attackRange)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(pursuingBall.transform.position - transform.position), Time.deltaTime * 180f * (isAgro? 2 : 1));
    }

    void Update_StateIdle()
    {
        Ball closestBall = balls[0];
        foreach (Ball ball in balls)
        {
            if (Vector3.Distance(transform.position, ball.transform.position) < Vector3.Distance(transform.position, closestBall.transform.position))
                closestBall = ball;
        }

        if (Vector3.Distance(transform.position, closestBall.transform.position) <= pursueRange)
        {
            if (pursuingBall == null)
            {
                pursuingBall = closestBall;
                animator.SetBool("Run", true);
                state = State.Pursue;
            }
        }
    }

    void Update_StatePursue()
    {
        if (pursuingBall == null)
            return;

        Vector3 targetPosition = pursuingBall.transform.position + ((transform.position - pursuingBall.transform.position).normalized * 1f);
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * pursueSpeed);
        rb.MovePosition(newPosition);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(pursuingBall.transform.position - transform.position), Time.deltaTime * 180f);
        
        if (Vector3.Distance(transform.position, pursuingBall.transform.position) > pursueRange)
        {
            pursuingBall = null;
            animator.SetBool("Run", false);

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            state = State.Idle;

            return;
        }

        if (Vector3.Distance(transform.position, pursuingBall.transform.position) <= startAttackRange)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Eat", true);

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            state = State.Attack;
        }
    }
}
