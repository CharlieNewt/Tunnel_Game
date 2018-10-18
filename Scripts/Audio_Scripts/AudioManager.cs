using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

//THE FOLLOWING CLASS WAS TAKEN FROM A BRACKEYS VIDEO ---> https://www.youtube.com/watch?v=6OT43pvUyfY&index=23&list=PLLS-o2D4IXowrAw9x2lE4QxeuFMzaHS1j&t=0s

public class AudioManager : MonoBehaviour {

    [HideInInspector]
    public string scene;

    public Sound[] sounds;

    public static AudioManager instance;

    [HideInInspector]
    public bool introStarted;
    [HideInInspector]
    public bool introFinished;

    [HideInInspector]
    public bool themeLoopStarted;

    [HideInInspector]
    public string isPaused;

	// Use this for initialization
	void Awake () {

        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
	}

    void Start()
    {
        //Play("Asteroid_Hit");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.PlayOneShot(s.source.clip);
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Pause();
    }

    public bool IsPlaying(string name)
    {
        bool isPlaying;
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            //return null;
        }
        isPlaying = s.source.isPlaying;
        return isPlaying;
    }
}
