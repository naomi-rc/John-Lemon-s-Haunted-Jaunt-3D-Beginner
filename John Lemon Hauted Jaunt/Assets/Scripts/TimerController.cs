using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timeCounter;
    private float startTime;
    private bool finishedGame;   

    void Start()
    {
        startTime = Time.time;
        timeCounter.color = Color.white;
        finishedGame = false;
        timeCounter.text = "Time 00.00.00";
    }

    void Update()
    {
        if (finishedGame)
            return;
        float time = Time.time - startTime;
        float minutesValue = ((int)time / 60);
        string minutes = minutesValue < 10 ? $"0{minutesValue}" : minutesValue.ToString();
        float secondsValue = (time % 60);
        string seconds = (secondsValue < 10)? $"0{secondsValue.ToString("f2")}" : secondsValue.ToString("f2");
        timeCounter.text = "Time " + minutes + "." + seconds;
    }

    public string GetTime()
    {
        return timeCounter.text;
    }


    public void Finish()
    {
        finishedGame = true;
        timeCounter.color = Color.yellow;
    }
}
