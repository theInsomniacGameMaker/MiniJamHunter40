using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera fpsCamera;

    [SerializeField]
    private float range = 100.0f;

    [SerializeField]
    private float damage;

    [SerializeField]
    private float fireRate = 15.0f;

    private float nextTimeToFire = 0.0f;

    private void Start()
    {
         
    }

    private void Update()
    {
        if (Controls.Instance.currentView == View.FirstPerson)
        {
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1.0f / fireRate;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
