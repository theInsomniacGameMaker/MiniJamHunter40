using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCountdown : MonoBehaviour {
    [SerializeField] private float countdownDuration;

    [SerializeField] private Text textCountdown;
    private float countdownDurationOriginal;

    void Start() {
        countdownDurationOriginal = countdownDuration;
    }

    void Update() {
        countdownDuration -= Time.deltaTime;
        textCountdown.text = countdownDuration.ToString();
        if (countdownDuration <= 0.0f) {
            gameObject.SetActive(false);
        }
    }
    void OnEnable() {
        countdownDuration = countdownDurationOriginal;
    }
}
