using UnityEngine;

public class TestScript : MonoBehaviour
{
    /// <summary>
    /// Show Rate Game Popup every time this script starts and conditions are met
    /// </summary>
    private void Start()
    {
        RateGame.Instance.ShowRatePopupWithCallback(PopupClosedMethod);
    }

    /// <summary>
    /// Increase custom event by pressing UI Button
    /// </summary>
    public void IncreaseCustomEvents()
    {
        RateGame.Instance.IncreaseCustomEvents();
    }


    /// <summary>
    /// Show Rate Game Popup even if conditions are not met by pressing the UI Button
    /// </summary>
    public void ForceShowPopup()
    {
        RateGame.Instance.ForceShowRatePopupWithCallback(PopupClosedMethod);
    }


    /// <summary>
    /// Triggered when Rate Popup is closed
    /// </summary>
    private void PopupClosedMethod(GleyRateGame.PopupOptions result)
    {
        Debug.Log("Popup Closed-> ButtonPresed: " + result + " -> Resume Game");
    }
}
