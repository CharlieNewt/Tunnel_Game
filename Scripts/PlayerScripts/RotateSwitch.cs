using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSwitch : MonoBehaviour {

	Transform from, to;
	float maxRotation, minRotation;
	float t;

	float timer;
	bool isSwitchUp;
	public bool IsSwitchUp
	{
		set { isSwitchUp = value; }
	}
	// Use this for initialization
	void Start () {
		maxRotation = 25;
		minRotation = -25;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//from.rotation = Quaternion.Euler(0f, -25f, 0f);
		//to.rotation = Quaternion.Euler(0f, 25f, 0f);
		//current_Y_Rotation = gameObject.transform.localRotation.eulerAngles.y - 360;
		//Rotate switch up
		if (isSwitchUp)
		{
			if (t < 1)
			{
				t += (4 * Time.deltaTime);				
			}
			else {
				t = 1;
			}
		}

		//Rotate switch down
		else
		{
			if (t > 0)
			{
				t -= (4 * Time.deltaTime);
				
			}
			else {
				t = 0;
			}
		}
		//Debug.Log(t);
		transform.localRotation = Quaternion.Lerp(Quaternion.Euler(0f, -25f, 0f), Quaternion.Euler(0f, 25f, 0f), t);
		//gameObject.transform.Rotate(0f, current_Y_Rotation, 0f);
	}

}
