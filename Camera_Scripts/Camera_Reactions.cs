using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * The following code is adapted from this youtube video --> https://www.youtube.com/watch?v=GDatJi6HSYE
 * The video describes how to create a camera that shakes in demand.
*/

public class Camera_Reactions : MonoBehaviour {

    public float power = 0.2f;
    public float duration = 1f;
    public Transform camera;
    public float slowDownAmount = 1f;

    Vector3 startPosition;
    float initialDuration;

    bool shouldShake;
    public bool ShouldShake
        {
        get { return shouldShake; }
        set { shouldShake = value; }
        }
    float timer;
	// Use this for initialization
	void Start () {
        shouldShake = false;
        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        initialDuration = duration;
	}
	
	// Update is called once per frame
	void Update () {
        ShakeCamera();
	}

    void ShakeCamera()
    {
        if (shouldShake)
        {
            if (duration > 0)
            {
                camera.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime* slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                camera.localPosition = startPosition;
            }
        }
    }
}
