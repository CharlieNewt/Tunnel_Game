using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

//https://www.youtube.com/watch?time_continue=50&v=GIatyq9KT28
	void OnTriggerExit(Collider other)
	{
        if (other.tag == "EnemyController_CollisionBox")
        {
            return;
        }

        if (other.tag == "Lazer")
        {
            return;
        }

		Destroy(other.gameObject);
	}
}
