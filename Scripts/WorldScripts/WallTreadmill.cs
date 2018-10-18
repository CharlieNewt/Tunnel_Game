using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTreadmill : MonoBehaviour
{
    GameObject cube;
    float timer;
    float timerInt;
    float i;

    int cubeCounter;

    public Vector3 EnemyCtrlStartPos;

    void Start()
    {
        //cube = Resources.Load("World_Resources/BorderCube") as GameObject;
        Debug.Log("WallTreadmill script has started");

        i = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BorderCube")
        {
            Vector3 cubePosition = new Vector3(
            4080f,
            other.GetComponent<WallCubeMovement>().y,
            other.GetComponent<WallCubeMovement>().z
            );

            GameObject cube = Resources.Load("World_Resources/BorderCube") as GameObject;

            other.transform.position = cubePosition;

            cubeCounter++;
            if (cubeCounter % 6 == 0)
            {
                GameObject.Find("ship_draft").GetComponent<PlayerStats>().PlayerScore++;
            }
            return;
        }

        if (other.tag == "EnemyController_CollisionBox")
        {
            int respawnController = other.GetComponent<Controller_CollisionBox>().RespawnCounter;
            if (respawnController <= 2)
            {
                

                other.transform.position = new Vector3(5000, other.transform.position.y, other.transform.position.z);
                respawnController++;
                other.GetComponent<Controller_CollisionBox>().RespawnCounter = respawnController;

                Debug.Log(respawnController);
                return;
            }
            else
            {
                if (other.GetComponent<EnemySpawn>().isGatlingEnemy)
                {
                    GameObject.Find("GameController").GetComponent<GameController>().GatlingCounter++;
                    GameObject.Find("GameController").GetComponent<GameController>().SpawnGatling();
                }
                else
                {
                    GameObject.Find("GameController").GetComponent<GameController>().LazerCounter++;
                    GameObject.Find("GameController").GetComponent<GameController>().SpawnLazer();
                }
                Destroy(other.gameObject);
                Debug.Log("EnemyDestroyed");
            }
        }
    }
}
