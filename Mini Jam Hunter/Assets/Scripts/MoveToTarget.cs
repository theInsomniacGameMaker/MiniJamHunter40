using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed;
    private void Start()
    {
        offset = target.position - transform.position;
    }

    private void LateUpdate()
    {
        if (Controls.Instance.isMoving && Controls.Instance.currentView == View.TopDown)
        {
            transform.position = Vector3.Lerp(new Vector3 (transform.position.x, 0, transform.position.z), new Vector3(target.position.x, 0, target.position.z), Time.deltaTime * speed) - offset;
        }
    }
}
