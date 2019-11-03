using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    private int healthCurrent;
    [SerializeField] private int healthMax;

    protected void Start() {
        ResetDefaultValues();
    }

    private void ResetDefaultValues() {
        healthCurrent = healthMax;
    }


    public int GetHealthCurrent() {
        return healthCurrent;
    }
    public int GetHealthMax() {
        return healthMax;
    }

    public float GetHealthPercent() {
        float healthPercent = healthCurrent / (float)healthMax;
        return healthPercent <= 1 ? healthPercent : 1;
    }
}
