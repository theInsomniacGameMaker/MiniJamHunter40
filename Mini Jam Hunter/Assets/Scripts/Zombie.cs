using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieType { Regular, Large };


public class Zombie : Entity
{
    [SerializeField]
    private ZombieType zombieType;
    public int damage;

    private SphereCollider sphereCollider;

    public Transform player;
    public bool foundPlayer;
    public bool willPatrol;
    protected override void Start()
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

        willPatrol = Random.Range(0, 1) == 0;

        if (willPatrol)
        {
            StartCoroutine(Patrol());
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
        
        if (healthCurrent <= 0) {
            Controls.Instance.PlaySound("Zombie Dying", transform.position);
            Controls.Instance.score += 100;
            Destroy(gameObject);
        }
    }


    IEnumerator Patrol()
    {
        while (true)
        {
            if (!foundPlayer)
            {
                RaycastHit raycastHit;
                Debug.DrawRay(new Vector3(Random.Range(-100,100), 10, Random.Range(-100, 100)), Vector3.down, Color.yellow, 10f);
                if (Physics.Raycast(new Vector3(Random.Range(-100, 100), 10, Random.Range(-100, 100)), Vector3.down, out raycastHit, 10, 1 << 9))
                {
                    if(raycastHit.transform.CompareTag("Ground"))
                    {
                        myAgent.SetDestination(raycastHit.point);
                    }
                }
            }
            yield return new WaitForSeconds(Random.Range(3, 7));
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        myAgent.SetDestination (FindObjectOfType<Player>().transform.position);
        Controls.Instance.PlaySound("Zombie Short Moan", transform.position);
        
    }
}
