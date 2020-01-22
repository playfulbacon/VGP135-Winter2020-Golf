using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image healthBar;
    public float health;
    public float startHealth; 

    public void TakeDamage(float damage)
    {
        health = health - damage;
        print(health.ToString());
        healthBar.fillAmount = health / startHealth;
    }
}
