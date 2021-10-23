/*
Nathan Nguyen
George Brown College
Assignment 2 - GAME2014-F2021

101268067
10/23/2021

Description:
Controls Sound clip generation

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    void Start()
    {
        Play("BGM");
    }



}
