using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The purpose of this class is to identify the spawn points of the enemies, and then identify all the enemies.
 * After this the class assigns the velocity of the enemy in the direction towards the next point.
*/ 

public class EnemyDirectionController : MonoBehaviour {

    private GameObject controller; //The enemy controller object
    private EnemySpawn enSpwn; //The controller's EnemySpawn script
    private EnemyMovement enMvmt; //The controller's EnemyMovement script

    //public Vector3 postNextPosition;

    public List<GameObject> enemies = new List<GameObject>(); //A list of all enemies

    float gameSpeed; //The current speed of the game

	// Use this for initialization
    /// <summary>
    /// The Start function assigns the controller to this game object, the enemy spawn to this controllers enemyspawn component,
    /// and Finds all the enemies that have been spawned in the controller.
    /// </summary>
	void Start () {
        controller = gameObject;
        enSpwn = controller.GetComponent<EnemySpawn>();
        FindEnemies();
	}
	
	/// <summary>
    /// The FixedUpdate constantly checks if there are any enemies left in the controller
    /// and checks where the each enemy should be going.
    /// If no enemies are left in the controller, then the controller object is propelled forward.
    /// </summary>
	void FixedUpdate () {
        gameSpeed = GameObject.Find("GameController").GetComponent<GameController>().GameSpeed;


        enSpwn = controller.GetComponent<EnemySpawn>();

        FindEnemies();
        EnemyDirection();

        if (enemies.Count <= 0)
        {
            transform.position -= new Vector3(500f, 0f, 0f) * Time.deltaTime * gameSpeed;
            Debug.Log("No enemies left");
        }
    }
    /// <summary>
    /// The following function gets the points list from the enemy spawn script and compares the amount of points with the amount of enemies
    /// in the controller. 
    /// </summary>
    void FindEnemies()
    {
        int i;
        foreach (GameObject p in enSpwn.points)
        {
            i = enSpwn.points.IndexOf(p);
            if ( transform.Find("Enemy" + i) != null)
            {
                GameObject enemyA = transform.Find("Enemy" + i).gameObject;
            
                if ((enemyA != null) && !enemies.Contains(enemyA))
                {
                    enemies.Add(enemyA);
                }
            }
        }

    }

    /// <summary>
    /// The EnemyDirection function checks the enemies list for each non-null enemy (not destroyed).
    /// If the enemy e in enemies is not null, then its index is taken and used, along with the pointOffset value,
    /// to chose the point which the enemy should travel to next.
    /// </summary>
    void EnemyDirection()
    {
        int i;
        int pointOffset;
        int pointIndexMod;
        foreach (GameObject e in enemies)
        {
            if (e != null)
            {
                i = enemies.IndexOf(e);
                enMvmt = e.GetComponent<EnemyMovement>();
                pointOffset = enMvmt.pointOffset;

                pointIndexMod = (i + 1 + pointOffset) % enSpwn.points.Count;

                enMvmt.NextPosition = enSpwn.points[pointIndexMod].transform.localPosition;
            }
        }

    }
}
