using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField]
    Text ScoreUI;

    int MaxScore = 1500;
    int LevelCompleteScore = 500;
    int HitScore = 1000;
    int EndScore = 0;

    void Start()
    {

    }

    public void SetScore(int hits)
    {     
        hits -= hits * 2;

        if (HitScore <= 0)
        {
            HitScore = 0;
        }

        EndScore = LevelCompleteScore + HitScore;

        if (EndScore >= MaxScore)
        {
            EndScore = MaxScore;
        }

        ScoreUI.text = "SCORE:" + EndScore.ToString();
    }
}
