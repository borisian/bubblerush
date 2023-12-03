using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BubbleRush
{

    public class MainUI : MonoBehaviour
    {
        private GameManager gm;
        public GameObject Shop;
        public GameObject Entry;
        public GameObject Custom;
        public GameObject Panel;
        public TextMeshProUGUI GoldEndPanel;
        public TextMeshProUGUI ScoreEndPanel;

        public void PanelEnd() // used in Limit.cs
        {
            Panel.SetActive(true);
            GoldEndPanel.text = GetComponent<BubbleRush.SceneChanger>().gm.Gold.ToString();
            ScoreEndPanel.text = GetComponent<BubbleRush.SceneChanger>().gm.Score.ToString();
        }

        public void GoShop()
        {
            Entry.SetActive(false);
            Custom.SetActive(false);
            Shop.SetActive(true);
            GetComponent<BubbleRush.SceneChanger>().gm.gameInShop = true;
            GetComponent<BubbleRush.SceneChanger>().gm.gameInMenu = false;
            GetComponent<BubbleRush.SceneChanger>().gm.textGold = GameObject.Find("Gold").GetComponent<TextMeshProUGUI>();
            GetComponent<BubbleRush.SceneChanger>().gm.textGold.text = GetComponent<BubbleRush.SceneChanger>().gm.Gold.ToString();
        }

        public void GoCustom()
        {
            Entry.SetActive(false);
            Shop.SetActive(false);
            Custom.SetActive(true);
            GetComponent<BubbleRush.SceneChanger>().gm.gameInShop = true;
            GetComponent<BubbleRush.SceneChanger>().gm.gameInMenu = false;
            GetComponent<BubbleRush.SceneChanger>().gm.textGold = GameObject.Find("Gold").GetComponent<TextMeshProUGUI>();
            GetComponent<BubbleRush.SceneChanger>().gm.textGold.text = GetComponent<BubbleRush.SceneChanger>().gm.Gold.ToString();
        }

        public void ReturnEntry()
        {
            Entry.SetActive(true);
            Shop.SetActive(false);
            Custom.SetActive(false);
            GetComponent<BubbleRush.SceneChanger>().gm.gameInShop = false;
            GetComponent<BubbleRush.SceneChanger>().gm.gameInMenu = true;
        }
    }
}
