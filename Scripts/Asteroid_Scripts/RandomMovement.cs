using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the speed that the asteroid travels towards the player (randomSpeed), as well as the speed the asteroid rotates (tumble).
/// The asteroids speed is also dependent on the game speed.
/// </summary>
public class RandomMovement : MonoBehaviour {
    
	public float tumble;
	private Rigidbody rb;

    private float randomSpeed;
    float gameSpeed;

	void Start ()
	{
        gameSpeed = GameObject.Find("GameController").GetComponent<GameController>().GameSpeed;

        randomSpeed = Random.Range(200f, 350f);
        tumble = Random.Range(0.1f, 5f);
        
        //Rigidbody Physics
		rb = GetComponent<Rigidbody>();

		rb.angularVelocity = Random.insideUnitSphere * tumble;

        rb.velocity = new Vector3(-randomSpeed * gameSpeed, 0f, 0f);
		}
}
