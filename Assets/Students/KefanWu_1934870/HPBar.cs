using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPBar : MonoBehaviour
{
    public Slider slider;
    public float health;
    public float resultHealth;
    private bool obstacles = false;





    void Start()
    {
        slider.maxValue = 100;
        slider.minValue = 0;
        slider.value = slider.maxValue;
        health = slider.value;
        resultHealth = health;

    }


    void Update()
    {
        if(obstacles)
        {
            resultHealth = slider.value - 10 < slider.value ? slider.minValue : slider.value - 10;
            obstacles = false;
        }
        health = Mathf.Lerp(health, resultHealth, 0.05f);
        slider.value = health;
        if(slider.value<=0.01)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }
    public void ReduceHealth()
    {
        obstacles = true;
    }

}
