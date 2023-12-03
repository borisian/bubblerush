using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BubbleRush
{
    public class SceneChanger : MonoBehaviour
    {
        public GameManager gm;
        public Sprite BoutonTriggered;
        public GameObject ButtonStart;

        public void Start()
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            if (gm.gameStarted) // Need to go to ==> MainUI.cs
            {
                gm.textScore = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
                gm.textGold = GameObject.Find("Gold").GetComponent<TextMeshProUGUI>();
                // Show UI
                gm.textGold.text = gm.Gold.ToString();
            }
        }

        public void MenuScene()
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            gm.gameStarted = false;
            gm.gameInMenu = true;
        }

        public void GameScene()
        {
            ButtonStart.GetComponent<Image>().sprite = BoutonTriggered;
            gm.gameInMenu = false;
            gm.gameStarted = true;
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }

        public void ReloadGameScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if (!gm.gameStarted && gm.gameEnded)
            {
                gm.gameEnded = false;
                gm.gameStarted = true;
                gameObject.GetComponent<MainUI>().Panel.SetActive(false);
            }
        }
    }
}
