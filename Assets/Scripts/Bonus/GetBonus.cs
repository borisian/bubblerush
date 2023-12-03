using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleRush
{
    public class GetBonus : MonoBehaviour
    {
        private GameManager gm;
        public GameObject ExploseTheBigBonusObject;
        public GameObject SwapBonusObject;
        public GameObject ThreeRandomBonusObject;


        private void Awake()
        {
           gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void Update()
        {
            
            if (gm.Gold >= 3)
            {
                ExploseTheBigBonusObject.GetComponent<Button>().interactable = true;
            }
            else
            {
                ExploseTheBigBonusObject.GetComponent<Button>().interactable = false;   
            }
            if (gm.Gold >= 5)
            {
                ThreeRandomBonusObject.GetComponent<Button>().interactable = true;
            }
            else
            {
                ThreeRandomBonusObject.GetComponent<Button>().interactable = false;
            }
            if (gm.Gold >= 7)
            {
                SwapBonusObject.GetComponent<Button>().interactable = true;
            }
            else
            {
                SwapBonusObject.GetComponent<Button>().interactable = false;
            }
        }

        public void Confirmation(GameObject btn)
        {
            if (btn.activeInHierarchy)
            {
                btn.SetActive(false);
            }
            else
            {
                btn.SetActive(true);

            }
        }

        public void PurchaseExploseTheBigBonus()
        {
            Debug.Log("Purchase Explose The Big Bonus for 3 golds");
            gm.Purchase(3);
            gm.ExploseTheBigBonus += 1;
            PlayerPrefs.SetInt("ExploseTheBigBonus", gm.ExploseTheBigBonus);
        }

        public void PurchaseThreeRandomBonus()
        {
            Debug.Log("Purchase Three Random Bonus for 5 golds");
            gm.Purchase(5);
            gm.ThreeRandomBonus += 1;
            PlayerPrefs.SetInt("ThreeRandomBonus", gm.ThreeRandomBonus);
        }

        public void PurchaseSwapBonus()
        {
            Debug.Log("Purchase Swag Bonus for 7 golds");
            gm.Purchase(7);
            gm.SwapBonus += 1;
            PlayerPrefs.SetInt("SwapBonus", gm.SwapBonus);
        }

    }
}
