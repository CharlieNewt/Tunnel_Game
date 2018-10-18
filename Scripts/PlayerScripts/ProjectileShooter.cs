using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

	GameObject alphaPrefab;
	GameObject betaPrefab;
	GameObject gammaPrefab;

    GameObject cannonRaycast;

    AudioManager audioManager;

	public int gunSelection;
	public float scroll;

	bool isBetaFiring;

	// Use this for initialization
	void Start () {
		//Load the 3 ammo typesZ
		alphaPrefab = Resources.Load("Projectiles_New/AlphaProjectile") as GameObject;
		betaPrefab = Resources.Load("Projectiles_New/BetaProjectile") as GameObject;
		gammaPrefab = Resources.Load("Projectiles_New/GammaProjectile") as GameObject;
		//Set the gun selection to 1 to begin with
		gunSelection = 1;

		loadAlphaA = true;
		loadAlphaB = false;
		fireBeta = true;

        cannonRaycast = GameObject.Find("CannonRaycast");

        audioManager = FindObjectOfType<AudioManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		BetaTimer();

		GunSelectionControls();
		FireGun();
		if (isBetaFiring)
		{
			FireBeta();
		}

		scroll = Input.GetAxis("Mouse ScrollWheel") * 10f;		
	}

	void GunSelectionControls()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			gunSelection = 1;
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			gunSelection = 2;
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			gunSelection = 3;
		}
	}


	void FireGun () {

		//ALPHA GUN
		if (gunSelection == 1)
		{
			if (Input.GetKeyDown("space"))
			{
				//fireAlpha = true;
			}
			if (Input.GetKey("space"))
			{
				FireAlpha();
			}
			if (Input.GetKeyUp("space"))
			{
				//alphaTimeVariable = 0f;
			}
		}

		//BETA GUN
		if (gunSelection == 2)
		{
			if (Input.GetKeyDown("space") || Input.GetKey("space"))
			{
				isBetaFiring = true;
			}
			
		}

		//GAMMA GUN
		if (gunSelection == 3)
		{
			if (Input.GetKeyDown("space"))
			{
				//gammaTimeVariable = 0f;
			}
			if (Input.GetKey("space"))
			{
				GammaTimer();
				FireGamma();
			}
			if (Input.GetKeyUp("space"))
			{
				//if (gammaSize >= 2f)
				//{
				//	fireGamma = true;
				//	FireGamma();
				//}
				//gammaSize = 0;
				//gammaTimeVariable = 0f;				
				//fireGamma = false;
			}
		}
	}

	//=======================ALPHA GUN============================
	private bool loadAlphaA;
	private bool loadAlphaB;
	private bool fireAlpha;
	private float alphaTimeVariable;
	
	/*
		The following function swaps which alpha gun should be shooting.
		If a gun (A or B) is set to true, then the opposite gun is set to true and 
		the original gun set to false.
	*/
	void LoadAlpha() {
		if (loadAlphaA)
		{
			loadAlphaA = false;
			loadAlphaB = true;
			return;
		}
		else if (loadAlphaB)
		{
			loadAlphaB = false;
			loadAlphaA = true;
			return;
		}
	}

	/*
		This function acts as a timer that is used to judge the time between shots. 
		Every 0.25 seconds the fireAlpha value is set to true and the timer resets.
	*/
	void AlphaTimer ()
	{
		alphaTimeVariable += 1f * Time.deltaTime;
		if (alphaTimeVariable > 0.125f)
		{
			fireAlpha = true;
			alphaTimeVariable = 0f;
		}
	}

	/*
		This is the core function that fires the Alpha Guns.
		Firsts it checks that if the gun can be fired (fireAlpha = true), then it checks
		which of the two alpha gun (A or B) is loaded. A prjectile is then fired from the 
		active gun.
	*/
	void FireAlpha () 
	{
		AlphaTimer();
		if (fireAlpha)
		{
			if (loadAlphaA)
			{
				if (transform.parent.parent.GetComponent<PlayerStats>().EnoughPower(1))
				{
					transform.parent.parent.GetComponent<PlayerStats>().PowerUsed(1);
					GameObject projectile = Instantiate(alphaPrefab) as GameObject;

                    //Play audio
                    audioManager.PlayOneShot("Alpha_" + AudioRegionCheck());

					projectile.GetComponent<ShotStats>().ShotDamage = 2;

					projectile.transform.position = (transform.position + transform.right * 80 + new Vector3(0f, 0f, 25f));
					Rigidbody rb = projectile.GetComponent<Rigidbody>();

					Vector3 direction = cannonRaycast.GetComponent<ProjectileRay>().DirectionToRayBreak(projectile.transform.position);
					//projectile.transform.LookAt(cannonRaycast.GetComponent<ProjectileRay>().DirectionToRayBreak(transform.position));
					rb.velocity = direction * 1500f;

					LoadAlpha();		
					fireAlpha = false;
				}
				//Remove the projectile after 2 seconds.
				//Destroy (projectile, 2);
			}

			else if (loadAlphaB)
			{
				if (transform.parent.parent.GetComponent<PlayerStats>().EnoughPower(1))
				{
					transform.parent.parent.GetComponent<PlayerStats>().PowerUsed(1);
					GameObject projectile = Instantiate(alphaPrefab) as GameObject;

                    //Play audio
                    audioManager.PlayOneShot("Alpha_" + AudioRegionCheck());

                    projectile.GetComponent<ShotStats>().ShotDamage = 2;

					projectile.transform.position = (transform.position + transform.right * 80 + new Vector3(0f, 0f, -25f));
					Rigidbody rb = projectile.GetComponent<Rigidbody>();

					Vector3 direction = cannonRaycast.GetComponent<ProjectileRay>().DirectionToRayBreak(projectile.transform.position);
					//projectile.transform.LookAt(cannonRaycast.GetComponent<ProjectileRay>().RayBreak);
					rb.velocity = direction * 1500f;

					LoadAlpha();
					fireAlpha = false;
				}

				//Remove the projectile after 2 seconds.
				//Destroy (projectile, 2);
			}
		}
	}
	//=======================ALPHA GUN============================


	//=======================BETA GUN=============================
	private bool fireBeta = true;
	public float shotCount;
	private float betaTimeVariable;

	void BetaTimer() 
	{
		betaTimeVariable += 1f * Time.deltaTime;
        if (betaTimeVariable > (0.5f / 3f))
        {
            if (shotCount < 9f)
            {
                shotCount++;
            }
            fireBeta = true;
            betaTimeVariable = 0f;
        }
        else if (shotCount >= 9f && isBetaFiring)
        {
            shotCount = 0f;
        }
        //else if (shotCount >= 9f)
        //{
        //    shotCount = 9;
        //}
        else if (shotCount > 2)
        {
            isBetaFiring = false;
        }
	}

	void FireBeta() 
	{
		//BetaTimer();
		if (fireBeta)
		{
			if (shotCount == 0f)
			{
				if (transform.parent.parent.GetComponent<PlayerStats>().EnoughPower(4))
				{
					transform.parent.parent.GetComponent<PlayerStats>().PowerUsed(4);
					GameObject projectile = Instantiate(betaPrefab) as GameObject;

                    //Play audio
                    audioManager.PlayOneShot("Beta_" + AudioRegionCheck());

                    projectile.GetComponent<ShotStats>().ShotDamage = 5;

					projectile.transform.position = (transform.position + transform.right * 80 + new Vector3(0f, -10f, 0f));
					Rigidbody rb = projectile.GetComponent<Rigidbody>();
					rb.velocity = transform.right * 1200f;

					fireBeta = false;
				}
				else 
				{
					isBetaFiring = false;
				}

				//Remove the projectile after 2 seconds.
				//Destroy (projectile, 2);
			}
			else if (shotCount == 1f)
			{
				if (transform.parent.parent.GetComponent<PlayerStats>().EnoughPower(4))
				{
					transform.parent.parent.GetComponent<PlayerStats>().PowerUsed(4);
					GameObject projectile = Instantiate(betaPrefab) as GameObject;

					projectile.GetComponent<ShotStats>().ShotDamage = 5;

					projectile.transform.position = (transform.position + transform.right * 80 + new Vector3(0f, -10f, 0f));
					Rigidbody rb = projectile.GetComponent<Rigidbody>();
					rb.velocity = transform.right * 1200f;

					fireBeta = false;
				}
				else 
				{
					isBetaFiring = false;
				}

				//Remove the projectile after 2 seconds.
				//Destroy (projectile, 2);
			}
			else if (shotCount == 2f)
			{
				if (transform.parent.parent.GetComponent<PlayerStats>().EnoughPower(4))
				{
					transform.parent.parent.GetComponent<PlayerStats>().PowerUsed(4);
					GameObject projectile = Instantiate(betaPrefab) as GameObject;

					projectile.GetComponent<ShotStats>().ShotDamage = 5;

					projectile.transform.position = (transform.position + transform.right * 80 + new Vector3(0f, -10f, 0f));
					Rigidbody rb = projectile.GetComponent<Rigidbody>();
					rb.velocity = transform.right * 1200f;

					fireBeta = false;
					isBetaFiring = false;
				}
				else
				{
					isBetaFiring = false;
				}

				//Remove the projectile after 2 seconds.
				//Destroy (projectile, 2);
			}
		}
	}
	//=======================BETA GUN=============================


	//=======================GAMMA GUN============================
	private bool hasGammaFired;
	public bool fireGamma;
	public int gammaSize;
	public float gammaTimeVariable;
	
	void GammaTimer() 
	{
		gammaTimeVariable += 1f * Time.deltaTime;

		if (gammaTimeVariable > 0.5f)
		{
			gammaSize++;
			gammaTimeVariable = 0f;
		}

		if (gammaSize >= 5f)
		{
            gammaSize = 5;
			fireGamma = true;
		}
	}

	void FireGamma () 
	{
		
		if (fireGamma)
		{
            if (transform.parent.parent.GetComponent<PlayerStats>().EnoughPower(2 * gammaSize))
            {
                transform.parent.parent.GetComponent<PlayerStats>().PowerUsed(2 * gammaSize);
                GameObject projectile = Instantiate(gammaPrefab) as GameObject;

                projectile.GetComponent<ShotStats>().ShotDamage = 2f * gammaSize;

                projectile.transform.position = (transform.position + transform.right * 120 + new Vector3(0f, -20f, 0f));

                projectile.transform.localScale += new Vector3(gammaSize * 3f, gammaSize * 3f, gammaSize * 3f);
                projectile.transform.Find("GammaProjectile_Model").Find("GammaTrail").localScale += new Vector3(gammaSize * 4f, gammaSize * 4f, gammaSize * 4f);
                projectile.transform.Find("GammaProjectile_Model").Find("GammaParticle").localScale += new Vector3(gammaSize * 4f, gammaSize * 4f, gammaSize * 4f);


                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.velocity = transform.right * 1000f;

                //Remove the projectile after 2 seconds.
                //Destroy (projectile, 2);

                fireGamma = false;

                gammaSize = 0;
                audioManager.Play("Gamma_Fire");
            }
		}
	}
    //=======================GAMMA GUN============================

    int AudioRegionCheck()
    {
        float yMax = 550;
        float yMin = -350;
        float ySpan = yMax - yMin;
        float ySegment = ySpan * 0.2f; //Divide by the number of audio files

        //If the player is in the 5th (bottom) segment, return the int 5.
        if (transform.position.y <= yMin + ySegment)
        {
            return 5;
        }

        //If the player is in the 4th (between bottom and first divider) segment, return the int 4.
        else if ((transform.position.y <= yMin + (ySegment * 2)) && (transform.position.y >= yMin + ySegment))
        {
            return 4;
        }

        //If the player is in the 3rd (between first divider and second divider) segment, return the int 3.
        else if ((transform.position.y <= yMin + (ySegment * 3)) && (transform.position.y >= yMin + (ySegment * 2)))
        {
            return 3;
        }

        //If the player is in the 4nd (between second divider and third divider) segment, return the int 3.
        else if ((transform.position.y <= yMin + (ySegment * 4)) && (transform.position.y >= yMin + (ySegment * 3)))
        {
            return 2;
        }

        //If the player is not within any of the predefined ranges, due to the game logic, the player can only be in the top segment
        else
        {
            return 1;
        }
    }
}