using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBallOnFall : MonoBehaviour
{
    public float DeathY = -3;
    void Update()
    {
        if(transform.position.y < DeathY)
        {
            FindObjectOfType<GameOverMenu>().SetGameOverMenu(true);
        }
    }
}
