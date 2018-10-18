using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorMath;

/*++++++++ WARNING: LEAVE SCRIPT DISABLED ++++++++++++++
 * This is because the script needs to be enabled after all the enemies have been spawned.
 * The script is enabled in the LazerController class.
*/

public class DrawLines : MonoBehaviour {

    public int numOfEnemies;
    LineRenderer lr1, lr2, lr3, lr4, lr5, lr6;
    // GameObject lineObj1, lineObj2, lineObj3;

    GameObject cyl; //The Cylinder object is used as a lazer;
    GameObject lazer1, lazer2, lazer3, lazer4, lazer5, lazer6;
    float cylSX, cylSY, cylSZ; //The starting scale of the cylinder object.



	// Use this for initialization
	IEnumerator Start () {

        cyl = Resources.Load("Enemies/Ships/Lazer") as GameObject;
        if (cyl == null)
        {
            Debug.Log("lazer object not found");
        }
        numOfEnemies = gameObject.GetComponent<EnemyDirectionController>().enemies.Count;
        //Store the initial scale of the cylinder (lazer).
        cylSX = cyl.transform.localScale.x;
        cylSY = cyl.transform.localScale.y;
        cylSZ = cyl.transform.localScale.z;

        if (numOfEnemies != 0)
        {
            WhichFormationStart();
        }
        else
        {
            Debug.Log("No enemies found.");
        }

        yield return null;
        
    }
	
	// Update is called once per frame
	void Update () {
        numOfEnemies = gameObject.GetComponent<EnemyDirectionController>().enemies.Count;
        if (numOfEnemies != 0)
        {
            WhichFormationUpdate();
        }
        else
        {
            Debug.Log("No enemies found.");
        }
        //Debug.Log(numOfEnemies);
	}



    /*
     * The following function decides which formation of lines (lasers) should be initialised
    */
    void WhichFormationStart()
    {
        if ((numOfEnemies == 2) || (numOfEnemies == 3) || (numOfEnemies == 4) || (numOfEnemies == 6) || (numOfEnemies == 8))
        {
            switch (numOfEnemies)
            {
                case 2:
                    OneLineStart();
                    break;
                case 3:
                    ThreeLinesStart();
                    break;
                case 4:
                    TwoLinesStart();
                    break;
                case 6:
                    SixLinesStart();
                    break;
                case 8:
                    FourLinesStart();
                    break;
            }
        }
    }

    /*
     * The following function decides which formation of lines (lasers) should be updated
    */
    void WhichFormationUpdate()
    {
        if ((numOfEnemies == 2) || (numOfEnemies == 3) || (numOfEnemies == 4) || (numOfEnemies == 6) || (numOfEnemies == 8))
        {
            switch (numOfEnemies)
            {
                case 2:
                    OneLineUpdate();
                    break;
                case 3:
                    ThreeLinesUpdate();
                    break;
                case 4:
                    TwoLinesUpdate();
                    break;
                case 6:
                    SixLinesUpdate();
                    break;
                case 8:
                    FourLinesUpdate();
                    break;
            }
        }
    }


    //==============================START METHODS===================================


    void OneLineStart()
    {
        lazer1 = Instantiate(cyl, gameObject.transform) as GameObject;
    }

    void TwoLinesStart()
    {
        lazer1 = Instantiate(cyl, gameObject.transform) as GameObject;
        lazer2 = Instantiate(cyl, gameObject.transform) as GameObject;
    }

    void ThreeLinesStart()
    {
        lazer1 = Instantiate(cyl, gameObject.transform) as GameObject;
        lazer2 = Instantiate(cyl, gameObject.transform) as GameObject;
        lazer3 = Instantiate(cyl, gameObject.transform) as GameObject;
    }

    void FourLinesStart()
    {
        lazer1 = Instantiate(cyl, gameObject.transform) as GameObject;
        lazer2 = Instantiate(cyl, gameObject.transform) as GameObject;
        lazer3 = Instantiate(cyl, gameObject.transform) as GameObject;
        lazer4 = Instantiate(cyl, gameObject.transform) as GameObject;
    }

    void SixLinesStart()
    {
        lazer1 = Instantiate(cyl, gameObject.transform) as GameObject;
        lazer2 = Instantiate(cyl, gameObject.transform) as GameObject;
        lazer3 = Instantiate(cyl, gameObject.transform) as GameObject;
        lazer4 = Instantiate(cyl, gameObject.transform) as GameObject;
        lazer5 = Instantiate(cyl, gameObject.transform) as GameObject;
        lazer6 = Instantiate(cyl, gameObject.transform) as GameObject;
    }

    //==============================START METHODS===================================


    //==============================UPDATE METHODS==================================

    void OneLineUpdate()
    {
        float timer =+ Time.deltaTime;

        GameObject e1 = gameObject.GetComponent<EnemyDirectionController>().enemies[0].transform.Find("LazerGenerator").gameObject;
        GameObject e2 = gameObject.GetComponent<EnemyDirectionController>().enemies[1].transform.Find("LazerGenerator").gameObject;




        LazerMovement(lazer1, e1.transform.position, e2.transform.position);

    }

    void TwoLinesUpdate()
    {
        float timer = Time.deltaTime;

        GameObject e1 = gameObject.GetComponent<EnemyDirectionController>().enemies[0].transform.Find("LazerGenerator").gameObject;
        GameObject e2 = gameObject.GetComponent<EnemyDirectionController>().enemies[1].transform.Find("LazerGenerator").gameObject;
        GameObject e3 = gameObject.GetComponent<EnemyDirectionController>().enemies[2].transform.Find("LazerGenerator").gameObject;
        GameObject e4 = gameObject.GetComponent<EnemyDirectionController>().enemies[3].transform.Find("LazerGenerator").gameObject;

        //Debug.Log(lazer1.transform.position);
        LazerMovement(lazer1, e1.transform.position, e3.transform.position);
        LazerMovement(lazer2, e2.transform.position, e4.transform.position);

    }

    void ThreeLinesUpdate()
    {
        GameObject e1 = gameObject.GetComponent<EnemyDirectionController>().enemies[0].transform.Find("LazerGenerator").gameObject;
        GameObject e2 = gameObject.GetComponent<EnemyDirectionController>().enemies[1].transform.Find("LazerGenerator").gameObject;
        GameObject e3 = gameObject.GetComponent<EnemyDirectionController>().enemies[2].transform.Find("LazerGenerator").gameObject;

        LazerMovement(lazer1, e1.transform.position, e2.transform.position);
        LazerMovement(lazer2, e2.transform.position, e3.transform.position);
        LazerMovement(lazer3, e3.transform.position, e1.transform.position);
    }

    void FourLinesUpdate()
    {
        GameObject e1 = gameObject.GetComponent<EnemyDirectionController>().enemies[0].transform.Find("LazerGenerator").gameObject;
        GameObject e2 = gameObject.GetComponent<EnemyDirectionController>().enemies[1].transform.Find("LazerGenerator").gameObject;
        GameObject e3 = gameObject.GetComponent<EnemyDirectionController>().enemies[2].transform.Find("LazerGenerator").gameObject;
        GameObject e4 = gameObject.GetComponent<EnemyDirectionController>().enemies[3].transform.Find("LazerGenerator").gameObject;
        GameObject e5 = gameObject.GetComponent<EnemyDirectionController>().enemies[4].transform.Find("LazerGenerator").gameObject;
        GameObject e6 = gameObject.GetComponent<EnemyDirectionController>().enemies[5].transform.Find("LazerGenerator").gameObject;
        GameObject e7 = gameObject.GetComponent<EnemyDirectionController>().enemies[6].transform.Find("LazerGenerator").gameObject;
        GameObject e8 = gameObject.GetComponent<EnemyDirectionController>().enemies[7].transform.Find("LazerGenerator").gameObject;

        LazerMovement(lazer1, e1.transform.position, e6.transform.position);
        LazerMovement(lazer2, e2.transform.position, e5.transform.position);
        LazerMovement(lazer3, e3.transform.position, e8.transform.position);
        LazerMovement(lazer4, e4.transform.position, e7.transform.position);
    }

    void SixLinesUpdate()
    {
        GameObject e1 = gameObject.GetComponent<EnemyDirectionController>().enemies[0].transform.Find("LazerGenerator").gameObject;
        GameObject e2 = gameObject.GetComponent<EnemyDirectionController>().enemies[1].transform.Find("LazerGenerator").gameObject;
        GameObject e3 = gameObject.GetComponent<EnemyDirectionController>().enemies[2].transform.Find("LazerGenerator").gameObject;
        GameObject e4 = gameObject.GetComponent<EnemyDirectionController>().enemies[3].transform.Find("LazerGenerator").gameObject;
        GameObject e5 = gameObject.GetComponent<EnemyDirectionController>().enemies[4].transform.Find("LazerGenerator").gameObject;
        GameObject e6 = gameObject.GetComponent<EnemyDirectionController>().enemies[5].transform.Find("LazerGenerator").gameObject;

        if (lazer1 == null)
        { Debug.Log("lazer1 not loaded"); }
        else if (e1.transform.position == null)
        { Debug.Log("Enemy1 (e1) not found!"); }
        else
        {
            LazerMovement(lazer1, e1.transform.position, e3.transform.position);
            LazerMovement(lazer2, e2.transform.position, e4.transform.position);
            LazerMovement(lazer3, e3.transform.position, e5.transform.position);
            LazerMovement(lazer4, e4.transform.position, e6.transform.position);
            LazerMovement(lazer5, e5.transform.position, e1.transform.position);
            LazerMovement(lazer6, e6.transform.position, e2.transform.position);
        }
    }

    //==============================UPDATE METHODS==================================

    void LazerMovement(GameObject lazer, Vector3 startPos, Vector3 endPos)
    {
        Vector3 direction = VectorFunc.Direction(startPos, endPos);
        float distance = VectorFunc.Distance(startPos, endPos);

        if (lazer != null)
        {
            lazer.transform.position = startPos;
            lazer.transform.LookAt(endPos);
            //Set the scale of the cyl. The x & y values remain the same but the z value is equal to the distance * initial z value.
            lazer.transform.localScale = new Vector3(
                lazer.transform.localScale.x,
                lazer.transform.localScale.y,
                distance * cylSZ
                );
        }
        else
        {
            Debug.Log("Lazer not found.");
        }
    }
}
