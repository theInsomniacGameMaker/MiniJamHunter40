using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCountdown : MonoBehaviour {
    [SerializeField] private float countdownDuration;

    private Text text;
    private float countdownDurationOriginal;

    void Start() {
        text = GetComponent<Text>();
        countdownDurationOriginal = countdownDuration;
    }

    void Update() {
        countdownDuration -= Time.deltaTime;
        text.text = ((int)countdownDuration).ToString();
        if (countdownDuration <= 0.0f) {
            gameObject.SetActive(false);
        }
    }
    void OnEnable() {
        countdownDuration = countdownDurationOriginal;
    }
}
