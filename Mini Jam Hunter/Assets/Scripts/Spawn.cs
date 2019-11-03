using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public List<GameObject> enemyPrefabs;


    [SerializeField] private float respawnTimeMin = 15.0f;
    [SerializeField] private float respawnTimeMax = 15.0f;

    private float respawnTimeCurrent;
    private float respawnTimeElapsed;

    private bool canCreateEnemy;

    private void Start() {
        ResetSpawn();
    }
    private void Update() {
        respawnTimeElapsed += Time.deltaTime;
        if (respawnTimeElapsed >= respawnTimeMin) {
            ResetSpawn();          
        }
    }

    public void CreateEnemy() {
        if (!canCreateEnemy) {
            return;
        }

        int index = Random.Range(0, enemyPrefabs.Count);
        Instantiate(enemyPrefabs[index], transform.position, transform.rotation);
        canCreateEnemy = false;
    }
    private void ResetSpawn() {
        respawnTimeCurrent = Random.Range(respawnTimeMin, respawnTimeMax);
        canCreateEnemy = true;
        respawnTimeElapsed = 0.0f;
    }
}
