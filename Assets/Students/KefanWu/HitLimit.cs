using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitLimit : MonoBehaviour
{
    UnityEngine.UI.Text hitLimitText;
    public int Hits { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        FindObjectOfType<BallController>().OnHit += OnHit;
    }
    void Start()
    {
        hitLimitText = GetComponent<UnityEngine.UI.Text>();
        hitLimitText.text = Hits.ToString();
    }
    void OnHit(Vector3 hitdirection)
    {
        SetHits(Hits+1);
    }

    public void SetHits(int set)
    {
        Hits = set;
        if (Hits >= 15)
        {
            Debug.Log(" hits >15");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}