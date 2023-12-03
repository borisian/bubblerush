using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleRush
{

    public class BonusAction : MonoBehaviour
    {
        public GameObject Spawner;
        private GameObject[] allBubbles;
        private GameManager gm;

        private void Awake()
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        public void ExploseTheBigBubbles()
        {
            Debug.Log("BONUS : Explose the bigger");
            allBubbles = GameObject.FindGameObjectsWithTag("Bubbles");
            GameObject BigBubbles = null;
            float BiggerBubblesSize = -9999f;
            for (int i = 0; i < allBubbles.Length; i++)
            {
                float xScale = allBubbles[i].transform.localScale.x;

                if (xScale > BiggerBubblesSize)
                {
                    BiggerBubblesSize = xScale;
                    BigBubbles = allBubbles[i];
                }
            }
            Spawner.GetComponent<Spawner>().bubblesCount -= 1;
            gm.ExploseTheBigBonus -= 1;
            PlayerPrefs.SetInt("ExploseTheBigBonus", gm.ExploseTheBigBonus);
            Destroy(BigBubbles);
        }

        public void ExploseThreeRandom()
        {
            Debug.Log("BONUS : Explose three random");
            allBubbles = GameObject.FindGameObjectsWithTag("Bubbles");
            if (allBubbles.Length > 2)
            {

                int a;
                int b;
                int c;

                a = Random.Range(0, allBubbles.Length);
                b = Random.Range(0, allBubbles.Length);
                c = Random.Range(0, allBubbles.Length);

                while (a == b || a == c || b == c)
                {
                    a = Random.Range(0, allBubbles.Length);
                    b = Random.Range(0, allBubbles.Length);
                    c = Random.Range(0, allBubbles.Length);
                }
                Spawner.GetComponent<Spawner>().bubblesCount -= 3;
                gm.ThreeRandomBonus -= 1;
                PlayerPrefs.SetInt("ThreeRandomBonus", gm.ThreeRandomBonus);
                Destroy(allBubbles[a]);
                Destroy(allBubbles[b]);
                Destroy(allBubbles[c]);

            }
            else
            {
                Debug.Log("No Bubbles");
            }
        }

        public void ChangeTheBubblesLaunched()
        {
            if (Spawner.GetComponent<BubbleRush.Spawner>().bubblesCount > 1 && !Spawner.GetComponent<BubbleRush.Spawner>().inLaunch)
            {
                Debug.Log("BONUS : Change the bubbles launched");
                Spawner.GetComponent<BubbleRush.Spawner>().BonusChangeBubble = true;
                Destroy(Spawner.GetComponent<BubbleRush.Spawner>().actualBubbles);
                Spawner.GetComponent<BubbleRush.Spawner>().InstantiateBubble();
                Spawner.GetComponent<BubbleRush.Spawner>().BonusChangeBubble = false;
                Spawner.GetComponent<Spawner>().bubblesCount -= 1;
                gm.SwapBonus -= 1;
                PlayerPrefs.SetInt("SwapBonus", gm.SwapBonus);
            }
            else
            {
                Debug.Log("Need more bubbles");
            }
        }
    }
}
