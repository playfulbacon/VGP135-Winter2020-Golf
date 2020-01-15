using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    void Start()
    {

    }

    public virtual void OnHit()
    {
        FindObjectOfType<GoalMenu>()?.SetGoalMenu(true);
    }
}
