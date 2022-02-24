using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        Instance = this;    
    }

    void Start()
    {
        UpdateGameState(GameState.MainMenu);    
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;
        Debug.Log("State Changed : " + newState);

        switch (newState)
        {
            case GameState.MainMenu:
                HandleMainMenu();
                break;
            case GameState.PlayLevel:                
                break;
            case GameState.CompleteLevel:
                break;
            case GameState.FailLevel:
                break;
            case GameState.GameOver:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleMainMenu()
    {

    }

}

public enum GameState
{
    MainMenu,
    PlayLevel,
    CompleteLevel,
    FailLevel,
    GameOver
}