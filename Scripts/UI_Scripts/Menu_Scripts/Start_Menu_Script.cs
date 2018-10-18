using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_Menu_Script : MonoBehaviour
{
    /// <summary>
    /// The objects the have the button component
    /// </summary>
    GameObject play_Button, controls_Button, leaderboard_Button, quit_Button;

    /// <summary>
    /// The button components.
    /// </summary>
    Button pButton, cButton, lButton, qButton;

    AudioManager audioManager;

    // Use this for initialization
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (!audioManager.IsPlaying("Pause_Loop"))
        {
            audioManager.Play("Pause_Loop");
        }

        play_Button = transform.Find("Play_Text").gameObject;
        controls_Button = transform.Find("Controls_Text").gameObject;
        leaderboard_Button = transform.Find("Leaderboard_Text").gameObject;
        quit_Button = transform.Find("Quit_Text").gameObject;

        pButton = play_Button.GetComponent<Button>();
        cButton = controls_Button.GetComponent<Button>();
        lButton = leaderboard_Button.GetComponent<Button>();
        qButton = quit_Button.GetComponent<Button>();

        pButton.onClick.AddListener(Play);
        cButton.onClick.AddListener(ShowControls);
        lButton.onClick.AddListener(ShowLeaderboard);
        qButton.onClick.AddListener(QuitGame);
    }

    void Play()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
        Debug.Log("Play Pressed!");

        Time.timeScale = 1.0f;

        audioManager.Stop("Pause_Loop");
        //PlayerPrefs.DeleteAll();
    }

    void ShowControls()
    {
        SceneManager.LoadScene("Controls_Menu", LoadSceneMode.Additive);

    }

    void ShowLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard_Menu", LoadSceneMode.Additive);

    }

    void QuitGame()
    {
        Application.Quit();
    }
}
    
