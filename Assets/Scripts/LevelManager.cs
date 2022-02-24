using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] public int CurrentLevel;

    void Awake()
    {
        Instance = this;     
    }

    public void LoadLevel(int level)
    {
        Debug.Log("Loading Level" + level);

        if (1 == 1) // TODO change to level loaded successfully check
        {
            GameManager.Instance.UpdateGameState(GameState.PlayLevel);

        }
    }


}
