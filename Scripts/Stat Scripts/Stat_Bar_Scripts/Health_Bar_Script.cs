using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Bar_Script : MonoBehaviour {

    private float xScale;
    private float yScale;
    private float zScale;
    //DELETE WHEN TESTS ARE DONT
    private float zTemp;
    private Color fullHealth;
    private Color halfHealth;
    private Color lowHealth;


    //public GameObject health_outer;
    private Renderer outer_rend;

	// Use this for initialization
	void Start () {
        xScale = transform.localScale.x;
        yScale = transform.localScale.y;
        zScale = 0f;
        //DELETE WHEN TESTS ARE DONT
                zTemp = transform.parent.parent.parent.parent.GetComponent<PlayerStats>().PlayerHealth * 0.01f;


        //outer_rend = health_outer.GetComponent<Renderer>();

        fullHealth = new Color(0, 191, 33);
        halfHealth = new Color(191, 176, 0);
        lowHealth = new Color(191, 0, 12);
    }
	
	// Update is called once per frame
	void Update () {
        zTemp = transform.parent.parent.parent.parent.GetComponent<PlayerStats>().PlayerHealth * 0.01f;

        //DELETE WHEN TESTS ARE DONT
        if (zTemp > 1f)
        {
            zScale = 1f;
        }
        else
        {
            zScale = zTemp;
        }

        transform.localScale = new Vector3 (xScale, yScale, zScale);

        //ChangeColor();
        
    }

    // void ChangeColor()
    // {
    //     if (zScale > 0.6f)
    //     {
    //         outer_rend.material.SetColor("Color_8BB2B428", fullHealth);
    //     }
    //     else if ((zScale <= 0.6f) && (zScale > 0.2f))
    //     {
    //         outer_rend.material.SetColor("Color_8BB2B428", halfHealth);
    //     }
    //     else
    //     {
    //         outer_rend.material.SetColor("Color_8BB2B428", lowHealth);
    //     }
    //}
}
