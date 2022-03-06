using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] public int CurrentLevelIndex = 0 ;

    [SerializeField] public List<Level> Levels;
    [SerializeField] public Level CurrentLevel;

    void Awake()
    {
        Instance = this;
        SceneManager.sceneLoaded += OnSceneLoaded;

        Levels = new List<Level>();              
        // TODO Load Levels from Disk or Game Overrides
        Levels.Add(new Level() { ID = "Level_001" });
        Levels.Add(new Level() { ID = "Level_002" });

        
    }
    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadLevel(int level)
    {
        Debug.Log("Loading Level" + level);     

        if (Levels.Count > 0 ) // TODO change to level loaded successfully check
        {
            CurrentLevel = Levels[CurrentLevelIndex];
            string scene = "Scenes/Levels/Stage_001/" + CurrentLevel.ID;
            Debug.Log("Scene : " + scene);
            SceneManager.LoadScene(scene , LoadSceneMode.Additive);
        }
    }

    public void LoadNextLevel()
    {
        LoadLevel(CurrentLevelIndex); 
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        
        // If a Level has just been loaded
        if (CurrentLevel != null && scene.name == CurrentLevel.ID)
        {
            Debug.Log("Current Level: " + CurrentLevel.ID);
            // Move player to start position 
            GameObject player = GameObject.Find("Player Start");            
            PlayerController.Instance.transform.SetPositionAndRotation(player ? player.transform.position : new Vector3(0f, 0.5f, 0f), Quaternion.identity);

            // Populate Pickups List
            CurrentLevel.Pickups = new List<GameObject>(GameObject.FindGameObjectsWithTag("PickUp"));
            CurrentLevel.NumberOfPickupsRemaining = CurrentLevel.Pickups.Count;
            
            // Start Level
            GameManager.Instance.UpdateGameState(GameState.PlayLevel);
        }

    }

    public void OnPickupCollision(GameObject pickUp)
    {
        // Remove pickup and decrement counter
        CurrentLevel.NumberOfPickupsRemaining--;
        CurrentLevel.Pickups.Remove(pickUp);

        // If Pickups all collected
        if (CurrentLevel.NumberOfPickupsRemaining == 0)
        {
            // Next Level
            CurrentLevelIndex++;

            // Reset to beginnning is all levels completed
            if (CurrentLevelIndex >= Levels.Count)
            {
                CurrentLevelIndex = 0;
            }

            GameManager.Instance.UpdateGameState(GameState.LevelCompleted);
        }
    }
}

public class Level
{
    public string ID { get; set; }
    public List<GameObject> Pickups;
    public int NumberOfPickupsRemaining; 
          
}
