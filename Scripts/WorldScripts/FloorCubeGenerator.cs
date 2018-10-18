using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCubeGenerator : MonoBehaviour {

    GameObject cube; //The Cube object that is used as another brick in the wall.
    public int rows; //Number of rows of the wall
    public int columns; //number of columns of of the wall

    private Vector3 cubePosition; //The position of the individual brick
    private int currentRow; //Used by the 
    private int currentColumn;

    // Use this for initialization
    void Start () {
        cube = Resources.Load("World_Resources/BorderCube") as GameObject;

        currentRow = 1;
        currentColumn = 1;

        //Vector3[] verts;

        //for (int i = 0; i < (rows * columns); i++)
        //{
        while (currentColumn <= columns)
        {
            while (currentRow <= rows)
            {
                cubePosition = new Vector3(
                transform.position.x + (currentColumn * cube.transform.localScale.x),
                transform.position.y,
                transform.position.z + (currentRow * cube.transform.localScale.z)
                );
                GameObject cubeSpawned = Instantiate(cube) as GameObject;
                cubeSpawned.name = "cube: Row " + currentRow + " , Column " + currentColumn;
                cubeSpawned.GetComponent<WallCubeMovement>().isVertical = true;
                    
                cubeSpawned.transform.parent = gameObject.transform;
                cubeSpawned.transform.position = cubePosition;
                currentRow++;
            }
            currentColumn++;
            currentRow = 1;
        }         
       // }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
