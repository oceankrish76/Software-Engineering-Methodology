using UnityEngine;
using System.Collections;

// Game States
public enum GameState { INTRO, MAIN_MENU, PAUSED, GAME, CREDITS, HELP, GAME_OVER }



//Event delegates
public delegate void OnStateChanged(GameState state);
public delegate void OnPlayerLivesChanged(int lives);
public delegate void OnScoreChanged(int score);

public class SimpleGameManager : MonoBehaviour
{
    //Events
    public event OnStateChanged OnStateChanged;
    public event OnPlayerLivesChanged OnLivesChanged;
    public event OnScoreChanged OnScoreChanged;

    public static SimpleGameManager instance = null;
    public GameState gameState { get; private set; }

    //Gameplay variables
    private float playerFuel;
    private int playerLives;
    private int playerScore;

    private string playerName;

    private int scoreForNewLife = 500;
    private int scoreSinceLifeGained = 0;

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
        InitializeVariables();
        //Assigning events
        OnStateChanged += new OnStateChanged(HandleStateChanges);
        //ONLY ONE INSTANCE
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
        }
        set
        {
            instance = null;
        }
    }

    void HandleStateChanges(GameState newState)
    {
        switch (newState)
        {
            case GameState.GAME_OVER:
                InitializeVariables();
                break;

            default:
                //do nothing
                break;
        }

    }

    void InitializeVariables()
    {
        playerFuel = 50f;
        playerLives = 3;
        playerScore = 0;
    }

    public string PlayerName
    {
        get
        {
            return playerName;
        }
        set
        {
            playerName = value;
        }
    }

    public float PlayerFuel
    {
        get
        {
            return playerFuel;

        }
        set
        {
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

            if (playerLives > 4)
            {
                playerLives = 4;
            }

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
            OnScoreChanged(playerScore);
            if ((playerScore - scoreSinceLifeGained) > scoreForNewLife)
            {
                scoreSinceLifeGained = playerScore;
                PlayerLives += 1;
            }
        }
    }

    public void SetGameState(GameState state)
    {
        gameState = state;

        if (gameState == GameState.GAME_OVER)
        {
            GameObject.FindWithTag("GameOver").GetComponent<Canvas>().enabled = true;
        }

        OnStateChanged(state);
    }

    public void OnApplicationQuit()
    {
        instance = null;
    }

    public void PlayerDied()
    {
        PlayerLives -= 1;
        if (playerLives >= 0)
        {
            Debug.Log("Trying to respawn");
            playerFuel = 50f;
            GameObject.FindWithTag("Respawn").GetComponent<PlayerRespawn>().respawnPlayer();
        }
        else
        {
            SetGameState(GameState.GAME_OVER);
        }

    }
}
