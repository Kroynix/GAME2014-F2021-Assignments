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
