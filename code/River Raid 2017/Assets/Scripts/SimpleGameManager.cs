using UnityEngine;
using System.Collections;

// Game States
public enum GameState { INTRO, MAIN_MENU, PAUSED, GAME, CREDITS, HELP, GAME_OVER }



//Event delegates
public delegate void OnStateChangeHandler(GameState state);
public delegate void OnPlayerLivesChanged(int lives);
public delegate void OnScoreChanged(int score);

public class SimpleGameManager : MonoBehaviour
{
    //Events
    public event OnStateChangeHandler OnStateChanged;
    public event OnPlayerLivesChanged OnLivesChanged;
    public event OnScoreChanged OnScoreChanged;


    public static SimpleGameManager instance = null;
    public GameState gameState { get; private set; }

    //Gameplay variables
    private float playerFuel;
    private int playerLives;
    private int playerScore;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }


        //Initializing private variables
        gameState = GameState.INTRO;
        playerFuel = 50f;
        playerLives = 3;
        playerScore = 0;
        DontDestroyOnLoad(gameObject);

    }

    public static SimpleGameManager Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }

            return null;
        } set
        {
            instance = null;
        }
    }


    public float PlayerFuel
    {
        get {
            return playerFuel;

        } set {
            playerFuel = value;
        }

    }

    public int PlayerLives
    {
        get
        {
            return playerLives;
        }
        set
        {
            playerLives = value;
            OnLivesChanged(playerLives);
        }
    }

    public int PlayerScore
    {
        get
        {
            return playerScore;
        }
        set
        {
            playerScore = value;
            Debug.Log(playerScore);
            OnScoreChanged(playerScore);
        }
    }

    public void SetGameState(GameState state)
    {
        gameState = state;

        if(gameState == GameState.GAME_OVER)
        {
            GameObject.FindWithTag("GameOver").GetComponent<Canvas>().enabled = true;
        }

       // OnStateChange(state);
    }

    public void OnApplicationQuit()
    {
        instance = null;
    }

    public void PlayerDied()
    {
        PlayerLives -= 1;
        if(playerLives >= 0)
        {
            Debug.Log("Trying to respawn");
            playerFuel = 50f;
            GameObject.FindWithTag("Respawn").GetComponent<PlayerRespawn>().respawnPlayer();
        } else
        {
            SetGameState(GameState.GAME_OVER);
        }
   
    }
}
