using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    [SerializeField]
    public float Speed = 1.0f;

    
    // Update is called once per frame
    void Update()
    {
        //GetComponent<Skybox>().material.SetFloat("_Rotation", Time.time * Speed);
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * -Speed);
    }
}
