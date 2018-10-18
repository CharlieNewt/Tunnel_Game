using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The LazerController class is used as a buffer between the enemies and the lazers spawning. 
 * Without this script the lazers try to spawn the same time as the enemies leading to the lazers not being able to spawn.
*/

public class LazerController : MonoBehaviour {
    float timer;

    void Start()
    {
        enabled = !GetComponent<EnemySpawn>().isGatlingEnemy;
    }
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;
        if (timer > 0.1f)
        {
            /*
             * If the AllPointsSpawned parameter from the EnemySpawn class is true, and if the Drawlines script is disabled on this game object.
             * Then the draw lines script is enabled.
            */
            if (gameObject.GetComponent<EnemySpawn>().AllPointsSpawned && !gameObject.GetComponent<DrawLines>().enabled)
            {
                gameObject.GetComponent<DrawLines>().enabled = true;
            }
        }
        //yield return null;
        
	}
}
