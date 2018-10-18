using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCharge : MonoBehaviour {

    float shotCharge;
    
    int gunSelection;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        gunSelection = GameObject.Find("ProjectileCannons").GetComponent<ProjectileShooter>().gunSelection;
        if (gunSelection == 1)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            return;
        }
        else if (gunSelection == 2)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            shotCharge = GameObject.Find("ProjectileCannons").GetComponent<ProjectileShooter>().shotCount;
            shotCharge = (shotCharge) / 9;
        }

        else if (gunSelection == 3)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            shotCharge = GameObject.Find("ProjectileCannons").GetComponent<ProjectileShooter>().gammaSize;
            shotCharge = (shotCharge + 1) / 5;

            if (shotCharge > 1)
            {
                shotCharge = 1;
            }
        }
        
        gameObject.transform.localScale = new Vector3 (1f, 1f, shotCharge);
	}
}
