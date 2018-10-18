using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

/*
The AsteroidContact class controls what happens whenever something comes into contact with an asteroid.
Each contact object is identified by its tag. If the object is not specified in the OnTriggerEnter(...)
then it is destoyed.
*/
public class AsteroidContact : MonoBehaviour {

    AsteroidStats asteroid;
    AudioManager audioManager;

    //public CameraShake cameraShake;
    private float asteroidVelX;

    public List<string> collisions = new List<string>();

    void Start () {
        asteroid = gameObject.GetComponent<AsteroidStats>();
        audioManager = FindObjectOfType<AudioManager>();
    }

	void OnTriggerEnter(Collider other)
	{

		//Exclude Shot Boundary
		if (other.tag == "ShotBoundary")
		{
            //collisions.Add(other.gameObject);
			return;
		}

		

		if (gameObject.tag == "Asteroid" && other.tag == "AlphaProjectile")
		{
            ShotStats projStat = other.gameObject.GetComponent<ShotStats>();
            float projDmg = projStat.ShotDamage * 10;

            asteroid.DamageAsteroid(projDmg);

            if (!asteroid.isDisolving)
            {
                GameObject alphaSparksPS = Resources.Load("Projectiles_New/ImpactPS/AlphaImpactPS") as GameObject;
                Instantiate(alphaSparksPS, other.transform.position, Quaternion.Euler(0f, -90f, 0f), asteroid.transform);
                collisions.Add(other.tag);
                Destroy(other.gameObject);
            }
            //Debug.Log(asteroid.AsteroidHealth);

            //asteroid.KillAsteroid();
            //return;
		}

        if (gameObject.tag == "Asteroid" && other.tag == "BetaProjectile")
		{
            ShotStats projStat = other.gameObject.GetComponent<ShotStats>();
            float projDmg = projStat.ShotDamage * 10;

            asteroid.DamageAsteroid(projDmg);

            if (!asteroid.isDisolving)
            {
                GameObject alphaSparksPS = Resources.Load("Projectiles_New/ImpactPS/AlphaImpactPS") as GameObject;
                Instantiate(alphaSparksPS, other.transform.position, Quaternion.Euler(0f, -90f, 0f), asteroid.transform);
                collisions.Add(other.tag);
                Destroy(other.gameObject);
            }
        }

        if (gameObject.tag == "Asteroid" && other.tag == "GammaProjectile")
		{
            ShotStats projStat = other.gameObject.GetComponent<ShotStats>();
            float projDmg = projStat.ShotDamage * 10;

            asteroid.DamageAsteroid(projDmg);

            if (!asteroid.isDisolving)
            {
                GameObject alphaSparksPS = Resources.Load("Projectiles_New/ImpactPS/AlphaImpactPS") as GameObject;
                Instantiate(alphaSparksPS, other.transform.position, Quaternion.Euler(0f, -90f, 0f), asteroid.transform);
                collisions.Add(other.tag);
                //Destroy(other.gameObject);
            }

            return;
        }


        if (other.tag == "Player")
        {
            if (!other.GetComponentInChildren<Camera_Reactions>().ShouldShake)
                other.GetComponentInChildren<Camera_Reactions>().ShouldShake = true;

            asteroidVelX = gameObject.GetComponent<Rigidbody>().velocity.x;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(asteroidVelX * 0.1f, 0f, 0f);

            other.GetComponent<PlayerStats>().PlayerHit(5);

            asteroid.disolveRate = 4f;
            asteroid.isDisolving = true;

            collisions.Add(other.tag);
            Debug.Log("player hit");

            if (audioManager == null)
            {
                Debug.LogWarning("AudioManager Not found");
            }
            else
            {
                audioManager.Play("Asteroid_Hit");
            }

            return;
        }

        if (other.tag == "WorldBlockBoundary")
        {
            collisions.Add(other.tag);
            return;
        }

        if (other.tag == "BorderCube")
        {
            collisions.Add(other.tag);
            return;
        }

        if (other.tag == "EnemyController_CollisionBox")
        {
            //collisions.Add(other.gameObject);
            return;
        }

        if (other.tag == "Lazer")
        {
            collisions.Add(other.tag);
            return;
        }

        if (other.tag == "Gatling_Ship")
        {
            collisions.Add(other.tag);
            return;
        }

        if (gameObject.tag == "Asteroid" && other.tag == "Enemy_Projectile")
        {
            float proj_Damage = other.GetComponent<ShotStats>().ShotDamage * 10;
            asteroid.DamageAsteroid(proj_Damage);
            collisions.Add(other.tag);

            Destroy(other.gameObject);
            return;
        }

        Destroy(other.gameObject);
        //Destroy(gameObject);
    }

    
}
