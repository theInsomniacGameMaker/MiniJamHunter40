using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTimeY : MonoBehaviour {

    public float speedRotate;
    public Space space;

    public void Update() {
        transform.Rotate(Vector3.up, speedRotate * Time.deltaTime, space);
    }
}
