using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    AudioManager audioManager;

    //public GameObject asteroid;
    GameObject asteroid1, asteroid2, asteroid3, asteroid4;
    public GameObject spawnBoundary;
    GameObject lazerEnemyController;
    GameObject gatlingEnemyController;


    List<GameObject> asteroids = new List<GameObject>(); //List of asteroids
    List<GameObject> gatlings = new List<GameObject>(); //List of gatling enemies
    List<GameObject> lazers = new List<GameObject>(); //List of lazer enemies
    List<GameObject> controllers = new List<GameObject>(); // List of enemy spawn/movement controllers.


    //Boundary Position
    private float spawnBoundaryXP;
    private float spawnBoundaryYP;
    private float spawnBoundaryZP;
    //Boundary Scale
    private float spawnBoundaryXS;
    private float spawnBoundaryYS;
    private float spawnBoundaryZS;

    float timer;
    float asteroidTimer;
    float speedTimer;

    int largeAsteroidCount;
    int smallAsteroidCount;

    int lazerCounter;
    public int LazerCounter
    {
        get { return lazerCounter; }
        set { lazerCounter = value; }
    }

    int gatlingCounter;
    public int GatlingCounter
    {
        get { return gatlingCounter; }
        set { gatlingCounter = value; }
    }

    float gameSpeed;
    public float GameSpeed
    {
        get { return gameSpeed;  }
    }

    bool firstGatlingSpawned;
    bool firstLazerSpawned;

    int[] numOfLazerArray;

    bool hasLoopStarted;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("Theme_Intro");
        audioManager.introStarted = true;
        hasLoopStarted = false;

        //load asteroid objects from resources folder
        asteroid1 = Resources.Load("Asteroids/AsteroidSpawn1") as GameObject;
        asteroid2 = Resources.Load("Asteroids/AsteroidSpawn2") as GameObject;
        asteroid3 = Resources.Load("Asteroids/AsteroidSpawn3") as GameObject;
        asteroid4 = Resources.Load("Asteroids/AsteroidSpawn4") as GameObject;

        lazerEnemyController = Resources.Load("Enemies/EnemyController/Controller") as GameObject;
        gatlingEnemyController = Resources.Load("Enemies/EnemyController/Controller") as GameObject;

        //Add all the asteroids to the list
        asteroids.Add(asteroid1);
        asteroids.Add(asteroid2);
        asteroids.Add(asteroid3);
        asteroids.Add(asteroid4);

        //Set the number of asteroids to
        largeAsteroidCount = 25;

        //Set boundary positions
        spawnBoundaryXP = spawnBoundary.transform.position.x;
        spawnBoundaryYP = spawnBoundary.transform.position.y;
        spawnBoundaryZP = spawnBoundary.transform.position.z;

        //Set boundary scales
        spawnBoundaryXS = spawnBoundary.transform.localScale.x;
        spawnBoundaryYS = spawnBoundary.transform.localScale.y;
        spawnBoundaryZS = spawnBoundary.transform.localScale.z;

        AsteroidSpawn();

        gameSpeed = 1;

        gatlingCounter = 1;
        lazerCounter = 2;

        firstGatlingSpawned = false;
        firstLazerSpawned = false;


        numOfLazerArray = new int[] { 2, 3, 4, 6, 8 };
        Debug.Log(numOfLazerArray.Length);
    }


    void FixedUpdate()
    {
        AudioSwitch();
        PauseGame();

        timer += Time.deltaTime;
        asteroidTimer += Time.deltaTime * gameSpeed;
        speedTimer += Time.deltaTime;

        if (asteroidTimer >= 12f)
        {
            AsteroidSpawn();
            asteroidTimer = 0;
        }

        if (speedTimer > 30)
        {
            gameSpeed += 0.25f;
            Debug.Log("Game Speed = " + gameSpeed);
            speedTimer = 0f;
        }

        if (timer > 15 && !firstLazerSpawned)
        {
            SpawnLazer();
            firstLazerSpawned = true;
        }

        if (timer > 30 && !firstGatlingSpawned)
        {
            SpawnGatling();
            firstGatlingSpawned = true;
        }
    }

    void AsteroidSpawn()
    {
        for (int i = 0; i < largeAsteroidCount; i++)
        {
            Vector3 asteroidSpawnPosition =
                new Vector3(
                Random.Range(spawnBoundaryXP - spawnBoundaryXS * 0.5f, spawnBoundaryXP + spawnBoundaryXS * 0.5f),
                Random.Range(spawnBoundaryYP - spawnBoundaryYS * 0.5f, spawnBoundaryYP + spawnBoundaryYS * 0.5f),
                Random.Range(spawnBoundaryZP - spawnBoundaryZS * 0.5f, spawnBoundaryZP + spawnBoundaryZS * 0.5f)
                );
      
            Instantiate(asteroids[Random.Range(1, 4)], asteroidSpawnPosition, Quaternion.identity);
        }
    }

    

    public void SpawnLazer()
    {
        GameObject lazerEnemy = Instantiate(lazerEnemyController);
        lazerEnemy.GetComponent<EnemySpawn>().isGatlingEnemy = false;

        if (lazerCounter > 8)
        {
            int index = Random.Range(0, numOfLazerArray.Length - 1);
            lazerEnemy.GetComponent<EnemySpawn>().numOfEnemies = numOfLazerArray[index];
        }
        else if (lazerCounter == 5 || lazerCounter == 7)
        {
            lazerEnemy.GetComponent<EnemySpawn>().numOfEnemies = lazerCounter - 1;
        }
        else
        {
            lazerEnemy.GetComponent<EnemySpawn>().numOfEnemies = lazerCounter;
        }

        lazerEnemy.GetComponent<EnemySpawn>().radius = 575;
        lazerEnemy.transform.position = new Vector3(11000, 110, 0);
    }
    public void SpawnGatling()
    {
        GameObject gatlingEnemy = Instantiate(gatlingEnemyController);
        gatlingEnemy.GetComponent<EnemySpawn>().isGatlingEnemy = true;

        if (gatlingCounter > 8)
        {
            gatlingEnemy.GetComponent<EnemySpawn>().numOfEnemies = Random.Range(1, 8);
        }

        else
        {
            gatlingEnemy.GetComponent<EnemySpawn>().numOfEnemies = gatlingCounter;
        }

        gatlingEnemy.GetComponent<EnemySpawn>().radius = Random.Range(400, 500);
        gatlingEnemy.transform.position = new Vector3(11000, 110, 0);
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            SceneManager.LoadScene("Pause_Menu", LoadSceneMode.Additive);
            if (audioManager.IsPlaying("Theme_Intro"))
            {
                audioManager.isPaused = "Theme_Intro";
                audioManager.Pause("Theme_Intro");
            }
            else
            {
                audioManager.isPaused = "Theme_Loop";
                audioManager.Pause("Theme_Loop");
            }
            //audioManager.Pause("Theme_Loop");
            audioManager.Play("Pause_Loop");
        }
    }

    void AudioSwitch()
    {
        if (audioManager == null)
        {
            Debug.LogWarning("AudioManager Not found");
            
        }
        if (audioManager.introStarted && !audioManager.IsPlaying("Theme_Intro") && hasLoopStarted == false)
        {
            audioManager.Play("Theme_Loop");
            hasLoopStarted = true;
        }
    }

}
