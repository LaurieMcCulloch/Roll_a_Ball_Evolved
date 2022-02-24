using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject _mainMenuPanel;

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
        _mainMenuPanel.SetActive(state == GameState.MainMenu);
    }

}
