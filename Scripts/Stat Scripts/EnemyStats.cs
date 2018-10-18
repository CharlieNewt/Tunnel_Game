using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	float damage;
	public float Damage
	{
		get { return damage; }
		set { damage = value; }
	}
	float shipHealth;
	public float ShipHealth
	{
		get { return shipHealth; }
		set { shipHealth = value; }
	}

	bool destroyed = false;
	bool beingDestroyed = false;
	public bool BeingDestroyed
	{
		get { return beingDestroyed; }
	}

	bool hasScoreChanged;

	float destructionTimer;

	Renderer rend;
	// Use this for initialization
	void Start () {
		shipHealth = 100;
		rend = transform.Find("Gatling_Enemy_Ship").GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CheckShipHealth();
		AnimateShip();
		DestroyShip();
	}

	public void DamageShip(float damageTaken)
	{
		shipHealth -= damageTaken;
	}

	void AnimateShip()
	{
		rend.materials[1].SetFloat("Vector1_712BE931", -0.001f *(shipHealth - 100f));
	}

	void CheckShipHealth()
	{
		if (shipHealth <= 0)
		{
			KillShip();
			ScoreChange();
		}
	}

	void KillShip ()
	{
		beingDestroyed = true;
	}

	void DestroyShip()
	{
		if (beingDestroyed)
		{
			destructionTimer += Time.deltaTime;
			if (destructionTimer < 1.5f)
			{
				if (transform.Find("Gatling_Fade_VFX").gameObject.active != true)
				{
					transform.Find("Gatling_Fade_VFX").gameObject.SetActive(true);
					//Destroy(transform.Find("Gatling_Enemy_Ship").gameObject);
					transform.Find("Gatling_Enemy_Ship").gameObject.SetActive(false);
				}
			}
			else 
			{
				Destroy(gameObject);
			}
		}

	}

	void ScoreChange()
    {
        if (hasScoreChanged == false)
        {
            //Get the last element in the list of collisions in the Gatling_Contact class
            if (gameObject.GetComponent<Gatling_Contact>().collisions[gameObject.GetComponent<Gatling_Contact>().collisions.Count - 1] != null)
            {
                string lastCollision = gameObject.GetComponent<Gatling_Contact>().collisions[gameObject.GetComponent<Gatling_Contact>().collisions.Count - 1];
                Debug.Log(lastCollision);
                if ((lastCollision == "AlphaProjectile") || (lastCollision == "BetaProjectile") || (lastCollision == "GammaProjectile"))
                {
                    GameObject.Find("ship_draft").GetComponent<PlayerStats>().PlayerScore += 1000;
                }
                hasScoreChanged = true;
            }
        }
    }
}
