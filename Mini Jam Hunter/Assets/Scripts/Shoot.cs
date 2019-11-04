using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Gun
{
    public string name;
    public int damage;
    public float fireRate;
    public float range;
    public int maxAmmo;
    [HideInInspector]
    public int currentAmmo;
    public GameObject gunMesh;
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
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].currentAmmo = guns[i].maxAmmo;
        }
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

            if (Input.mouseScrollDelta.y>0.5f)
            {
                currentSelected++;
                currentSelected = currentSelected % guns.Length;
                guns[currentSelected].gunMesh.SetActive(true);
                TurnAllMeshesOff();
            }
        }
    }

    private void Fire()
    {
        if (guns[currentSelected].maxAmmo>=1)
        {
            RaycastHit hit;

            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, guns[currentSelected].range, ~(1 << 10)))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.CompareTag("Zombie"))
                {
                    hit.transform.GetComponent<Zombie>().TakeDamage(guns[currentSelected].damage);
                }
            }
            guns[currentSelected].currentAmmo--;
        }
    }

    public void RefillAmmo()
    {
        guns[currentSelected].currentAmmo = guns[currentSelected].maxAmmo;
    }

    private void TurnAllMeshesOff()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].gunMesh.SetActive(false);
        }
    }

    public int GetAmmoCount() {
        return guns[currentSelected].currentAmmo;
    }
}
