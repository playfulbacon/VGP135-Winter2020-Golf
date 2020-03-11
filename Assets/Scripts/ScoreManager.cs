using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;

public class ScoreManager : MonoBehaviour
{
    public enum Score
    {
        [Description("Albatross")]
        Albatross = -3,
        [Description("Eagle")]
        Eagle = -2,
        [Description("Birdie")]
        Birdie = -1,
        [Description("Par")]
        Par = 0,
        [Description("Bogie")]
        Bogie = 1,
        [Description("Double Bogie")]
        DoubleBogie = 2,
        [Description("Triple Bogie")]
        TripleBogie = 3,
    }

    public Score GetScore()
    {
        return (Score)FindObjectOfType<HitCounter>().Hits - FindObjectOfType<LevelManager>().LevelPar;
    }
}
