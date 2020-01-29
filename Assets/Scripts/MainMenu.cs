using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
