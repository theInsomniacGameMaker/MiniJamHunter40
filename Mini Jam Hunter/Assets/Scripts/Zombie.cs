using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieType { Regular, Large };


public class Zombie : Entity
{
    [SerializeField]
    private ZombieType zombieType;

    private SphereCollider sphereCollider;

    Transform player;
    private bool foundPlayer;
    private void Start()
    {
        base.Start();
        sphereCollider = transform.GetChild(0).GetComponent<SphereCollider>();

        if (sphereCollider == null)
        {
            sphereCollider = transform.GetChild(0).gameObject.AddComponent<SphereCollider>();
        }

        sphereCollider.isTrigger = true;

        switch (zombieType)
        {
            case ZombieType.Regular:
                sphereCollider.radius = Random.Range(15.0f, 25.0f);
                myAgent.speed = Random.Range(8.0f, 12.0f);
                break;
            case ZombieType.Large:
                sphereCollider.radius = Random.Range(25.0f, 35.0f);
                myAgent.speed = Random.Range(4.0f, 8.0f);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (foundPlayer)
        {
            myAgent.SetDestination(player.position);
            RaycastHit raycastHit;
            if (Physics.Raycast(transform.position, player.position - transform.position, out raycastHit, 1000.0f))
            {
                if (!raycastHit.transform.CompareTag("Player"))
                {
                    foundPlayer = false;
                }
            }
            else
            {
                    foundPlayer = false;
            }

            Debug.DrawRay(transform.position, player.position - transform.position, Color.red, 5.0f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foundPlayer = true;
            player = other.transform;
        }
    }
}
