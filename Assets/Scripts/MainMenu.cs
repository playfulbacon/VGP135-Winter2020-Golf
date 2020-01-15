using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startScene;
    public GameObject startUI;
    public GameObject loginUI;
    public InputField inputName;
    public Text text;

    private string playerName;

    void Start()
    {
        startUI.SetActive(false);
        loginUI.SetActive(true);

    }

    public void Login()
    {
        playerName = inputName.text;
        loginUI.SetActive(false);
        startUI.SetActive(true);
        text.text = "Welcome " + playerName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public string GetPlayerName()
    {
        return playerName;
    }
}
