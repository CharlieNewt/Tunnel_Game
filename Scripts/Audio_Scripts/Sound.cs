using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//THE FOLLOWING CLASS WAS TAKEN FROM A BRACKEYS VIDEO ---> https://www.youtube.com/watch?v=6OT43pvUyfY&index=23&list=PLLS-o2D4IXowrAw9x2lE4QxeuFMzaHS1j&t=0s

[System.Serializable]
public class Sound {

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;


    public bool loop;

    [HideInInspector]
    public AudioSource source;

    
}
