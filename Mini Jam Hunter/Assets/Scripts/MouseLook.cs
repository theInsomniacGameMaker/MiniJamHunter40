using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity = 100.0f;
    [SerializeField]
    private float clampAngle = 80.0f;

    private float rotationY = 0.0f;
    private float rotationX = 0.0f;

    [SerializeField]
    private bool allowRotation = false;

    private void OnEnable()
    {
        Controls.OnMiddleMouseButtonClicked += TurnOffRotation;
        Controls.OnRightMouseButtonClicked += ResetRotation;
    }

    private void OnDisable()
    {
        Controls.OnMiddleMouseButtonClicked -= TurnOffRotation;
        Controls.OnRightMouseButtonClicked -= ResetRotation;
    }

    private void Start()
    {
        Vector3 startRotation = transform.localRotation.eulerAngles;
        rotationY = startRotation.y;
        rotationX = startRotation.x;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!allowRotation)
        {
            Rotate();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            allowRotation = !allowRotation;
        }
    }

    public void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotationY += mouseX * mouseSensitivity * Time.deltaTime;
        rotationX += mouseY * mouseSensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
        transform.rotation = localRotation;

    }

    private void TurnOffRotation()
    {
        allowRotation = !allowRotation;
        if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void ResetRotation()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

}
