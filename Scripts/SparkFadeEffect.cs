using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkFadeEffect : MonoBehaviour {

    Renderer rend;
    float timer;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material.SetFloat("Vector1_1A8D6441", 0);
	}
	
	// Update is called once per frame
	void Update () {
        timer = Time.deltaTime;
        rend.material.SetFloat("Vector1_1A8D6441", (timer));
        if (timer > 1)
        {
            Debug.Log("Sparks Destroyed");
            Destroy(gameObject);
        }
    }
}
