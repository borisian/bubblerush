using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace BubbleRush
{
    public class GameManager : MonoBehaviour
    {

        public bool gameStarted;
        public bool gameEnded;
        public bool gameInMenu;
        public bool gameInShop;
        public bool BeatScore;

        public int Score;
        public int Gold;
        public int ExploseTheBigBonus;
        public int ThreeRandomBonus;
        public int SwapBonus;
        public int BestScore;

        public TextMeshProUGUI textScore;
        public TextMeshProUGUI bestScore;
        public TextMeshProUGUI textGold;

        public GameObject[] Bubbles;

        #region Begin
        private void Awake()
        {
            Initialization();
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            CheckBestScore();
            // Prevent negative
            if (Gold < 0)
            {
                Gold = 0;
            }
            if (ExploseTheBigBonus < 0)
            {
                ExploseTheBigBonus = 0;
            }
            if (ThreeRandomBonus < 0)
            {
                ThreeRandomBonus = 0;
            }
            if (SwapBonus < 0)
            {
                SwapBonus = 0;
            }
        }


        public void Initialization()
        {
            BestScore = PlayerPrefs.GetInt("BestScore", BestScore);
            SwapBonus = PlayerPrefs.GetInt("SwapBonus", SwapBonus);
            ThreeRandomBonus = PlayerPrefs.GetInt("ThreeRandomBonus", ThreeRandomBonus);
            ExploseTheBigBonus = PlayerPrefs.GetInt("ExploseTheBigBonus", ExploseTheBigBonus);
            Gold = PlayerPrefs.GetInt("Golds", Gold);
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            BeatScore = false;
            gameStarted = false;
            gameEnded = false;
            gameInMenu = true;
            gameInShop = false;
            Debug.Log("Game Start In Menu");
        }
        #endregion

        #region ScoreAndGold
        public void AddScore(int num)
        {
            Score += num;
            textScore.text = Score.ToString();
        } 

        public void CheckBestScore()
        {
            if (Score > BestScore)
            {
                BestScore = Score;
                PlayerPrefs.SetInt("BestScore", BestScore);
                if (!BeatScore)
                {
                    // ...
                    Debug.Log("You beat your score");
                    BeatScore = true;
                }
            }
        }

        public void AddGold(int num)
        {
            Debug.Log("GOLD");
            Gold += num;
            PlayerPrefs.SetInt("Golds", Gold);
            textGold.text = Gold.ToString();
        }
        #endregion

        #region Purchase
        public void Purchase(int numGold)
        {
            Gold -= numGold;
            PlayerPrefs.SetInt("Golds", Gold);
            textGold.text = Gold.ToString();
        }
        #endregion
    }
}
