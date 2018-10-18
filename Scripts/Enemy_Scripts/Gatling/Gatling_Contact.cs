using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatling_Contact : MonoBehaviour {

	EnemyStats enemyStats;
	public List<string> collisions = new List<string>();

	// Use this for initialization
	void Start () {
		enemyStats = GetComponent<EnemyStats>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "AlphaProjectile")
		{
			float shotDamage = other.GetComponent<ShotStats>().ShotDamage * 2;
			enemyStats.DamageShip(shotDamage);

			if (!enemyStats.BeingDestroyed)
			{
				GameObject alphaSparksPS = Resources.Load("Projectiles_New/ImpactPS/AlphaImpactPS") as GameObject;
            	Instantiate(alphaSparksPS, other.transform.position, Quaternion.Euler(0f, -90f, 0f), gameObject.transform);
			}
			collisions.Add(other.tag);
			Destroy(other.gameObject);
		}

		if (other.tag == "BetaProjectile")
		{
			float shotDamage = other.GetComponent<ShotStats>().ShotDamage * 2;
			enemyStats.DamageShip(shotDamage);

			if (!enemyStats.BeingDestroyed)
			{
				GameObject alphaSparksPS = Resources.Load("Projectiles_New/ImpactPS/AlphaImpactPS") as GameObject;
            	Instantiate(alphaSparksPS, other.transform.position, Quaternion.Euler(0f, -90f, 0f), gameObject.transform);
			}
			collisions.Add(other.tag);
			Destroy(other.gameObject);
		}

		if (other.tag == "GammaProjectile")
		{
			float shotDamage = other.GetComponent<ShotStats>().ShotDamage * 2;
			enemyStats.DamageShip(shotDamage);

			if (!enemyStats.BeingDestroyed)
			{
				GameObject alphaSparksPS = Resources.Load("Projectiles_New/ImpactPS/AlphaImpactPS") as GameObject;
            	Instantiate(alphaSparksPS, other.transform.position, Quaternion.Euler(0f, -90f, 0f), gameObject.transform);
			}
			collisions.Add(other.tag);
			//Destroy(other.gameObject);
		}
	}

	
}
