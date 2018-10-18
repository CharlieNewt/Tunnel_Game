using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerBoundary {
	public float yMin, yMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	
	//++++++++++PUBLIC VARIABLES++++++++++
	public float speed;
	public PlayerBoundary playerBoundary;
	public float shipRoll;
    public float shipPitch;
	//++++++++++PUBLIC VARIABLES++++++++++


	//++++++++++PRIVATE VARIABLES++++++++++
	private Rigidbody rb;
	private float baseSpeed;
	private float maxSpeed;

	private Vector3 movement;
	private Vector3 movementLimit;

    float playerPower;
    float boosterPowerTimer;
	//++++++++++PRIVATE VARIABLES++++++++++
	


	void Start () {
		rb = GetComponent<Rigidbody>();
		baseSpeed = 100f;
		maxSpeed = 300f;
		speed = baseSpeed;
	}

	void FixedUpdate () {

        playerPower = gameObject.GetComponent<PlayerStats>().PlayerPower;

        Booster();

		//To calculate roll of the ship the horizontal axis is used
		//shipRoll = Input.GetAxis("Horizontal");
		//Assign input axis to a floats
		float moveHorizontal = Input.GetAxis("Horizontal") * speed;
		float moveVertical = Input.GetAxis("Vertical") * speed;

		movement = new Vector3(0, moveVertical, -moveHorizontal);
		rb.velocity = movement;

		//Mathf.Clamp sets the limits of a value.
		rb.position = new Vector3
		(
			0f,
			Mathf.Clamp (rb.position.y, playerBoundary.yMin, playerBoundary.yMax),
			Mathf.Clamp (rb.position.z, playerBoundary.zMin, playerBoundary.zMax)
		);

        //shipRoll = rb.velocity.z;
        ShipRoll();
        ShipPitch();
        rb.rotation = Quaternion.Euler(shipRoll * Time.deltaTime, 0f, -shipPitch * Time.deltaTime);
	}

	/*
		The following function increases the speed of the player ship if the booster button (left shift) is being pressed.
		When the button is let go, the player's speed degrades back to the baseSpeed over time.
	*/
	void Booster () {
		if (GetComponent<PlayerStats>().EnoughPower(1) && Input.GetKey(KeyCode.LeftShift))
		{
            //if (Input.GetKey(KeyCode.LeftShift))
            //{
                if (speed < maxSpeed)
                {
                    speed = speed + 100f * Time.deltaTime;
                }
                else
                {
                    speed = maxSpeed;
                }
                BoosterPowerTimer();
            //}       
		}
		else if (speed > baseSpeed) 
		{
			speed = speed - 100f * Time.deltaTime;
            boosterPowerTimer = 0f;
		}
		else {
			speed = baseSpeed;
            boosterPowerTimer = 0f;
		}
	}

    void BoosterPowerTimer()
    {
        boosterPowerTimer += Time.deltaTime;

        if (boosterPowerTimer > 0.1f)
        {
            GetComponent<PlayerStats>().PowerUsed(1);
            boosterPowerTimer = 0f;
        }
    }

    /*
        This function calculates when and how much the ship should roll.
    */
    void ShipRoll()
    {

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (shipRoll < 200)
                shipRoll = shipRoll + 100f * Time.deltaTime;
            return;
        }

        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            if (shipRoll > -200)
                shipRoll = shipRoll - 100f * Time.deltaTime;
            return;
        }
        else if (shipRoll < 0.5f && shipRoll > -0.5f)
        {
            shipRoll = 0;
        }
        else if (shipRoll > 0)
        {
            shipRoll = shipRoll - 100f * Time.deltaTime;
        }

        else if (shipRoll < 0)
        {
            shipRoll = shipRoll + 100f * Time.deltaTime;
        }
    }

    void ShipPitch()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            if (shipPitch < 200)
                shipPitch = shipPitch + 100f * Time.deltaTime;
            return;
        }

        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            if (shipPitch > -200)
                shipPitch = shipPitch - 100f * Time.deltaTime;
            return;
        }
        else if (shipPitch < 0.5f && shipPitch > -0.5f)
        {
            shipPitch = 0;
        }

        else if (shipPitch > 0)
        {
            shipPitch = shipPitch - 100f * Time.deltaTime;
        }

        else if (shipPitch < 0)
        {
            shipPitch = shipPitch + 100f * Time.deltaTime;
        }
    }
}
