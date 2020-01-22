using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    float health = 0.0f;
    public Slider slider;

    void Start()
    {
        SetHealth(maxHealth);
    }

    public void SetHealth(float set)
    {
        health = set;
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateUI();
    }

    private void TakeDamage(float damage)
    {
        SetHealth(health - damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            TakeDamage(obstacle.damage);
        }
    }

    private void UpdateUI()
    {
        slider.value = Mathf.Lerp(0f, 1f, health / maxHealth);

        if (health <= 0.0f)
        {
            //Reset level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
