using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParUI : MonoBehaviour
{
    public Text parUIText;

    void Start()
    {
        parUIText.text = "PAR " + FindObjectOfType<Level>().levelData.par.ToString();
    }
}
