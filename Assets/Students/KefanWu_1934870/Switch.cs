using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour

{
    public Switch toggleswitch;
    GameObject obstacles;

    public void OnCollisionEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            obstacles = GameObject.FindGameObjectWithTag("obstacles");
            obstacles.SetActive(false);
        }
    }
}
