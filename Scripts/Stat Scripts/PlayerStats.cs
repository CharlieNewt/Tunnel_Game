using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    AudioManager audioManager;

    private int damageModifier; //This variable is used to determine how much damage to take or power to use.
    
    private float playerHealth;
    public float PlayerHealth {
        get { return playerHealth; }
    }

    private int playerPower;
    public int PlayerPower
    {
        get { return playerPower; }
        set { playerPower = value; }
    }
    bool isRecharging;
    float rechargeTimer;
    float rechargeBufferTimer;

    private int playerScore;
    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }


    private GameObject textObject;
    private GameObject healthTextObject;
    private GameObject powerTextObject;
    private GameObject scoreTextObject;
    

    private float timer;

	// Use this for initialization
	void Start () {
        audioManager = FindObjectOfType<AudioManager>();

        textObject = GameObject.Find("Stats_Text");
        healthTextObject = textObject.transform.Find("Health").gameObject;
        powerTextObject = textObject.transform.Find("Power").gameObject;
        scoreTextObject = GameObject.Find("Desk_Score_Box").transform.Find("Score_Variable_Txt").gameObject;

        playerHealth = 100;
        playerPower = 100;
        playerScore = 0;

        damageModifier = transform.Find("Player_ship_Windows_2").Find("Desk_Obj").Find("Desk_Switch_Top").GetComponent<Desk_Switch_Controller>().ShieldModifier;
        //Debug.Log(transform.Find("Player_ship_Windows_2").Find("Desk_Obj").Find("Desk_Switch_Top").GetComponent<Desk_Switch_Controller>().ShieldModifier);
	}

    // Update is called once per frame
    void FixedUpdate() {
        //statsTest();
        damageModifier = transform.Find("Player_ship_Windows_2").Find("Desk_Obj").Find("Desk_Switch_Top").GetComponent<Desk_Switch_Controller>().ShieldModifier;
        //Debug.Log(transform.Find("Player_ship_Windows_2").Find("Desk_Obj").Find("Desk_Switch_Top").GetComponent<Desk_Switch_Controller>().ShieldModifier);


        healthTextObject.GetComponent<TMPro.TextMeshPro>().SetText("" + playerHealth);
        powerTextObject.GetComponent<TMPro.TextMeshPro>().SetText("" + playerPower);
        scoreTextObject.GetComponent<TMPro.TextMeshPro>().SetText("" + playerScore);

        rechargeBufferTimer += Time.deltaTime;
        PowerRechargeBuffer();

        KillPlayer();
    }

    void StatsTest()
    {
        timer += Time.deltaTime * 5f;
        if (timer >= 1f)
        {
            playerScore++;         
            timer = 0f;
        }
    }
    
	public void PlayerHit(float damage)
    {
        playerHealth -= damage * (4 - damageModifier);
    }

    void PowerRechargeBuffer()
    {
        if (rechargeBufferTimer > 1f)
        {
            RechargePower();
        }
    }

    void RechargePower() 
    {
        rechargeTimer += Time.deltaTime;
        if ((rechargeTimer > 0.01f) && (playerPower < 100))
        {
            playerPower++;
        }
        else if (playerPower >= 100)
        {
            playerPower = 100;
        }
    }
    public void PowerUsed(int power)
    {
        int newPower = playerPower - power;
        playerPower = newPower;
        rechargeBufferTimer = 0f;
    }
    public bool EnoughPower(int power)
    {
        if ((playerPower - power) >= 0)
            return true;

        else    
            return false;
    }

    //If the player dies then the scene is changed and the score is sent to the object with the game over script in the new scene.
    void KillPlayer()
    {
        if (playerHealth <= 0)
        {
            int yourScore = playerScore;
            if (PlayerPrefs.HasKey("yourScore"))
            {
                PlayerPrefs.DeleteKey("yourScore");
            }
            PlayerPrefs.SetInt("yourScore", yourScore);

            LeaderboardShuffle(yourScore, LeaderboardPlacement(yourScore));

            for (int i = 1; PlayerPrefs.HasKey(i + "Scene"); i++)
            {
                Debug.Log(i + "Scene = " + PlayerPrefs.GetInt(i + "Scene"));
            }

            Time.timeScale = 0.0f;

            if (audioManager == null)
            {
                Debug.LogWarning("AudioManager Not found");
            }
            else if (audioManager.IsPlaying("Theme_Intro"))
            {
                audioManager.Stop("Theme_Intro");
            }
            else
            {
                audioManager.Stop("Theme_Loop");
                audioManager.introStarted = false;
            }
            audioManager.Play("Pause_Loop");

            SceneManager.LoadScene("Game_Over_Menu", LoadSceneMode.Single);
            //PlayerPrefs.DeleteAll();

        }
    }

    /*
     * The following function takes in a score and a placement and shuffles the leaderboard to
     * add the new score value at the given placement.
     */
    void LeaderboardShuffle(int score, int placement)
    {
        //int i = placement;
        int iMax = placement;

        //Starting from the the placement, the for loop counts up until no score exists
        for (int i = placement; PlayerPrefs.HasKey(i + "Score"); i++)
        {
            iMax = i; //Set the current i to the max value. Once the top value is reached iMax will hold the last value of i.   
            Debug.Log("iMax placement in shuffle is " + iMax);
            Debug.Log(+i + "Score = " + PlayerPrefs.GetInt(i + "Score"));
        }
        
        //The set the score above iScore to iScore.
        PlayerPrefs.SetInt((iMax + 1) + "Score", PlayerPrefs.GetInt(iMax + "Score"));
 
        //This for loop iterates from the top down to delete the indexScene and replace it with the index-1 Score.
        for (int index = iMax; index > placement; index--)
        {
            PlayerPrefs.DeleteKey(index + "Score");
            PlayerPrefs.SetInt(index + "Score", PlayerPrefs.GetInt((index - 1) + "Score"));
        }
        
        //If the current placement exists then delete it.
        if (PlayerPrefs.HasKey(placement + "Score"))
        {
            PlayerPrefs.DeleteKey(placement + "Score");
        }
        //Set the current placement to the score.
        PlayerPrefs.SetInt(placement + "Score", score);

    }

    /*
     * The following function finds the rank at which a new score should be placed.
     */
    int LeaderboardPlacement(int score)
    {
        //Starting from the top
        //int i = 1;
        int iMax = 1;

        //If the top score exists...
        if (PlayerPrefs.HasKey("1Score"))
        {
            if (score > PlayerPrefs.GetInt("1Score"))
            {
                return 1;
            }
            //This for loop counts up the ranks until the score is no longer smaller than the iScore.
            for (int i = 1; score < PlayerPrefs.GetInt(i + "Score"); i++) 
            {
                //The last iScore index is stored in iMax.
                iMax = i;
                Debug.Log("Current leaderboard placement iMax " + iMax);

            } 
            //The value of iMax is then returned.
             return iMax + 1;
        }
        else {
            //If there is no top score, then the 1Score is returned as the correct placement.
            return 1;
        }
    }
}
