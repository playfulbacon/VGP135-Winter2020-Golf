using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    public GameObject forceQuad;
    float aimPrefabZLength;

    // Start is called before the first frame update
    void Start()
    {
        aimPrefabZLength = transform.localScale.z;
    }


    public void SetPercentage(float percentage)
    {
        forceQuad.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -(aimPrefabZLength * percentage));
    }
}
