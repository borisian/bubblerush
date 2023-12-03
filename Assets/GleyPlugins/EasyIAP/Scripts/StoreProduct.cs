#if GleyIAPiOS || GleyIAPGooglePlay || GleyIAPAmazon || GleyIAPMacOS || GleyIAPWindows
#define GleyIAPEnabled
#endif

#if GleyIAPEnabled
using UnityEngine.Purchasing;
#endif

using UnityEngine;

public enum ProductType
{
    Consumable = 0,
    NonConsumable = 1,
    Subscription = 2
}

public enum IAPOperationStatus
{
    Success,
    Fail
}

[System.Serializable]
public class StoreProduct
{
    public string productName;
    public ProductType productType;
    public string idGooglePlay;
    public string idAmazon;
    public string idIOS;
    public string idMac;
    public string idWindows;
    public int value;
    public string localizedPriceString = "-";
    public int price;
    public string isoCurrencyCode;
    internal string localizedDescription;
    internal string localizedTitle;
    internal bool active;
    internal SubscriptionInfo subscriptionInfo;


    public StoreProduct(string productName, ProductType productType, int value, string idGooglePlay, string idIOS, string idAmazon, string idMac, string idWindows)
    {
        this.productName = productName;
        this.productType = productType;
        this.value = value;
        this.idGooglePlay = idGooglePlay;
        this.idIOS = idIOS;
        this.idAmazon = idAmazon;
        this.idMac = idMac;
        this.idWindows = idWindows;
    }


    public StoreProduct()
    {
        productName = "";
        idGooglePlay = "";
        idIOS = "";
        idAmazon = "";
        idMac = "";
        idWindows = "";
        productType = ProductType.Consumable;
    }

#if GleyIAPEnabled
    internal UnityEngine.Purchasing.ProductType GetProductType()
    {
        return (UnityEngine.Purchasing.ProductType)(int)productType;
    }
#endif

    internal string GetStoreID()
    {
#if GleyIAPMacOS
        return idMac;
#elif GleyIAPiOS
        return idIOS;
#elif GleyIAPGooglePlay
        return idGooglePlay;
#elif GleyIAPAmazon
        return idAmazon;
#elif GleyIAPWindows
        return idWindows;
#else
        return "";
#endif
    }
}

#if !GleyIAPEnabled
internal class SubscriptionInfo
{
}
#endif