using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public bool isGatlingEnemy;

    GameObject enemy;
    public GameObject point;
    public GameObject center;

    public Vector3 nextPoint;

    public int numOfEnemies;
    public float radius;

    private float enemyThetaConst;
    private float enemyThetaVar;

    private bool allPointsSpawned;
    public bool AllPointsSpawned
    {
        get { return allPointsSpawned; }
    }

    private Vector3 pointPosition;
    private Vector3 enemyPosition;

    public List<GameObject> points = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();

    public Vector3 startPosition;



    //=--=--=--=Enemy Movement Variables=--=--=--=
    //Dictionary<string, GameObject> pointsMap = new Dictionary<string, GameObject>();

    //=--=--=--=Enemy Movement Variables=--=--=--=

    

	// Use this for initialization
	void Start () {
        startPosition = transform.position;

        //Load the enemy object
        if (!isGatlingEnemy){
            enemy = Resources.Load("Enemies/Ships/LazerCarrierTop") as GameObject;
        }
        else 
        {
            enemy = Resources.Load("Enemies/Ships/Gatling_Enemy_Top") as GameObject;
        }

        //We must figure out the angle between each enemy so we devide 2pi by the number of enemies.
        enemyThetaConst = (2f * Mathf.PI) / numOfEnemies;

        //To create the enemies as well as the points where the enemies spawn we cycle a for loop for the number of enemies.
        for (int i = 0; i < numOfEnemies; i++)
        {
            enemyThetaVar = (Mathf.PI * 0.5f) + (enemyThetaConst * i);
            pointPosition = new Vector3(
                0f,
                radius * Mathf.Sin(enemyThetaVar),
                radius * Mathf.Cos(enemyThetaVar)
                );
            GameObject thisPoint = Instantiate(point, gameObject.transform) as GameObject;
            thisPoint.transform.localPosition = pointPosition;
            points.Add(thisPoint);
            thisPoint.name = "EnemySpawn" + i;


            GameObject thisEnemy = Instantiate(enemy, gameObject.transform) as GameObject;
            thisEnemy.transform.localPosition = pointPosition;
            enemies.Add(thisEnemy);
            thisEnemy.name = "Enemy" + i ;

            //thisPoint.transform.parent = gameObject.transform;




            if (i == numOfEnemies - 1)
            {
                allPointsSpawned = true;
            }
        }

        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Debug.Log(enemies.Count);
        RemoveEnemy();
        
    }

    void RemoveEnemy()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null)
            {
                enemies.Remove(enemy);
                Debug.Log("Enemy was removed");
            }

            if (enemies.Count <= 0)
            {
                Debug.Log("No Enemies left");
                GameObject.Find("GameController").GetComponent<GameController>().GatlingCounter++;
                GameObject.Find("GameController").GetComponent<GameController>().SpawnGatling();
                Destroy(gameObject);
            }
        }
    }
}
