using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] public int CurrentLevelIndex = 0 ;

    public List<Level> Levels;
    public Level CurrentLevel;

    void Awake()
    {
        Instance = this;

        Levels = new List<Level>();              
        // TODO Load Levels from Disk or Game Overrides
        Levels.Add(new Level() { ID = "Level_001" });
        Levels.Add(new Level() { ID = "Level_002" });

        
    }

    public void LoadLevel(int level)
    {
        Debug.Log("Loading Level" + level);
        

        if (Levels.Count > 0 ) // TODO change to level loaded successfully check
        {
            CurrentLevel = Levels[CurrentLevelIndex];
            SceneManager.LoadScene(CurrentLevel.ID, LoadSceneMode.Additive);
            GameObject player = GameObject.Find("Player Start");

            // TODO fix this hack, wait for scene to load then try and get start position
            PlayerController.Instance.transform.SetPositionAndRotation(player ? player.transform.position:new Vector3(0f,0.5f,0f), Quaternion.identity);
            GameManager.Instance.UpdateGameState(GameState.PlayLevel);

        }
    }
}
public class Level
{
    public string ID { get; set; }
    
    
}
