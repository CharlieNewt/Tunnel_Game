using System.Collections;       
using System.Collections.Generic;
using UnityEngine;

public class WallCubeGenerator : MonoBehaviour {

    GameObject cube; //The Cube object that is used as another brick in the wall.
    public int rows; //Number of rows of the wall
    public int columns; //number of columns of of the wall

    private Vector3 cubePosition; //The position of the individual brick
    private int currentRow; 
    private int currentColumn;

    // Use this for initialization
    void Start()
    {
        //Load the cube so that it is readdy to be instantiated
        cube = Resources.Load("World_Resources/BorderCube") as GameObject;

        currentRow = 1; //Start at the first row,
        currentColumn = 1; // and the first column.

        //While the current column is less than the number of columns
        while (currentColumn <= columns)
        {
            //While the current row is less than the number of rows
            while (currentRow <= rows)
            {
                //Set the cubes position relative to its current row and column
                cubePosition = new Vector3(
                transform.position.x + (currentColumn * cube.transform.localScale.x),
                transform.position.y + (currentRow * cube.transform.localScale.y),
                transform.position.z
                );
                //Spawn the cube and name the cube relative to its row and column
                GameObject cubeSpawned = Instantiate(cube) as GameObject;
                cubeSpawned.name = "cube: Row " + currentRow + " , Column " + currentColumn;

                //make the cubes parent the object that has the cube spawn component
                cubeSpawned.transform.parent = gameObject.transform;
                // and then set the position of the cube to the specified position above
                cubeSpawned.transform.position = cubePosition;
                currentRow++; //Increase the current row value to move onto spawning the next cube
            }
            //When then currentRow has exceeded the number of rows value,
            // the next column is started and the current row value is reset.
            currentColumn++;
            currentRow = 1;

        }
    }
}
