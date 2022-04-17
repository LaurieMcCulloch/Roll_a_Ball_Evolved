using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;


public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    //private SceneInstance LoadedScene;  // Reference to loaded scene used for unloading
    private Scene LoadedScene;

    [SerializeField] public int CurrentLevelIndex = 0 ;
    [SerializeField] public List<Level> Levels;
    [SerializeField] public Level CurrentLevel;
    

    void Awake()
    {

        if (SceneManager.GetActiveScene().name != "MiniGame")
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadSceneAsync("MiniGame");
        }

        Instance = this;
        SceneManager.sceneLoaded += OnSceneLoaded;        

        Levels = new List<Level>();
        // TODO Load Levels from Disk or Game Overrides
        Levels.Add(new Level() { ID = "Level_001" });
        Levels.Add(new Level() { ID = "Level_002" });
        Levels.Add(new Level() { ID = "Level_003" });
        Levels.Add(new Level() { ID = "Level_004" });

    }
    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;        
    }


    public void LoadLevel()
    {
        LoadLevel(CurrentLevelIndex);
    }


    public void LoadLevel(int level)
    {
        if (Levels.Count == 0)
        {
            Debug.Log("Unable to load level, Levels data is empty!");
            return;
        }

        // Unload the previous level
        if (CurrentLevel != null )
        {
            //Addressables.UnloadSceneAsync(LoadedScene, true).Completed += OnSceneUnloaded;
            SceneManager.UnloadSceneAsync(LoadedScene);
            LoadedScene = new Scene(); // new SceneInstance();
        }
           
        // Load new level
        CurrentLevel = Levels[level];
        //Addressables.LoadSceneAsync(CurrentLevel.ID, LoadSceneMode.Additive, true).Completed += OnSceneLoaded ;
        SceneManager.LoadScene(CurrentLevel.ID, LoadSceneMode.Additive);
        //LoadedScene = SceneManager.GetActiveScene();
    }

    /*
    void OnSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            LoadedScene = obj.Result;
        }
        else
        {
            Debug.LogError("Failed to load scene ");
        }

    }
    */
    /*
   void OnSceneUnloaded(AsyncOperationHandle<SceneInstance> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            LoadedScene = new SceneInstance();
        }
        else
        {
            Debug.LogError("Failed to unload scene ");
        }
    }
    */

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        LoadedScene = scene;
        // If a Level has just been loaded
        if (CurrentLevel != null && scene.name == CurrentLevel.ID)
        {
            // Move player to start position 
            GameObject player = GameObject.Find("Player Start");
            PlayerController.Instance.transform.SetPositionAndRotation(player ? player.transform.position : new Vector3(0f, 0.5f, 0f), Quaternion.identity);

            // Populate Pickups List
            CurrentLevel.Pickups = new List<GameObject>(GameObject.FindGameObjectsWithTag("PickUp"));
            CurrentLevel.PickupsAtStart = CurrentLevel.Pickups.Count;
            CurrentLevel.PickupsRemaining = CurrentLevel.Pickups.Count;

            // Start Level
            GameManager.Instance.UpdateGameState(GameState.PlayLevel);
        }

    }


    public void OnPickupCollision(GameObject pickUp)
    {
        // Remove pickup and decrement counter
        CurrentLevel.PickupsRemaining--;
        CurrentLevel.Pickups.Remove(pickUp);

        // If Pickups all collected
        if (CurrentLevel.PickupsRemaining == 0)
        {
            GameManager.Instance.UpdateGameState(GameState.LevelCompleted);
        }
    }
}

public class Level
{
    public string ID { get; set; }
    public List<GameObject> Pickups;
    public int PickupsAtStart;
    public int PickupsRemaining;         
}
