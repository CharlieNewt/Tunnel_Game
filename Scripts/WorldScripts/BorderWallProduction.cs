using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderWallProduction : MonoBehaviour
{

    GameObject cube;
    float timer;
    float timerInt;

    void Start()
    {
        cube = Resources.Load("World_Resources/BorderCube") as GameObject;

        if (cube == null)
        {
            Debug.Log("Wrong path for cube");
        }

        if (cube != null)
        {
            Debug.Log("Right path for cube");
        }

        timerInt = 0;
    }

    private void FixedUpdate()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 1)
        {
            timerInt++;
            timer = 0;

            //Debug.Log(timerInt);
        }

        if (gameObject.transform.position.x > -429 && cube != null)
            CubeProduction();

        if (cube == null)
            Debug.Log("Cube not loaded");

    }

    void CubeProduction()
    {
        Vector3 cubePosition = new Vector3(
        4200,
        gameObject.GetComponent<WallCubeMovement>().y,
        gameObject.GetComponent<WallCubeMovement>().z
        );

        Instantiate(cube, cubePosition, Quaternion.identity);

        Destroy(gameObject);

    }
}
