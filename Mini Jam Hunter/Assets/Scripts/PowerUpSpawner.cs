using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SpawnerType { Health, Ammo };
public class PowerUpSpawner : MonoBehaviour
{
    GameObject justSpawned = null;
    public float minTime, maxTime;
    public GameObject healthPack, ammoBox;
    public SpawnerType spawnerType;
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if (justSpawned == null)
            {
                yield return new WaitForSeconds(Random.Range(minTime, maxTime));
                justSpawned = Instantiate(spawnerType == SpawnerType.Ammo ? ammoBox : healthPack, transform.position, Quaternion.identity);
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }

}
