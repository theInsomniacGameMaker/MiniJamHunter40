using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour {

    private int healthCurrent;
    [SerializeField] private int healthMax;

    protected NavMeshAgent myAgent;
    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }
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
