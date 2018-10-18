using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leaderboard_Script : MonoBehaviour {

    GameObject firstScoreVariable, secondScoreVariable, thirdScoreVariable, fourthScoreVariable, fifthScoreVariable;

    GameObject back_Button, clear_Button;
    Button bButton, cButton;


	// Use this for initialization
	void Start () {
        back_Button = transform.Find("Back_Text").gameObject;
        clear_Button = transform.Find("Clear_Text").gameObject;

        bButton = back_Button.GetComponent<Button>();
        cButton = clear_Button.GetComponent<Button>();

        bButton.onClick.AddListener(Back);
        cButton.onClick.AddListener(Clear);


        firstScoreVariable = transform.Find("FirstPlace_Variable_Text").gameObject;
        secondScoreVariable = transform.Find("SecondPlace_Variable_Text").gameObject;
        thirdScoreVariable = transform.Find("ThirdPlace_Variable_Text").gameObject;
        fourthScoreVariable = transform.Find("FourthPlace_Variable_Text").gameObject;
        fifthScoreVariable = transform.Find("FifthPlace_Variable_Text").gameObject;



        firstScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText(""+PlayerPrefs.GetInt("1Score"));
        secondScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + PlayerPrefs.GetInt("2Score"));
        thirdScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + PlayerPrefs.GetInt("3Score"));
        fourthScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + PlayerPrefs.GetInt("4Score"));
        fifthScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + PlayerPrefs.GetInt("5Score"));
    }

    // Update is called once per frame
    void Update () {
        firstScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + PlayerPrefs.GetInt("1Score"));
        secondScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + PlayerPrefs.GetInt("2Score"));
        thirdScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + PlayerPrefs.GetInt("3Score"));
        fourthScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + PlayerPrefs.GetInt("4Score"));
        fifthScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + PlayerPrefs.GetInt("5Score"));
    }

    void Back()
    {
        SceneManager.UnloadSceneAsync("Leaderboard_Menu");
    }

    void Clear()
    {
        PlayerPrefs.DeleteAll();
    }
}
