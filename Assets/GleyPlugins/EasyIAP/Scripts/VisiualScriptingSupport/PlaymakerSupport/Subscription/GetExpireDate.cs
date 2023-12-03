#if GleyIAPiOS || GleyIAPGooglePlay || GleyIAPAmazon || GleyIAPMacOS || GleyIAPWindows
#if USE_PLAYMAKER_SUPPORT

using UnityEngine.Purchasing;

namespace HutongGames.PlayMaker.Actions
{
    [HelpUrl("http://gleygames.com/documentation/Gley-EasyIAP-Documentation.pdf")]
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Get Subscription Expire Date")]
    public class GetExpireDate : FsmStateAction
    {
        [Tooltip("Where to send the event.")]
        public FsmEventTarget eventTarget;

        [Tooltip("Subscription product")]
        public ShopProductNames subscriptionProductToCheck;

        [Tooltip("Variable where the Expire Date will be stored")]
        public FsmString result;


        public override void Reset()
        {
            base.Reset();
            eventTarget = FsmEventTarget.Self;
        }

        public override void OnEnter()
        {
            if (IAPManager.Instance.IsInitialized())
            {
                SubscriptionInfo info = IAPManager.Instance.GetSubscriptionInfo(subscriptionProductToCheck);
                if (info != null)
                {
                    result.Value= info.getExpireDate().ToShortDateString();
                }
                else
                {
                    result.Value = "-";
                }

            }
            else
            {
                result.Value = "-";
            }
            Finish();
        }
    }
}
#endif
#endif