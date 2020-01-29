using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    float currentHealth;

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
    }

    public void AddHealth(float add)
    {
        SetHealth(currentHealth + add);
    }

    public void SetHealth(float health)
    {
        currentHealth = health;

        Healthbar.Instance.slider.value = currentHealth / maxHealth;
    }
}
