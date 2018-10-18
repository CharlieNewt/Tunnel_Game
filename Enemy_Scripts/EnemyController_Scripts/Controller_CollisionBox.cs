using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_CollisionBox : MonoBehaviour {

    float controllerRadius;
    EnemySpawn enemySpawn;
    BoxCollider boxCollider;

    private int respawnCounter;
    public int RespawnCounter
    {
        get { return respawnCounter; }
        set { respawnCounter = value; }
    }


	// Use this for initialization
	void Start () {

        respawnCounter = 0;

        enemySpawn = GetComponent<EnemySpawn>();
        boxCollider = GetComponent<BoxCollider>();

        controllerRadius = enemySpawn.radius;

        boxCollider.size = new Vector3(
            100f,
            controllerRadius * 2,
            controllerRadius * 2
            );
	}
	
}
