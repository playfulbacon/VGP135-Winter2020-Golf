using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Text highScoreText;
    
    private int highScore = 10;
    private int currentScore; 
    private GoalMenu goalManager;

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("highScore", highScore);
        goalManager = FindObjectOfType<GoalMenu>();
        currentScore = goalManager.GetFinalScore();
   
        DisplayHighScore();
     
    }

    public void DisplayHighScore()
    {
        CheckScore();
        highScoreText.text = "HighScore: " + highScore.ToString();
    }


    private void OnDestroy()
    {
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

    public void CheckScore()
    {
        if (FindObjectOfType<GoalMenu>().isActiveAndEnabled)
        {
            if (currentScore < highScore)
            {
                highScore = currentScore;
            }
        }
    }
}
