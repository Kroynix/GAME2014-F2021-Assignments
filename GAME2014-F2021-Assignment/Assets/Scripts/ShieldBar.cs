/*
Nathan Nguyen
George Brown College
Assignment 1 - GAME2014-F2021
101268067
9/28/2021
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public float current;
    public float Max;
    public Image Fill;

    // Update is called once per frame
    void Update()
    {
        FillBar();
    }

    void FillBar() 
    {
        float fillAmount = current / Max;
        Fill.fillAmount = fillAmount;
    }
}
