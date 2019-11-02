using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public List<GameObject> enemyPrefabs;

    public void SpawnEnemy() {
        int index = Random.Range(0, enemyPrefabs.Count);
        Instantiate(enemyPrefabs[index], transform.position, transform.rotation);
    }
}
