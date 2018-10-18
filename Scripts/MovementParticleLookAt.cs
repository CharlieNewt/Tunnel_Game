using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementParticleLookAt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(GameObject.FindWithTag("Player").transform);
	}
}
