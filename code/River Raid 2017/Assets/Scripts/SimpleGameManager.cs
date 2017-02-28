using UnityEngine;
using System.Collections;

// Game States
public enum GameState { INTRO, MAIN_MENU, PAUSED, GAME, CREDITS, HELP }

public delegate void OnStateChangeHandler();

public class SimpleGameManager : MonoBehaviour
{
    public static SimpleGameManager instance = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }

    private float playerFuel;

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

        playerFuel = 100f;
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

    public void SetGameState(GameState state)
    {
        gameState = state;
        OnStateChange();
    }

    public void OnApplicationQuit()
    {
        instance = null;
    }


}
