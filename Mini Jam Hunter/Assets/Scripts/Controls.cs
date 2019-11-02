using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField]
    private Camera firstPerson, topDown;

    public delegate void MiddleMouseButtonClick();
    public static event MiddleMouseButtonClick OnMiddleMouseButtonClicked;
    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            firstPerson.enabled = !firstPerson.enabled;
            topDown.enabled = !topDown.enabled;

            OnMiddleMouseButtonClicked();
        }
    }
}
