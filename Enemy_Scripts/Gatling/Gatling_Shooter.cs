using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorMath;

public class Gatling_Shooter : MonoBehaviour {

	GameObject player;
	GameObject shot;
	GameObject shotSpawnR;
	GameObject shotSpawnL;
	GameObject gatlingCharge;
	Renderer gatlingCharge_rend;
	

	bool isRightSpawn;
	float timer;
	float timerMultiplier;
	public float TimerMultiplier
	{
		get { return timerMultiplier; }
		set { timerMultiplier = value; }
	}

    float gameSpeed;
	// Use this for initialization
	void Start () {
        gameSpeed = GameObject.Find("GameController").GetComponent<GameController>().GameSpeed;
        timer = 0f;
		timerMultiplier = gameSpeed;

		shot = Resources.Load("Projectiles_New/EnemyProjectile") as GameObject;
		shotSpawnR = transform.Find("Gatling_Enemy_Ship").Find("GatlingBase").Find("FrontGunR").Find("Proj_Spawn_R").gameObject;
		shotSpawnL = transform.Find("Gatling_Enemy_Ship").Find("GatlingBase").Find("FrontGunL").Find("Proj_Spawn_L").gameObject;

		gatlingCharge = transform.Find("Gatling_Enemy_Ship").Find("EnemyGatlingCharge").gameObject;
		gatlingCharge_rend = gatlingCharge.GetComponent<Renderer>();
		gatlingCharge_rend.material.SetFloat("Vector1_CB8148DF", 0f);

		player = GameObject.FindWithTag("Player");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gameSpeed = GameObject.Find("GameController").GetComponent<GameController>().GameSpeed;
        timerMultiplier = gameSpeed;
        //Debug.Log("Shot speed Modifier = " + timerMultiplier);

        if (!GetComponent<EnemyStats>().BeingDestroyed)
		{
			timer += Time.deltaTime * timerMultiplier;
			if (timer > 2)
			{
				if ((transform.position.x < 3500) && (transform.position.x > 950))
				{
					ShootProjectile();
					timer = 0;
				}
			}
			
			if (timer <= 2f)
			{
				gatlingCharge_rend.material.SetFloat("Vector1_CB8148DF", timer * 0.125f);
			}
			else if (gatlingCharge_rend.material != null)
			{
				gatlingCharge_rend.material.SetFloat("Vector1_CB8148DF", 0f);
			}
			if (transform.position.x > 950)
				transform.LookAt(player.transform);
		}

	}

	void ShootProjectile()
	{
		Vector3 direction;
		GameObject shotObj = Instantiate(shot);
		Rigidbody rb = shotObj.GetComponent<Rigidbody>();
		shotObj.GetComponent<ShotStats>().ShotDamage = 1;
		

		if (isRightSpawn)
		{
			shotObj.transform.position = shotSpawnR.transform.position;
		}
		else
		{
			shotObj.transform.position = shotSpawnL.transform.position;
		}

		direction = VectorFunc.Direction(shotObj.transform.position, player.transform.position);
		
		rb.velocity = 1100 * direction;
		
		isRightSpawn = !isRightSpawn;
	}
}
