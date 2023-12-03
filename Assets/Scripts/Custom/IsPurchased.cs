using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleRush
{

    public class IsPurchased : MonoBehaviour
    {
        // BOOL WHICH BUBBLES HAVE THIS CUSTOM
        public bool Violet;
        public bool VioletEquip;
        public bool Orange;
        public bool OrangeEquip;
        public bool Yellow;
        public bool YellowEquip;
        //

        public Dictionary<string, bool> customsPurchased = new Dictionary<string, bool>();
        public Dictionary<string, bool> customsEquipped = new Dictionary<string, bool>();

        public GameObject buttonPurchased;
        public GameObject buttonNotPurchased;
        public GameObject skinShop;

        public string bubbleName;
        public int cost;

        public void Update()
        {
            bubbleName = skinShop.GetComponent<SkinShop>().bubblePreviewName;

            switch (bubbleName)
            {
                case "Violet":
                    CheckButtonWithBool(Violet, VioletEquip);
                    break;
                case "Orange":
                    CheckButtonWithBool(Orange, OrangeEquip);
                    break;
                case "Yellow":
                    CheckButtonWithBool(Yellow, YellowEquip);
                    break;
            }
        }

        public void CheckButtonWithBool(bool bl, bool ble)
        {
            if (!bl)
            {
                buttonNotPurchased.SetActive(true);
                buttonPurchased.SetActive(false);
            }
            else
            {
                buttonNotPurchased.SetActive(false);
                buttonPurchased.SetActive(true);
                if (!ble)
                {
                    buttonPurchased.GetComponent<Image>().color = Color.white;
                }
                else
                {
                    buttonPurchased.GetComponent<Image>().color = Color.green;
                }
            }
        }

        public void CheckBoolPurchase(string preview)
        {
            switch (preview)
            {
                case "Violet":
                    Violet = true;
                    break;
                case "Orange":
                    Orange = true;
                    break;
                case "Yellow":
                    Yellow = true;
                    break;
            }
        }

        public void CheckBoolEquip(string preview)
        {
            switch (preview)
            {
                case "Violet":
                    VioletEquip = true;
                    break;
                case "Orange":
                    OrangeEquip = true;
                    break;
                case "Yellow":
                    YellowEquip = true;
                    break;
            }
        }

        public void CheckBoolDesequip(string preview)
        {
            switch (preview)
            {
                case "Violet":
                    VioletEquip = false;
                    break;
                case "Orange":
                    OrangeEquip = false;
                    break;
                case "Yellow":
                    YellowEquip = false;
                    break;
            }
        }

        /*
         * 
         * public void CheckWithDict()
         * {
         *  // Check PURCHASED
            foreach (KeyValuePair<string, bool> custom in customsPurchased)
            {
                if (custom.Key == bubbleName)
                {
                    Debug.Log(custom.Key + custom.Value);
                    if (custom.Value == false)
                    {
                        buttonNotPurchased.SetActive(true);
                        buttonPurchased.SetActive(false);
                    }
                    else
                    {
                        buttonNotPurchased.SetActive(false);
                        buttonPurchased.SetActive(true);
                        // Check EQUIPPED
                        foreach (KeyValuePair<string, bool> cst in customsEquipped)
                        {
                            if (cst.Key == bubbleName)
                            {
                                if (custom.Value == false)
                                {
                                    buttonPurchased.GetComponent<Image>().color = Color.white;
                                }
                                else
                                {
                                    buttonPurchased.GetComponent<Image>().color = Color.green;
                                }
                            }
                        }
                        
                    }
                }
            }
         * }
         * 
         * public void WriteJSONCustom()
        {
            string path = Application.streamingAssetsPath + "/" + "data.json";
            JsonHelper.WriteToJsonFile(path, customsPurchased);
            JsonHelper.WriteToJsonFile(path, customsEquipped);
        }

        public void GetJSONCustom()
        {
            string path = Application.streamingAssetsPath + "/" + "data.json";
            customsEquipped = JsonHelper.ReadFromJsonFile<Dictionary<string, bool>>(path);
        }*/
    }
}
