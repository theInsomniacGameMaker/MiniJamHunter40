using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity = 100.0f;
    [SerializeField]
    private float clampAngle = 80.0f;

    private float rottationY = 0.0f;
    private float rotationX = 0.0f;

    [SerializeField]
    private bool allowMovement = false;

    private void Start()
    {
        Vector3 startRotation = transform.localRotation.eulerAngles;
        rottationY = startRotation.y;
        rotationX = startRotation.x;
    }

    private void Update()
    {
        if (!allowMovement)
        {
            Rotate();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            allowMovement = !allowMovement;
        }
    }

    public void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rottationY += mouseX * mouseSensitivity * Time.deltaTime;
        rotationX += mouseY * mouseSensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotationX, rottationY, 0.0f);
        transform.rotation = localRotation;

    }
}
