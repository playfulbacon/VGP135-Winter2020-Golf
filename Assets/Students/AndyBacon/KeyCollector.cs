using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public bool hasKey = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Key key = other.GetComponentInParent<Key>();
        if (key)
        {
            Destroy(key.gameObject);
            hasKey = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        LockedDoor lockedDoor = collision.gameObject.GetComponentInParent<LockedDoor>();
        if (hasKey && lockedDoor)
        {
            Destroy(lockedDoor.gameObject);
        }
    }
}
