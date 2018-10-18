using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk_Switch_Controller : MonoBehaviour {

	bool isSwitch_L_Up;
	bool isSwitch_M_Up;
	bool isSwitch_R_Up;

	Renderer switch_L_Base_Rend, switch_M_Base_Rend, switch_R_Base_Rend;
	GameObject switchL, switchM, switchR;

	GameObject shield_Object, weapons_Mod_Obj_R, weapons_Mod_Obj_L;
	Renderer shield_Rend, weapons_Mod_Rend_R, weapons_Mod_Rend_L;

	int shieldModifier;
	public int ShieldModifier
	{
		get { return shieldModifier; }
	}

	int weaponModifier;
	public int WeaponModifier {
		get { return weaponModifier; }
	}

	private GameObject weaponsModifierTextObject;
    private GameObject shieldModifierTextObject;

	// Use this for initialization
	void Start () {

		switch_L_Base_Rend = transform.Find("Switch_L_Base").GetComponent<Renderer>();
		switch_M_Base_Rend = transform.Find("Switch_M_Base").GetComponent<Renderer>();
		switch_R_Base_Rend = transform.Find("Switch_R_Base").GetComponent<Renderer>();

		switchL = transform.Find("Switch_L_Base").Find("Switch_L").gameObject;
		switchM = transform.Find("Switch_M_Base").Find("Switch_M").gameObject;
		switchR = transform.Find("Switch_R_Base").Find("Switch_R").gameObject;

		shield_Object = transform.parent.parent.parent.Find("Shield_Obj").gameObject;
        weapons_Mod_Obj_R = transform.parent.parent.parent.Find("Weapons_Modifier_Top").Find("Weapons_Mod_R").gameObject;
        weapons_Mod_Obj_L = transform.parent.parent.parent.Find("Weapons_Modifier_Top").Find("Weapons_Mod_L").gameObject;

        shield_Rend = shield_Object.GetComponent<Renderer>();
        weapons_Mod_Rend_R = weapons_Mod_Obj_R.GetComponent<Renderer>();
        weapons_Mod_Rend_L = weapons_Mod_Obj_L.GetComponent<Renderer>();


        weaponsModifierTextObject = transform.Find("Switch_Text_Object").Find("Weapons_Variable_Text").gameObject;
		shieldModifierTextObject = transform.Find("Switch_Text_Object").Find("Shields_Variable_Text").gameObject;

		shieldModifier = 3;
		weaponModifier = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (shieldModifier > 0)
		{
			shield_Rend.material.SetFloat("_Shield_Value", (1f - (shieldModifier * 0.5f)));
		}
		else
		{
			shield_Rend.material.SetFloat("_Shield_Value", 1f);

		}

        if (weaponModifier > 0)
        {
            weapons_Mod_Rend_R.material.SetFloat("_Shield_Value", (1f - (weaponModifier * 0.5f)));
            weapons_Mod_Rend_L.material.SetFloat("_Shield_Value", (1f - (weaponModifier * 0.5f)));
        }
        else
        {
            weapons_Mod_Rend_R.material.SetFloat("_Shield_Value", 1f);
            weapons_Mod_Rend_L.material.SetFloat("_Shield_Value", 1f);
        }

            weaponsModifierTextObject.GetComponent<TMPro.TextMeshPro>().SetText("x" + (1 + weaponModifier));
		shieldModifierTextObject.GetComponent<TMPro.TextMeshPro>().SetText("x" + (1 + shieldModifier));
	}

	public void UseSwitchL()
	{
		isSwitch_L_Up = !isSwitch_L_Up;
		
		ChangeColour(switch_L_Base_Rend, isSwitch_L_Up);
		RotateSwitch(switchL, isSwitch_L_Up);

		ChangeModifier(isSwitch_L_Up);

		Debug.Log(isSwitch_L_Up);
	}

	public void UseSwitchM()
	{
		isSwitch_M_Up = !isSwitch_M_Up;

		ChangeColour(switch_M_Base_Rend, isSwitch_M_Up);
		RotateSwitch(switchM, isSwitch_M_Up);
		ChangeModifier(isSwitch_M_Up);


		Debug.Log(isSwitch_M_Up);
	}

	public void UseSwitchR()
	{
		isSwitch_R_Up = !isSwitch_R_Up;

		ChangeColour(switch_R_Base_Rend, isSwitch_R_Up);
		RotateSwitch(switchR, isSwitch_R_Up);
		ChangeModifier(isSwitch_R_Up);


		Debug.Log(isSwitch_R_Up);
	}

	void ChangeColour(Renderer rend, bool switchPosition)
	{
		int colourValue;
		if (switchPosition)
		{			
			colourValue = 1;
		}
		else{
			colourValue = 0;
		}

		rend.material.SetInt("_Switch_Base_Blend", colourValue);
	}

	void RotateSwitch(GameObject thisSwitch, bool switchPosition)
	{
		thisSwitch.GetComponent<RotateSwitch>().IsSwitchUp = switchPosition;
	}

	void ChangeModifier (bool switchIsUp)
	{
		if (switchIsUp)
		{
			weaponModifier++;
			shieldModifier--;
		}
		else {
			weaponModifier--;
			shieldModifier++;
		}
	}
}
