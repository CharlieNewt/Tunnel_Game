using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The following class is used to determine which object in the scene should be "focused" by the projectile.
 * In the case of the alpha projectile this is used to focus the two lazers to converge on the object.
 * 
 * If an object is in the layer "2: Ignore Raycast" then it will not break the ray.
 */
public class ProjectileRay : MonoBehaviour {

    //RaycastHit hit;
    Ray ray;
    RaycastHit hit;

    private Vector3 rayBreak;
    public Vector3 RayBreak
    {
        get { return rayBreak; }
    }

	// Use this for initialization
	
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 right = transform.TransformDirection(transform.right);
        ray.origin = transform.position;
        ray.direction = right;

        // if (Physics.Raycast(ray, out hit, 4000))
        // {
        //     rayBreak = hit.collider.gameObject.transform.position;
        // }

        //else
        //{
            rayBreak = transform.position + (transform.right * 3000f);
        //}
	}

    public Vector3 DirectionToRayBreak(Vector3 startPosition)
    {
        Vector3 heading = rayBreak - startPosition;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        return direction;
    }
}
