using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : MonoBehaviour
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
        text.text = controls.score.ToString();
    }
}
