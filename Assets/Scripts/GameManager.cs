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
                HandlePlayLevel();
                break;
            case GameState.LevelCompleted:
                HandleLevelCompleted();
                break;            
            case GameState.GameOver:
                HandleGameOver();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleMainMenu()
    {

    }
    private void HandlePlayLevel()
    {

    }
    private void HandleLevelCompleted()
    {

    }
    private void HandleGameOver()
    {

    }

}

public enum GameState
{
    MainMenu,
    PlayLevel,
    LevelCompleted,
    GameOver
}