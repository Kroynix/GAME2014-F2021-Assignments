using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public int current;
    public int Max;
    public Image Fill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFil();
    }

    void GetCurrentFil() 
    {
        float fillAmount = (float)current / (float)Max;
        Fill.fillAmount = fillAmount;
    }
}
