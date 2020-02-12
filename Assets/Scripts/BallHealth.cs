using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BallHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    float currentHealth;

    public Action OnDeath;
    private GameOverMenu gameOverMenu;
    void Start()
    {
        SetHealth(maxHealth);
    }
    
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        SetHealth(currentHealth - damage);
        if (currentHealth <= 0)
        {
            GetComponent<Ball>().gameObject.SetActive(false);
            OnDeath?.Invoke();
        }
    }

    public void SetHealth(float health)
    {
        currentHealth = health;

        Healthbar.Instance.slider.value = currentHealth / maxHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }
}
