using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;


public class Analytics : MonoBehaviour
{

    public void RecordTransactionEvent()
    {
        var productsReceived = new Events.Product()
        {
            items = new List<Events.Item>()
            {
                new Events.Item(){ itemName = "Golden Battle Axe"      , itemType = "Weapon", itemAmount = 1},
                new Events.Item(){ itemName = "Flaming Sword"          , itemType = "Weapon", itemAmount = 1},
                new Events.Item(){ itemName = "Jewel Encrusted Shield" , itemType = "Armour", itemAmount = 1}
            },
            virtualCurrencies = new List<Events.VirtualCurrency>()
            {
                new Events.VirtualCurrency(){ virtualCurrencyName = "Gold", virtualCurrencyType = "PREMIUM", virtualCurrencyAmount = 100}
            }
        };

        var productsSpent = new Events.Product()
        {
            realCurrency = new Events.RealCurrency() { realCurrencyType = "USD", realCurrencyAmount = 499 }
        };

        Events.Transaction(new Events.TransactionParameters()
        {
            productsReceived = productsReceived,
            productsSpent = productsSpent,
            transactionID = "100000576198248",
            transactionName = "IAP - A Large Treasure Chest",
            transactionType = Events.TransactionType.PURCHASE,
            transactionServer = Events.TransactionServer.APPLE,
            transactionReceipt = "ewok9Ja81............991KS=="
        });

        
    }
}
