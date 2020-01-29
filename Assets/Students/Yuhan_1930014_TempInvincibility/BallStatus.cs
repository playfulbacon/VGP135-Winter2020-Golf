using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallStatus : MonoBehaviour
{
    [SerializeField]
    GameObject FillEffect;
    float mTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mTimer -= 1 * Time.deltaTime;
        if (mTimer > 0)
        {
            print((int)mTimer);
            FillEffect.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
            GetComponent<BallHealth>().mInvincible = true;
        }
        else
        {
            FillEffect.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            GetComponent<BallHealth>().mInvincible = false;
        }
    }

    public void Invincibility(float time)
    {
        mTimer = time;
    }
}
