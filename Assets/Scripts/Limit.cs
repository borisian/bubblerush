using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleRush
{
    public class Limit : MonoBehaviour
    {
        private float timeLimit = 3.5f;
        [SerializeField]
        private float time;
        private GameManager gm;
        public GameObject MainUILosePanel;

        private void Awake()
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Bubbles")
            {
                time = 0;
                collision.gameObject.GetComponent<BubbleRush.Bubbles>().CanPop = true;
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Bubbles")
            {
                time += Time.deltaTime;
                if (time >= timeLimit)
                {
                    Debug.Log("LOSE");
                    gm.gameEnded = true;
                    gm.gameStarted = false;
                    MainUILosePanel.GetComponent<MainUI>().PanelEnd();
                }
            }
        }
    }
}
