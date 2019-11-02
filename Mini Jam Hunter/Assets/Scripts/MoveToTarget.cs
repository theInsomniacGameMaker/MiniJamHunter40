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

    [SerializeField]
    private float dragSpeed = 2.0f;

    private Vector3 dragOrigin;

    private Camera myCamera;

    [SerializeField]
    private float edgeSize;

    [SerializeField]
    private float speedFactor;

    private bool followPlayer;
    private void Awake()
    {
        myCamera = GetComponent<Camera>();
    }

    private void Start()
    {
        offset = target.position - transform.position;
    }

    private void LateUpdate()
    {
        if (Controls.Instance.currentView == View.TopDown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                followPlayer = true;
            }
            if (Controls.Instance.currentView == View.TopDown && followPlayer)
            {
                transform.position = Vector3.Lerp(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(target.position.x, 0, target.position.z), Time.deltaTime * speed) - offset;
            }
            EdgeMovement();
        }

    }

    private void EdgeMovement()
    {
        if (Input.mousePosition.x > Screen.width - edgeSize)
        {
            float moveAmount = edgeSize - Screen.width + Input.mousePosition.x;
            transform.position += new Vector3(moveAmount * Time.deltaTime, 0, 0);
            followPlayer = false;
        }
        else if (Input.mousePosition.x < edgeSize)
        {
            float moveAmount = edgeSize - Input.mousePosition.x;
            transform.position -= new Vector3(moveAmount * Time.deltaTime, 0, 0);
            followPlayer = false;
        }

        if (Input.mousePosition.y > Screen.height - edgeSize)
        {
            float moveAmount = edgeSize - Screen.height + Input.mousePosition.y;
            transform.position += new Vector3(0, 0, moveAmount * Time.deltaTime);
            followPlayer = false;
        }
        else if (Input.mousePosition.y < edgeSize)
        {
            float moveAmount = edgeSize - Input.mousePosition.y;
            transform.position -= new Vector3(0, 0, moveAmount * Time.deltaTime);
            followPlayer = false;
        }

    }
}
