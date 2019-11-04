using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCountdown : MonoBehaviour {
    [SerializeField] private float countdownDuration;
    [SerializeField] private Text textCountdown;

    private float countdownDurationOriginal;
    private GameObject waveSpawner;

    void Start() {
        countdownDurationOriginal = countdownDuration;
        waveSpawner = GameObject.FindGameObjectWithTag("WaveSpawner");
        waveSpawner.SetActive(false);
    }

    void Update() {
        countdownDuration -= Time.deltaTime;
        textCountdown.text = ((int)countdownDuration).ToString();
        if (countdownDuration <= 0.0f) {
            gameObject.SetActive(false);
            waveSpawner.SetActive(true);
        }
    }
}
