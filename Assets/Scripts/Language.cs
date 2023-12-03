using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Language : MonoBehaviour
{
    public Text language;
    public TextMeshProUGUI shop;
    public TextMeshProUGUI start;
    // Start is called before the first frame update
    void Start()
    {
        RefreshTexts();
    }

    private void RefreshTexts()
    {
        // Get current language
        language.text = GleyLocalization.Manager.GetCurrentLanguage().ToString();
        // Set button texts
        shop.GetComponent<TextMeshProUGUI>().text = GleyLocalization.Manager.GetText(WordIDs.ShopID);
    }

    // Button for change language
    public void NextLanguage()
    {
        GleyLocalization.Manager.NextLanguage();
        RefreshTexts();
        SaveLanguage();
    }

    public void PrevLanguage()
    {
        GleyLocalization.Manager.PreviousLanguage();
        RefreshTexts();
        SaveLanguage();
    }

    // Save
    public void SaveLanguage()
    {
        GleyLocalization.Manager.SetCurrentLanguage(GleyLocalization.Manager.GetCurrentLanguage());
    }
}
