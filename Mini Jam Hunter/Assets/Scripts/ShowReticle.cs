using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowReticle : MonoBehaviour
{
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Update()
    {
        if (Controls.Instance.currentView == View.FirstPerson)
        {
            image.enabled = true;
        }
        else if (Controls.Instance.currentView == View.TopDown)
        {
            image.enabled = false;
        }
    }
}
