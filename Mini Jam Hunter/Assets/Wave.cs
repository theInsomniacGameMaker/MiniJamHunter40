using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
    public List<Spawn> spawns;

    void Start() {
        foreach (Spawn spawn in spawns) {
            spawn.SpawnEnemy();
        }
    }
}
