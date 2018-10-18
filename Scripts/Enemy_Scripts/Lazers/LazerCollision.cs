using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LazerCollision : MonoBehaviour {

    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!other.GetComponentInChildren<Camera_Reactions>().ShouldShake)
                other.GetComponentInChildren<Camera_Reactions>().ShouldShake = true;
			
			other.GetComponent<PlayerStats>().PlayerHit(10);

            if (audioManager == null)
            {
                Debug.LogWarning("AudioManager Not found");
            }
            else
            {
                audioManager.Play("Lazer_Hit");
            }

            return;
		}
	}
}
