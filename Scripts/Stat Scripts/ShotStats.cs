using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotStats : MonoBehaviour {

    GameObject switchObj;
	private float shotDamage;
    public float ShotDamage
    {
        get { return shotDamage; }
        set { shotDamage = value; }
    }

    void Start()
    {
        if ((gameObject.tag == "AlphaProjectile") || (gameObject.tag == "BetaProjectile") || (gameObject.tag == "GammaProjectile"))
        {
        switchObj = GameObject.FindWithTag("Desk_Top");
        float weaponModifier = switchObj.GetComponent<Desk_Switch_Controller>().WeaponModifier;
        shotDamage = shotDamage * (1 + weaponModifier);
        }
    }

    void FixedUpdate() {
        if (gameObject.tag == "BetaProjectile")
        {
            transform.Rotate(10, 0, 0);
        }
    }
}
