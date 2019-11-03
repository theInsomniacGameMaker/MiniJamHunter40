using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    Zombie parent;

    private void Awake()
    {
        parent = transform.parent.GetComponent<Zombie>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parent.foundPlayer = true;
            parent.player = other.transform;
        }
    }
}
