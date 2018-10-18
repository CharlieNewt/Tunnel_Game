using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is in control of the state of the asteroid. It controls its health,
/// and once thats depleted, it controls its death animation.
/// </summary>
public class AsteroidStats : MonoBehaviour {

	private float asteroidHealth;
    public float AsteroidHealth
    {
        get { return asteroidHealth; }
        set { asteroidHealth = value; }
    }

    private float damageBlend;

	private float asteroidDamage;
    public float GetAsteroidDamage
    {
        get { return asteroidDamage; }
    }
    public bool isDisolving;
    public bool isDestroyed;
    bool hasScoreChanged;

    public float disolveLevel;
    public float disolveRate;


    public Renderer rend;

    void Start()
    {
        asteroidHealth = 100f;
        disolveLevel = -1f;
        rend = GetComponentInChildren<Renderer>();
        rend.material.SetFloat("Vector1_29B5CF23", disolveLevel);

        hasScoreChanged = false;
    }
    
    void Update()
    {
        CheckHealth();
        AnimateAsteroid();
        DestroyAsteroid();
        rend.material.SetFloat("Vector1_29B5CF23", disolveLevel);
        
    }

    void DestroyAsteroid()
    {
        if (isDisolving)
        {
            if (disolveLevel < 1)
            {
                disolveLevel += (Time.deltaTime * disolveRate);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void KillAsteroid()
    {
        disolveRate = 4f;
        isDisolving = true;
    }

    private void CheckHealth()
    {
        if (asteroidHealth <= 0)
        {
            KillAsteroid();
            ScoreChange();
        }
    }

    void AnimateAsteroid()
    {
        rend.material.SetFloat("Vector1_712BE931", -0.01f *(asteroidHealth - 100f));
    }

    public void DamageAsteroid (float damage)
    {
        asteroidHealth -= damage;
    }

    void ScoreChange()
    {
        if (hasScoreChanged == false)
        {
            //Get the last element in the list of collisions in the AsteroidContact class
            string lastCollision = gameObject.GetComponent<AsteroidContact>().collisions[gameObject.GetComponent<AsteroidContact>().collisions.Count - 1];
            //Debug.Log(lastCollision);
            if ((lastCollision == "AlphaProjectile") || (lastCollision == "BetaProjectile") || (lastCollision == "GammaProjectile"))
            {
                GameObject.Find("ship_draft").GetComponent<PlayerStats>().PlayerScore += 250;
            }
            hasScoreChanged = true;
        }
    }
}
