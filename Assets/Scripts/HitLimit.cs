using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitLimit : MonoBehaviour
{
    UnityEngine.UI.Text hitLimitText;
    public int Hits { get; private set; }
    // Start is called before the first frame update
    void Start()
    { 
        hitLimitText.text= Hits.ToString();
    }

    private void SetHits(int set)
    {
        Hits = set;
        if (Hits >= 15)
        {
            Debug.Log(" hits >15");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
