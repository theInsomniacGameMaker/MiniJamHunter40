using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour {

    private float healthCurrent;
    [SerializeField] private float healthMax;

    protected NavMeshAgent myAgent;
    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }
    protected void Start()
    {
        ResetDefaultValues();
    }

    private void ResetDefaultValues()
    {
        healthCurrent = healthMax;
    }


    public float GetHealthCurrent()
    {
        return healthCurrent;
    }
    public float GetHealthMax()
    {
        return healthMax;
    }

    public float GetHealthPercent()
    {
        float healthPercent = healthCurrent / (float)healthMax;
        return healthPercent <= 1 ? healthPercent : 1;
    }

    public void TakeDamage(float damage)
    {
        healthCurrent -= damage;
    }
}
