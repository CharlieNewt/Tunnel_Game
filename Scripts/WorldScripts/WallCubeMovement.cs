using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCubeMovement : MonoBehaviour {

	private Vector3 startPosition;

	public bool useSin = true;
	public bool useCos = false;
	public float amplitude = 1;
	public float frequency = 1;
	public float phaseShift;

    public float x;
    public float y;
    public float z;

    public bool isVertical = false;


	private float rand;
    float gameSpeed;
    float maxFreq;
    float xSpeed;

	// Use this for initialization
	void Start () {
		startPosition = transform.localPosition;
		rand = Random.Range(0f, 2f);
		frequency = rand;
        maxFreq = 4;

        amplitude = transform.localScale.x / 5;

        //gameSpeed = GameObject.Find("GameController").GetComponent<GameController>().GameSpeed;
        gameSpeed = 1;
        xSpeed = 1;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //gameSpeed = GameObject.Find("GameController").GetComponent<GameController>().GameSpeed;

		x = startPosition.x;
		y = startPosition.y;
		z = startPosition.z;
		if (useSin)
		{
            if (!isVertical)
			    z = z + amplitude * Mathf.Sin (Time.timeSinceLevelLoad * frequency + phaseShift);

            else
                y = y + amplitude * Mathf.Sin(Time.timeSinceLevelLoad * frequency + phaseShift);
        }
		else if (useCos)
		{
            if (!isVertical)
			    z = z + amplitude * Mathf.Cos (Time.timeSinceLevelLoad * frequency + phaseShift);

            else
                y = y + amplitude * Mathf.Cos(Time.timeSinceLevelLoad * frequency + phaseShift);
        }

		transform.localPosition = new Vector3 (transform.localPosition.x - (10f * xSpeed), y, z);

        WaveSpeedUp();
        XDirectionSpeed();
		
	}

    void WaveSpeedUp()
    {
        if (frequency < maxFreq)
            { 
            gameSpeed = Time.deltaTime * 0.01f;
            frequency = frequency + gameSpeed;
        }
    }

    void XDirectionSpeed()
    {
        if (xSpeed < 2)
        {
            xSpeed += Time.deltaTime * 0.005f;
        }        
    }
}
