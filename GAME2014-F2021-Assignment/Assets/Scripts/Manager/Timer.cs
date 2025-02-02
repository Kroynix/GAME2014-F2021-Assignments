/*
Nathan Nguyen
George Brown College
Assignment 2 - GAME2014-F2021

101268067
10/23/2021

Description:
Controls Counter to show to user

*/

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerBox;
    private float time;
    private bool timerActive = false;
    private TimeSpan timespan;

    // Start is called before the first frame update
    void Start()
    {
        timerBox.text = "Time: " + time;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive)
        {
            time += Time.deltaTime;
            timespan = TimeSpan.FromSeconds(time);
            timerBox.text = "Time: " + timespan.ToString("mm' : 'ss");
        }
    }

    public void startTime()
    {
        timerActive = true;
    }

    public float sendTime()
    {
        timerActive = false;
        return time;
    }

}
