using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Switch_OnClick : MonoBehaviour {

	Desk_Switch_Controller desk_Switch_Controller;
	GameObject switch_L_Button, switch_M_Button, switch_R_Button;
	Button buttonL, buttonM, buttonR;


	// Use this for initialization
	void Start () {

		desk_Switch_Controller = transform.parent.GetComponent<Desk_Switch_Controller>();

		switch_L_Button = gameObject.transform.Find("Switch_UI_Canvas").Find("Switch_L_Button").gameObject;
		switch_M_Button = gameObject.transform.Find("Switch_UI_Canvas").Find("Switch_M_Button").gameObject;
		switch_R_Button = gameObject.transform.Find("Switch_UI_Canvas").Find("Switch_R_Button").gameObject;

		buttonL = switch_L_Button.GetComponent<Button>();
		buttonM = switch_M_Button.GetComponent<Button>();
		buttonR = switch_R_Button.GetComponent<Button>();

		buttonL.onClick.AddListener(SwitchL);
		buttonM.onClick.AddListener(SwitchM);
		buttonR.onClick.AddListener(SwitchR);
	}

	void SwitchL()
	{
		desk_Switch_Controller.UseSwitchL();

		//Debug.Log(isSwitch_L_Up);
	}
	void SwitchM()
	{
		desk_Switch_Controller.UseSwitchM();

		//Debug.Log(isSwitch_M_Up);
	}
	void SwitchR()
	{
		desk_Switch_Controller.UseSwitchR();

		//Debug.Log(isSwitch_R_Up);
	}


}

