using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBallOnFall : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -3)
        {
            FindObjectOfType<GameOverMenu>().SetGameOverMenu(true);
            
        }
    }
}
