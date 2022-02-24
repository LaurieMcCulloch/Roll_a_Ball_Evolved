using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject _mainMenuScreen;
    [SerializeField] private GameObject _gameUIScreen;
    [SerializeField] private GameObject _levelCompleteScreen;
    [SerializeField] private GameObject _gameOverScreen;

    void Awake()
    {
        Instance = this;
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        _mainMenuScreen.SetActive(state == GameState.MainMenu);
        _gameUIScreen.SetActive(state == GameState.PlayLevel);
        _levelCompleteScreen.SetActive(state == GameState.LevelCompleted);
        _gameOverScreen.SetActive(state == GameState.GameOver);
    }

}