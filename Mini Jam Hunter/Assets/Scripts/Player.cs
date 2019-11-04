using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    float nextTimeToTakeDamage = 0.0f;
    float damageInterval = 2.0f;
    

    protected override void Awake() {
        base.Awake();
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Zombie"))
        {
            Debug.Log("Collided with Zombie");
            if (nextTimeToTakeDamage < Time.time)
            {
                TakeDamage(collision.gameObject.GetComponent<Zombie>().damage);
                nextTimeToTakeDamage = Time.time + damageInterval;
                Controls.Instance.PlaySound("Player Pain 1", transform.position);
            }
        }
    }

    private void Update()
    {
        if (healthCurrent<=0)
        {
            GameObject.FindGameObjectWithTag("UIDeath").SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("HealthPack"))
        {
            Debug.Log("Got HEalth PAck");
            Heal(100);
            Destroy(collision.transform.gameObject);
            Controls.Instance.PlaySound("Health Pack Revive Long", transform.position);
        }
        else if (collision.transform.CompareTag("AmmoBox"))
        {
            Debug.Log("Refill Ammo");
            FindObjectOfType<Shoot>().RefillAmmo();
            Destroy(collision.transform.gameObject);
            Controls.Instance.PlaySound("Health Pack Grab", transform.position);
        }
    }
}
