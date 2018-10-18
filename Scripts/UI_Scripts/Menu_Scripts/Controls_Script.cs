using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controls_Script : MonoBehaviour {

    GameObject back_button;
    Button bButton;

	// Use this for initialization
	void Start () {
        back_button = transform.Find("Back_Text").gameObject;
        bButton = back_button.GetComponent<Button>();

        bButton.onClick.AddListener(Back);
	}

    void Back()
    {
        SceneManager.UnloadSceneAsync("Controls_Menu");
    }
}
