using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmoText : MonoBehaviour
{
    private Shoot shoot;
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        shoot = GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>();
    }

    private void Update()
    {
        text.text = shoot.GetAmmoCount().ToString();
    }
}
