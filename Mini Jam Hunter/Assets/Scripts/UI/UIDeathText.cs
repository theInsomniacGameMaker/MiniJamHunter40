using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDeathText : MonoBehaviour
{
    private Controls controls;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        controls = Controls.Instance;
    }

    private void Update()
    {
        text.text = "You died with a score of " + controls.score.ToString();
    }
}
