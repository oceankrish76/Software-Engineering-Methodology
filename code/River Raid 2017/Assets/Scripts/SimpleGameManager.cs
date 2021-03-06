﻿using UnityEngine;
using System.Collections;

// Game States
public enum GameState { INTRO, MENU, PAUSED, GAME, CREDITS, HELP, GAME_OVER }



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
    public bool playerIsAlive { get; private set; }

    private string playerName;

    private int scoreForNewLife = 7000;
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
                GameObject.FindWithTag("GameOver").GetComponent<Canvas>().enabled = true;
                break;
            case GameState.GAME:
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
        playerIsAlive = false;
        //Spawning the player
        if(gameState == GameState.GAME)
        {
            GameObject.FindWithTag("Respawn").GetComponent<PlayerRespawn>().respawnPlayer();
            playerIsAlive = true;
        }

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

        Debug.Log("GameState changed to: " + gameState);

        OnStateChanged(state);
    }

    public void OnApplicationQuit()
    {
        instance = null;
    }

    public void PlayerDied()
    {
        PlayerLives -= 1;
        playerIsAlive = false;
        if (playerLives >= 0)
        {
            Debug.Log("Trying to respawn");
            playerFuel = 50f;
            GameObject.FindWithTag("Respawn").GetComponent<PlayerRespawn>().respawnPlayer();
            playerIsAlive = true;
        }
        else
        {
            SetGameState(GameState.GAME_OVER);
        }

    }
}
