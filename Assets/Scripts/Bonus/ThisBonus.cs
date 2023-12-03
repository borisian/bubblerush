using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BubbleRush
{

    public class ThisBonus : MonoBehaviour
    {
        private GameManager gm;
        private int num;
        private string bonusName;
        public TextMeshProUGUI textNum;
        private GameObject spawner;


        private void Awake()
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            bonusName = gameObject.name;
            spawner = GameObject.Find("Spawner");
        }

        // Update is called once per frame
        void Update()
        {
            if (bonusName == "ExploseTheBigBonus")
            {
                num = gm.ExploseTheBigBonus;
                if (num > 0 && spawner.GetComponent<Spawner>().bubblesCount > 2)
                {
                    gameObject.GetComponent<Button>().interactable = true;
                }
                else
                {
                    gameObject.GetComponent<Button>().interactable = false;
                }
            }
            if (bonusName == "ThreeRandomBonus")
            {
                num = gm.ThreeRandomBonus;
                if (num > 0 && spawner.GetComponent<Spawner>().bubblesCount > 3)
                {
                    gameObject.GetComponent<Button>().interactable = true;
                }
                else
                {
                    gameObject.GetComponent<Button>().interactable = false;
                }
            }
            if (bonusName == "SwapBonus")
            {
                num = gm.SwapBonus;
                if (num > 0 && spawner.GetComponent<Spawner>().bubblesCount > 1)
                {
                    gameObject.GetComponent<Button>().interactable = true;
                }
                else
                {
                    gameObject.GetComponent<Button>().interactable = false;
                }
            }

            textNum.text = num.ToString();
        }
    }
}
