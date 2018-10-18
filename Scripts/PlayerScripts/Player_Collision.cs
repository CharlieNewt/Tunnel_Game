using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour {

    AudioManager audioManager;

	float timer;
	bool isInvinsible;

	// Use this for initialization
	void Start () {
		isInvinsible = false;
        audioManager = FindObjectOfType<AudioManager>();
    }
	
	void FixedUpdate()
	{
		// timer += Time.deltaTime;
		// if (timer > 0.75f)
		// {
		// 	isInvinsible = false;
		// }
	}
    /// <summary>
    /// This function controls what happenes when the player collides with an enemy or an enemy projectile.
    /// </summary>
    /// <param name="other"></param>
	void OnTriggerEnter(Collider other)
	{
        //An enemy projectile will cause the players camera to shake, the plyer will lose health and the projectile will be destroyed.
		if (other.tag == "Enemy_Projectile")
		{		
			if (!isInvinsible)
			{				
				if (!GetComponentInChildren<Camera_Reactions>().ShouldShake)
				{
                	GetComponentInChildren<Camera_Reactions>().ShouldShake = true;
				}
				float proj_Damage = other.GetComponent<ShotStats>().ShotDamage;
				GetComponent<PlayerStats>().PlayerHit(proj_Damage);

                if (audioManager == null)
                {
                    Debug.LogWarning("AudioManager Not found");
                }
                else
                {
                    audioManager.Play("Enemy_Projectile_Hit");
                }

                Destroy(other.gameObject);
				timer = 0;
				//isInvinsible = true;
			}
		}

        // A collision with a gatling enemy will cause the player to lose a chunck of health, as well as shake the camera and 
        // kill the gatling enemy.
		if (other.tag == "Gatling_Ship")
		{
			EnemyStats gatlingStats = other.GetComponent<EnemyStats>();
			gatlingStats.ShipHealth = 0f;

			if (!GetComponentInChildren<Camera_Reactions>().ShouldShake)
				{
                	GetComponentInChildren<Camera_Reactions>().ShouldShake = true;
				}

				gameObject.GetComponent<PlayerStats>().PlayerHit(25);

            if (audioManager == null)
            {
                Debug.LogWarning("AudioManager Not found");
            }
            else
            {
                audioManager.Play("Asteroid_Hit");
            }

        }
	}
}
