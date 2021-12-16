using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class _gameManager : MonoBehaviour
{
    public float timeRemaining, minutes, seconds;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText, gameOverText;

    void Start()
    {
        timerIsRunning = true;
        minutes = Mathf.FloorToInt(timeRemaining / 60);
        seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    
    void Update()
    {
        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime;
            minutes = Mathf.FloorToInt(timeRemaining / 60);
            seconds = Mathf.FloorToInt(timeRemaining % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            Debug.Log("Time has run out!");
            timeRemaining = 0;
            timerIsRunning = false;
        }
        if (timeRemaining <= 0)
        {
            timeText.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(true);
        }
    }
}
