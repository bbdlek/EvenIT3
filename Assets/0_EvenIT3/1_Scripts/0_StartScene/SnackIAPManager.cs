using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;
using UnityEngine.Purchasing;

public class SnackIAPManager : MonoBehaviour, IStoreListener
{
    IStoreController m_StoreController; // The Unity Purchasing system.

    public string environment = "production";
    
    //Your products IDs. They should match the ids of your products in your store.
    public string gold2ProductId = "com.Snacks.SnackCatcher.gold_2";
    public string gold10ProductId = "com.Snacks.SnackCatcher.gold_10";
    public string gold20ProductId = "com.Snacks.SnackCatcher.gold_20";

    async void Start()
    {
        try
        {
            var options = new InitializationOptions()
                .SetEnvironmentName(environment);

            await UnityServices.InitializeAsync(options);
        }
        catch (Exception exception)
        {
            // An error occurred during services initialization.
        }
        InitializePurchasing();
    }

    void InitializePurchasing()
    {
        Debug.Log("Hello");
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Add products that will be purchasable and indicate its type.
        builder.AddProduct(gold2ProductId, ProductType.Consumable);
        builder.AddProduct(gold10ProductId, ProductType.Consumable);
        builder.AddProduct(gold20ProductId, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyGold2()
    {
        m_StoreController.InitiatePurchase(gold2ProductId);
    }
    
    public void BuyGold10()
    {
        m_StoreController.InitiatePurchase(gold2ProductId);
    }
    
    public void BuyGold20()
    {
        m_StoreController.InitiatePurchase(gold2ProductId);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("In-App Purchasing successfully initialized");
        m_StoreController = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log($"In-App Purchasing initialize failed: {error}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        //Retrieve the purchased product
        var product = args.purchasedProduct;

        //Add the purchased product to the players inventory
        if (product.definition.id == gold2ProductId)
        {
            AddGold2();
        }
        else if (product.definition.id == gold10ProductId)
        {
            AddGold10();
        }
        else if (product.definition.id == gold20ProductId)
        {
            AddGold20();
        }

        Debug.Log($"Purchase Complete - Product: {product.definition.id}");

        //We return Complete, informing IAP that the processing on our side is done and the transaction can be closed.
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"Purchase failed - Product: '{product.definition.id}', PurchaseFailureReason: {failureReason}");
    }

    void AddGold2()
    {
        UserManager.Instance.userData.Commodities.Gold += 2;
        FBManagerScript.Instance.UpdateCurrentUser();
    }
    
    void AddGold10()
    {
        UserManager.Instance.userData.Commodities.Gold += 10;
        FBManagerScript.Instance.UpdateCurrentUser();
    }
    
    void AddGold20()
    {
        UserManager.Instance.userData.Commodities.Gold += 20;
        FBManagerScript.Instance.UpdateCurrentUser();
    }

    

}
