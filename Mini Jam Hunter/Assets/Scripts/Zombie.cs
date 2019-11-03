using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieType { Regular, Large };


public class Zombie : Entity
{
    [SerializeField]
    private ZombieType zombieType;

    private SphereCollider sphereCollider;
    private void Start()
    {
        base.Start();
        sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider==null)
        {
            sphereCollider = gameObject.AddComponent<SphereCollider>();
        }
        sphereCollider.isTrigger = true;

        switch (zombieType)
        {
            case ZombieType.Regular:
                sphereCollider.radius = Random.Range(15.0f, 25.0f);
                break;
            case ZombieType.Large:
                sphereCollider.radius = Random.Range(25.0f, 35.0f);
                break;
            default:
                break;
        }
    }
}
