using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Zombie"))
        {
            Debug.Log("Collided with Zombie");
            TakeDamage(0.35f);
        }
    }

}
