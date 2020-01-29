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

    // Start is called before the first frame update
    void Start()
    {
        SetHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        SetHealth(currentHealth - damage);
        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    public void SetHealth(float health)
    {
        currentHealth = health;

        Healthbar.Instance.slider.value = currentHealth / maxHealth;
    }
}
