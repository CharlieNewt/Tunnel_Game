using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj_Indicator_Swap : MonoBehaviour
{

    public float spinSpeed = 0.1f;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, spinSpeed, 0);
    }
}
