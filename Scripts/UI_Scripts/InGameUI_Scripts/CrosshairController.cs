using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour {
	GameObject crosshair;

	Vector3 rayBreak;
	Vector2 rayBreak2D;

	Vector3 crosshairPosition;
	Vector2 crosshairPosition2D;

	Vector2 currentPosition2D;

	// Use this for initialization
	void Start () {
		if (transform.Find("Windscreen_UI_Canvas").transform.Find("Crosshair_Image") != null)
			crosshair = transform.Find("Windscreen_UI_Canvas").transform.Find("Crosshair_Image").gameObject;
		else
			Debug.Log("Crosshair_Image not found");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (transform.parent.Find("ProjectilesTOP") != null)
		{
			rayBreak = transform.parent.Find("ProjectilesTOP").transform.Find("CannonRaycast").GetComponent<ProjectileRay>().RayBreak;
			rayBreak2D = new Vector2(rayBreak.z, rayBreak.y);

			currentPosition2D = new Vector2(transform.position.z, transform.position.y);
			
			crosshairPosition2D = rayBreak2D - currentPosition2D;
			if (crosshairPosition2D.y > 70)
			{
				crosshairPosition2D.y = 70;
			}
			if (crosshairPosition2D.y < -85)
			{
				crosshairPosition2D.y = -85;
			}
			crosshairPosition = new Vector3(crosshairPosition2D.x, crosshairPosition2D.y, 0);

			if (crosshair.GetComponent<RectTransform>() != null)
			{
				crosshair.GetComponent<RectTransform>().localPosition = crosshairPosition;
				Debug.Log(crosshairPosition);
			}
			else	
				Debug.Log("RectTransform not found in Crosshair_Image");
		}

		else
			Debug.Log("Projectile Top object not found");
	}
}
