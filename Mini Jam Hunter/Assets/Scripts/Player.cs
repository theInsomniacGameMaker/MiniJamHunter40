using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Zombie"))
        {
            Debug.Log("Collided with Zombie");
        }
    }

}
