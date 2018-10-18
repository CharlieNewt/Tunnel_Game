using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game_Over_Script : MonoBehaviour {

    int yourScore;
    public int YourScore
    {
        set { yourScore = value;  }
    }

    AudioManager audioManager;

    GameObject yourScoreVariable;
    GameObject topScoreVariable;

    GameObject try_Again_Button, main_Menu_Button, quit_Button;

    Button tA_Button, mMButton, qButton;

    // Use this for initialization
    void Start () {
        audioManager = FindObjectOfType<AudioManager>();

        yourScoreVariable = transform.Find("Your_Score_Variable_Text").gameObject;
        topScoreVariable = transform.Find("Top_Score_Variable_Text").gameObject;
        SetScoreText();

        try_Again_Button = transform.Find("Try_Again_Text").gameObject;
        main_Menu_Button = transform.Find("Main_Menu_Text").gameObject;
        quit_Button = transform.Find("Quit_Text").gameObject;

        tA_Button = try_Again_Button.GetComponent<Button>();
        mMButton = main_Menu_Button.GetComponent<Button>();
        qButton = quit_Button.GetComponent<Button>();

        tA_Button.onClick.AddListener(TryAgain);
        mMButton.onClick.AddListener(MainMenu);
        qButton.onClick.AddListener(QuitGame);
    }
	
	// Update is called once per frame
	void Update () {
        //SceneManager.LoadScene("Menu_Scenes/Game_Over_Menu", LoadSceneMode.Single);
        //yourScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + yourScore);
        SetScoreText();
        tA_Button = try_Again_Button.GetComponent<Button>();
        mMButton = main_Menu_Button.GetComponent<Button>();
        qButton = quit_Button.GetComponent<Button>();

    }

    void SetScoreText()
    {
        if (PlayerPrefs.HasKey("yourScore"))
        {
            yourScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + PlayerPrefs.GetInt("yourScore"));
        }
        else
        {
            yourScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("Score not found");

        }

        if (PlayerPrefs.HasKey("1Score"))
        {
            topScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("" + PlayerPrefs.GetInt("1Score"));
        }
        else
        {
            topScoreVariable.GetComponent<TMPro.TextMeshProUGUI>().SetText("Score not found");
        }
    }

    void TryAgain()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
        if (audioManager == null)
        {
            Debug.LogWarning("AudioManager Not found");
        }
        else
        {
            audioManager.Stop("Pause_Loop");
        }
    }

    void MainMenu()
    {
        SceneManager.LoadScene("Start_Menu", LoadSceneMode.Single);
    }

    void QuitGame()
    {
        //Code to quit the game
        Application.Quit();
    }
}
