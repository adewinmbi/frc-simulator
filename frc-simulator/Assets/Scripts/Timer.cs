using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    [SerializeField] private Text timerText, redPointText, bluePointText;
    private int redPoints = 0, bluePoints = 0;
    private float timer = 120;

    public bool isGameFinished = false; // Check this variable during Update to see if game is finished

    public void SetTimer(int seconds) { // Call this on start
        this.timer = seconds;
    }
    
    private void Start() {
        timerText.text = FormatTime(timer);
        redPointText.text = redPoints.ToString();
        bluePointText.text = bluePoints.ToString();
    }

    private void Update() {
        if (timer > 1) {
            timer -= Time.deltaTime;
            timerText.text = FormatTime(timer);
        } else {
            isGameFinished = true;
        }
    }

    private string FormatTime(float timer) {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    // Getters and setters

    public void SetBluePoints(int points) {
        bluePoints = points;
        bluePointText.text = points.ToString();
    }

    public int GetBluePoints() {
        return bluePoints;
    }

    public void SetRedPoints(int points) {
        redPoints = points;
        redPointText.text = points.ToString();
    }

    public int GetRedPoints() {
        return redPoints;
    }

}
