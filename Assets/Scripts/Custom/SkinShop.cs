using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BubbleRush
{
    public class SkinShop : MonoBehaviour
    {
        public GameManager gm;

        public GameObject DictPurchased;
        public GameObject preview;
        public GameObject previewPosition;
        private GameObject ObjectSelected;

        public string bubblePreviewName;

        public void Start()
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        public void Confirmation(GameObject btn)
        {
            btn.SetActive(true);
        }

        public void CustomBubbleChoice()
        {
            bubblePreviewName = EventSystem.current.currentSelectedGameObject.name;
            for (int i = 0; i < gm.Bubbles.Length; i++)
            {
                if (gm.Bubbles[i].name == bubblePreviewName)
                {
                    Destroy(preview);
                    preview = Instantiate(gm.Bubbles[i]);
                    preview.GetComponent<Rigidbody2D>().isKinematic = true;
                    preview.transform.localScale = new Vector3(0.5f, 0.5f, 1);
                    preview.transform.parent = gameObject.transform;
                    preview.transform.position = previewPosition.transform.position;
                }
            }
        }

        public void BuyHat(Sprite sprite) // Need two parameters (sprite, cost)
        {
            for (int i = 0; i < gm.Bubbles.Length; i++)
            {
                if (gm.Bubbles[i].name == bubblePreviewName)
                {
                    // TEST HERE DEBUG LOG
                    // button
                    ObjectSelected = EventSystem.current.currentSelectedGameObject;
                    // cost
                    int cost = ObjectSelected.transform.parent.GetComponent<IsPurchased>().cost;
                    // dict
                    Dictionary<string, bool> dictPurchased = ObjectSelected.transform.parent.GetComponent<IsPurchased>().customsPurchased;

                    // Check if empty dict
                    if (!dictPurchased.ContainsKey(bubblePreviewName))
                    {
                        dictPurchased.Add(bubblePreviewName, false);
                        ObjectSelected.transform.parent.GetComponent<IsPurchased>().customsPurchased = dictPurchased;
                    }

                    foreach (KeyValuePair<string, bool> custom in dictPurchased)
                    {
                        if (custom.Key == bubblePreviewName && custom.Value == false)
                        {
                            // TEST HERE DEBUG LOG
                            if (gm.Gold > cost)
                            {
                                gm.Purchase(cost);
                                Debug.Log("Buy for " + bubblePreviewName);
                                GameObject h = gm.Bubbles[i].transform.Find("Hat").gameObject;
                                h.GetComponent<SpriteRenderer>().sprite = sprite;
                                preview.transform.Find("Hat").gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
                                Debug.Log("Check BubbleName in IsPurchased.cs :" + ObjectSelected.transform.parent.GetComponent<IsPurchased>());
                                dictPurchased[bubblePreviewName] = true;
                                ObjectSelected.transform.parent.GetComponent<IsPurchased>().customsPurchased = dictPurchased;

                                foreach (KeyValuePair<string, bool> cst in ObjectSelected.transform.parent.GetComponent<IsPurchased>().customsEquipped)
                                {
                                    if (!ObjectSelected.transform.parent.GetComponent<IsPurchased>().customsEquipped.ContainsKey(bubblePreviewName))
                                    {
                                        ObjectSelected.transform.parent.GetComponent<IsPurchased>().customsEquipped.Add(bubblePreviewName, true);
                                    }
                                    else
                                    {
                                        if (cst.Key == bubblePreviewName)
                                        {
                                            {
                                                ObjectSelected.transform.parent.GetComponent<IsPurchased>().customsEquipped[bubblePreviewName] = true;
                                            }
                                        }
                                    }
                                }

                                break;
                            }
                            else
                            {
                                // Return Popup Alert...
                                Debug.Log("Not enough gold");
                                return;
                            }
                        }
                    }
                }
            }
        }

        // always with buttonPurchased of Custom object
        public void Equip(Sprite sprite)
        {
            for (int i = 0; i < gm.Bubbles.Length; i++)
            {
                if (gm.Bubbles[i].name == bubblePreviewName)
                {
                    ObjectSelected = EventSystem.current.currentSelectedGameObject;

                    // Check if empty dict
                    if (!ObjectSelected.transform.parent.GetComponent<IsPurchased>().customsEquipped.ContainsKey(bubblePreviewName))
                    {
                        ObjectSelected.transform.parent.GetComponent<IsPurchased>().customsEquipped.Add(bubblePreviewName, false);
                        return;
                    }

                    foreach (KeyValuePair<string, bool> cst in ObjectSelected.transform.parent.GetComponent<IsPurchased>().customsEquipped)
                    {
                        if (cst.Key == bubblePreviewName)
                        {
                            if (cst.Value)
                            {
                                ObjectSelected.transform.parent.GetComponent<IsPurchased>().customsEquipped[bubblePreviewName] = false;
                                GameObject h = gm.Bubbles[i].transform.Find("Hat").gameObject;
                                h.GetComponent<SpriteRenderer>().sprite = null;
                                preview.transform.Find("Hat").gameObject.GetComponent<SpriteRenderer>().sprite = null;
                            }
                            if (!cst.Value)
                            {
                                ObjectSelected.transform.parent.GetComponent<IsPurchased>().customsEquipped[bubblePreviewName] = true;
                                GameObject h = gm.Bubbles[i].transform.Find("Hat").gameObject;
                                h.GetComponent<SpriteRenderer>().sprite = sprite;
                                preview.transform.Find("Hat").gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
                            }
                        }
                    }
                }
            }
        }
    }
}
