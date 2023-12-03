#if GleyIAPiOS || GleyIAPGooglePlay || GleyIAPAmazon || GleyIAPMacOS || GleyIAPWindows
#if USE_PLAYMAKER_SUPPORT

namespace HutongGames.PlayMaker.Actions
{
    [HelpUrl("http://gleygames.com/documentation/Gley-EasyIAP-Documentation.pdf")]
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Get a product price")]
    public class GetStorePrice : FsmStateAction
    {
        [Tooltip("Where to send the event.")]
        public FsmEventTarget eventTarget;

        [Tooltip("Product to get the price for")]
        public ShopProductNames productToCheck;

        [Tooltip("Variable where the product price will be stored")]
        public FsmString price;


        public override void Reset()
        {
            base.Reset();
            eventTarget = FsmEventTarget.Self;
        }

        public override void OnEnter()
        {
            if (IAPManager.Instance.IsInitialized())
            {
                price.Value = IAPManager.Instance.GetLocalizedPriceString(productToCheck);
            }
            else
            {
                price.Value = "-";
            }
            Finish();
        }
    }
}
#endif
#endif