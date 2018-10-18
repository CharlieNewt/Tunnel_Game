using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj_Indicator_Switch : MonoBehaviour
{

    GameObject alpha, beta, gamma;
    int whichProjInidcator;
    public int WhichProjIndicator
    {
        set { whichProjInidcator = value; }
    }


    private void Start()
    {
        alpha = transform.Find("Alphas_Top").gameObject;
        beta = transform.Find("BetaProjectile").gameObject;
        gamma = transform.Find("GammaProjectile").gameObject;
    }

    private void Update()
    {
       // Debug.Log(GameObject.Find("ProjectileCannons").GetComponent<ProjectileShooter>().gunSelection);
        whichProjInidcator = GameObject.Find("ProjectileCannons").GetComponent<ProjectileShooter>().gunSelection;
        switch (whichProjInidcator)
        {
            case 1:
                alpha.SetActive(true);

                beta.SetActive(false);
                gamma.SetActive(false);
                break;
            case 2:
                beta.SetActive(true);

                alpha.SetActive(false);
                gamma.SetActive(false);
                break;
            case 3:
                gamma.SetActive(true);

                alpha.SetActive(false);
                beta.SetActive(false);
                break;


        }
    }
}
