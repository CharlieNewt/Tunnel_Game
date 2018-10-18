using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_VFX : MonoBehaviour {
	float timer;
	Renderer rend;
	

	// Use this for initialization
	void Start () {
		timer = 0;
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
		rend.material.SetFloat("_Noise_Scale", (51 + Mathf.Sin(timer) * 50));
	}
}
