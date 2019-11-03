using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlimitedWave : MonoBehaviour {
    public List<Spawn> spawns;

    private void Update() {
        foreach (Spawn spawn in spawns) {
            spawn.CreateEnemy();
        }
    }
}
