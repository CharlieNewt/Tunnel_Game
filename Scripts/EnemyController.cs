using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    /*
     * The following class controls the movement of the enemy as well as the formation in which they spawn.
     * The movements can be anti-clockwise or clockwise.
     * The formations are triangle, quad, and circle.
     */

	private int enemyFormationType; //This random int is used to decide which formation to spawn. 

    private int numberOfEnemies;

    private int triangleMovementArrangement; //This int is to decide which way the triangle spawns.

    public GameObject spawnBox; //This is the box that is used to determine the size of the enemy spawns.

    //The following variables define the position of the box;
    private float spawnBoxXP;
    private float spawnBoxYP;
    private float spawnBoxZP;

    //The following variables define the scale of the box;
    private float spawnBoxXS;
    private float spawnBoxYS;
    private float spawnBoxZS;

    List<GameObject> triangleArray = new List<GameObject>();
    List<GameObject> quadArray = new List<GameObject>();
    List<GameObject> circleArray = new List<GameObject>();

    void Start()
    {
        //define the position of the box being used
        spawnBoxXP = spawnBox.transform.position.x;
        spawnBoxYP = spawnBox.transform.position.y;
        spawnBoxZP = spawnBox.transform.position.z;
        //and the scale
        spawnBoxXS = spawnBox.transform.localScale.x;
        spawnBoxYS = spawnBox.transform.localScale.y;
        spawnBoxZS = spawnBox.transform.localScale.z;

        //Then determine the value of the random variables
        enemyFormationType = Random.Range(1, 4);
        triangleMovementArrangement = Random.Range(1, 5);

    }

    void WhichFormationStart()
    {
        switch (enemyFormationType)
        {
            case 1:
                numberOfEnemies = 3;
                TriangleFormation();
                break;

            case 2:
                numberOfEnemies = 4;
                QuadFormation();
                break;

            case 3:
                numberOfEnemies = 5;
                CircleFormation();
                break;

        }
    }

    void TriangleFormation()
    {
        //Code goes here
    }

    void QuadFormation()
    {
        //Code goes here
    }

    void CircleFormation()
    {
        //Code goes here
    }

}
