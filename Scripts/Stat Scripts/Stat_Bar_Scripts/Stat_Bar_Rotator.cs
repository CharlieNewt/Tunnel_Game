using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat_Bar_Rotator : MonoBehaviour {

	public float spinSpeed = 1;
	
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(0, 0, spinSpeed);
	}
}
