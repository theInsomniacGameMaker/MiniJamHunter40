using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Gun
{
    public string name;
    public float damage;
    public float fireRate;
    public float range;
}

public class Shoot : MonoBehaviour
{
    public Camera fpsCamera;

    private float nextTimeToFire = 0.0f;

    [SerializeField]
    private Gun[] guns;

    private int currentSelected = 0;

    private void Start()
    {
         
    }

    private void Update()
    {
        if (Controls.Instance.currentView == View.FirstPerson)
        {
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1.0f / guns[currentSelected].fireRate;
                Fire();
            }
        }
    }

    private void Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, guns[currentSelected].range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
