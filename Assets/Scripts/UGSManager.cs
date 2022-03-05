using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Services.Core;
using Unity.Services.Core.Environments;

public class UGSManager : MonoBehaviour
{
    public static UGSManager Instance;
    public static Analytics Analytics;

    internal const string UGS_ENVIRONMENT = "development";

    async void Awake()
    {
        // Create Static Inastance on UGSManager
        Instance = this;
        Analytics = GetComponent<Analytics>();

        // Set UGS Enbironment
        var options = new InitializationOptions();
        options.SetEnvironmentName(UGS_ENVIRONMENT);

        // Initialize UGS
        await UnityServices.InitializeAsync(options);
    }

}
