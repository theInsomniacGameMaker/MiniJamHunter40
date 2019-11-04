using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthText : MonoBehaviour
{
    private Entity player;
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>();
    }

    private void Update()
    {
        text.text = player.GetHealthCurrent().ToString();
    }
}
