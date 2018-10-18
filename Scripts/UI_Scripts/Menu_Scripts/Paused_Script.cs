using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Paused_Script : MonoBehaviour
{
    AudioManager audioManager;

    GameObject resume_Button, controls_Button, main_Menu_Button;
    Button rButton, cButton, lButton, mMButton;

    // Use this for initialization
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        resume_Button = transform.Find("Resume_Text").gameObject;
        controls_Button = transform.Find("Controls_Text").gameObject;
        main_Menu_Button = transform.Find("Main_Menu_Text").gameObject;

        rButton = resume_Button.GetComponent<Button>();
        cButton = controls_Button.GetComponent<Button>();
        mMButton = main_Menu_Button.GetComponent<Button>();

        rButton.onClick.AddListener(Resume);
        cButton.onClick.AddListener(ShowControls);
        mMButton.onClick.AddListener(MainMenu);
    }

    void Resume()
    {
        SceneManager.UnloadSceneAsync("Pause_Menu");
        Debug.Log("Resume Pressed!");

        Time.timeScale = 1.0f;

        if (audioManager == null)
        {
            Debug.LogWarning("AudioManager Not found");
        }
        else {
            audioManager.Pause("Pause_Loop");
            audioManager.Play(audioManager.isPaused);
        }

        //PlayerPrefs.DeleteAll();
    }

    void ShowControls()
    {
        SceneManager.LoadScene("Controls_Menu", LoadSceneMode.Additive);
    }

    void MainMenu()
    {
        SceneManager.LoadScene("Start_Menu", LoadSceneMode.Single);
    }
}

