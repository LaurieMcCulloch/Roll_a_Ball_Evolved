using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Services.Core;
using Unity.Services.Core.Environments;
using Unity.Services.Core.Analytics;

using Unity.Services.Analytics;

public class UGSManager : MonoBehaviour
{
    public static UGSManager Instance;
    public static Analytics Analytics;

    async void Awake()
    {
        // Create Static Inastance on UGSManager
        Instance = this;
        Analytics = GetComponent<Analytics>();
       
        // Set UGS Environment
        var options = new InitializationOptions();
        options.SetEnvironmentName(Configuration.UGS_ENVIRONMENT);
        options.SetAnalyticsUserId("Laurie");
        
        // Initialize UGS
        await UnityServices.InitializeAsync(options);        
        
    }
}
