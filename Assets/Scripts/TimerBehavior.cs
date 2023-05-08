using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerBehavior : MonoBehaviour
{
    public static TimerBehavior Instance;
    public float timeValue = 90;
    private float timeStart = 90;
    public float timeOver;
    public TextMeshProUGUI timerText;

    private void Awake()
    {

        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            timeOver = timeValue;
           

        }
        else
        {
            timeValue = 0;
            GameBehavior.Instance.GoSeq();


        }
        DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


    }
    public void ResetTimer()
    {
        timeValue = timeStart;
    }
    public void GameOverTimer()
    {
        
        DisplayTime(timeValue);
    }
}
