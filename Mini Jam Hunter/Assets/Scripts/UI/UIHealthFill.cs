using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthFill : MonoBehaviour
{
    private Entity player;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>();
    }

    private void Update()
    {
        image.fillAmount = player.GetHealthPercent();
    }
}
