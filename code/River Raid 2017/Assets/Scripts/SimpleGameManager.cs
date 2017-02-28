using UnityEngine;
using System.Collections;

// Game States
public enum GameState { INTRO, MAIN_MENU, PAUSED, GAME, CREDITS, HELP }


//Event delegates
public delegate void OnStateChangeHandler(GameState state);
public delegate void OnPlayerLivesChanged(int lives);

public class SimpleGameManager : MonoBehaviour
{

    //Event delegates
    public event OnStateChangeHandler OnStateChange;
    public event OnPlayerLivesChanged OnLivesChange;


    public static SimpleGameManager instance = null;
    public GameState gameState { get; private set; }

    //Gameplay variables
    private float playerFuel;
    private int playerLives;

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
        playerFuel = 100f;
        playerLives = 3;
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
            playerLives += value;
            OnLivesChange(playerLives);
        }
    }

    public void SetGameState(GameState state)
    {
        gameState = state;
       // OnStateChange(state);
    }

    public void OnApplicationQuit()
    {
        instance = null;
    }


}
