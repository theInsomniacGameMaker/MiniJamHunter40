using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField] private Entity entity;
    [SerializeField] private RectTransform healthCurrent;

    private float scaleY;
    private float scaleZ;

    private void Start() {
        scaleY = healthCurrent.localScale.y;
        scaleZ = healthCurrent.localScale.z;
    }

    private void Update() {
        healthCurrent.localScale = new Vector3(entity.GetHealthPercent(), scaleY, scaleZ);
    }
}
