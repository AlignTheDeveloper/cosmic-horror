using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour

public static gameManager instance;
public GameState state;
//public static event Action
{
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                // Handle main menu state
                HandleMainMenuState();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    // Handle main menu state
    HandleMainMenuState()
    {
        
    }

    public enum GameState
    {
        MainMenu,
        InGame,
        Paused,
        GameOver
    }
}
