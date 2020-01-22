using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
	public GameObject levelOverScreen;

	void Start()
	{
		levelOverScreen.SetActive(false);
	}

	public void CompleteLevel(int timeToReset)
	{
		//Invoke("RestartLevel", timeToReset);
		levelOverScreen.SetActive(true);
	}

    public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadLevel(int level)
	{
		SceneManager.LoadScene(level);
	}
}
