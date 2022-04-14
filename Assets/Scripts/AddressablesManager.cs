using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
public class AddressablesManager : MonoBehaviour
{//TODO clean this and the implementation in the Level Manager up, particularly the task handle in the Completed methtod
    /*
    public static AddressablesManager Instance;

    // Level Loading
    private bool clearPreviousScene = false;
    private SceneInstance previousLoadedScene;

    private void Awake()
    {
        Instance = this;
    }
    public void LoadAddressableLevel(string addressableKey)
    {
        if(clearPreviousScene)
        {
            Addressables.UnloadSceneAsync(previousLoadedScene).Completed += (asyncHandle) =>
            {
                clearPreviousScene = true;
                previousLoadedScene = new SceneInstance();
                Debug.Log($"Unloaded Scene {addressableKey} Successfully");
            };
        }

        Addressables.LoadSceneAsync(addressableKey, LoadSceneMode.Additive).Completed += (asyncHandle) =>
        {
            clearPreviousScene = true;
            previousLoadedScene = asyncHandle.Result;
            Debug.Log($"Loaded Scene {addressableKey} Successfully");

        };
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
