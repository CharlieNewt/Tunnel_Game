using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Bar_Script : MonoBehaviour {

    private float xScale;
    private float yScale;
    private float zScale;
    //DELETE WHEN TESTS ARE DONT
    private float zTemp;
    private Color fullPower;
    private Color halfPower;
    private Color lowPower;


    //public GameObject health_outer;
    private Renderer outer_rend;

	// Use this for initialization
	void Start () {
        zTemp = transform.parent.parent.parent.parent.GetComponent<PlayerStats>().PlayerPower * 0.01f;
		
		xScale = transform.localScale.x;
        yScale = transform.localScale.y;
        zScale = zTemp;
    }
	
	// Update is called once per frame
	void Update () {
        zTemp = transform.parent.parent.parent.parent.GetComponent<PlayerStats>().PlayerPower * 0.01f;
        zScale = zTemp;
        transform.localScale = new Vector3 (xScale, yScale, zScale);
        
    }
}
