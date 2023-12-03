using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleRush
{
    public class Bubbles : MonoBehaviour
    {
        private GameManager gm;

        private GameObject spawner;
        private GameObject nb;

        public bool EndFall = false;
        public bool CanPop;
        public bool CanCombo;

        public void Awake()
        {
            CanCombo = false;
            CanPop = false;
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            spawner = GameObject.Find("Spawner");
        }

        private void CollisionBubbles(Collision2D col, string add, string result)
        {
            // Don't forget : add == Name(Clone)
            if (col.gameObject.name == add && CanPop)
            {
                for (int i = 0; i < gm.Bubbles.Length; i++)
                {
                    if (gm.Bubbles[i].name == result)
                    {
                        Debug.Log("TRANSFORM" + add + " + " + add + " = " + result);
                        nb = gm.Bubbles[i];
                        break;
                    }
                }
                Vector3 pos = gameObject.transform.position;
                // Prevent to instantiate two nb1
                col.gameObject.GetComponent<BubbleRush.Bubbles>().CanPop = false;
                gm.AddScore(2);
                // Destroy this object and the collider for instantiate the new bubble
                Destroy(gameObject);
                Destroy(col.gameObject);
                GameObject nb1 = Instantiate(nb, pos, Quaternion.identity);
                nb1.GetComponent<BubbleRush.Bubbles>().EndFall = true;
                nb1.GetComponent<BubbleRush.Bubbles>().CanCombo = true;
                nb1.GetComponent<BubbleRush.Bubbles>().CanPop = true;
                spawner.GetComponent<Spawner>().bubblesCount -= 1;
                // COMBO
                if (CanCombo && col.gameObject.GetComponent<BubbleRush.Bubbles>().CanCombo)
                {
                    gm.AddGold(1);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Respawn, End Fall etc...
            if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Bubbles")
            {
                if (!EndFall)
                {
                    spawner.GetComponent<BubbleRush.Spawner>().inLaunch = false;
                    spawner.GetComponent<BubbleRush.Spawner>().instantiated = false;
                }
                EndFall = true;
            }

            // POP
            if (EndFall && collision.gameObject.tag == "Bubbles")
            {
                switch (gameObject.name)
                {
                    // Yellow + Yellow = Violet
                    case "Yellow(Clone)":
                        CollisionBubbles(collision, "Yellow(Clone)", "Violet");
                        break;

                    // Violet + Violet = Orange
                    case "Violet(Clone)":
                        CollisionBubbles(collision, "Violet(Clone)", "Orange");
                        break;

                    // Orange + Orange = White
                    case "Orange(Clone)":
                        CollisionBubbles(collision, "Orange(Clone)", "White");
                        break;

                    // White + White = Blue
                    case "White(Clone)":
                        CollisionBubbles(collision, "White(Clone)", "Blue");
                        break;

                    // Blue + Blue = Pink
                    case "Blue(Clone)":
                        CollisionBubbles(collision, "Blue(Clone)", "Pink");
                        break;

                    // Pink + Pink = Red
                    case "Pink(Clone)":
                        CollisionBubbles(collision, "Pink(Clone)", "Red");
                        break;

                    // Red + Red = Green
                    case "Red(Clone)":
                        CollisionBubbles(collision, "Red(Clone)", "Green");
                        break;

                    // Green + Green = Turquoise
                    case "Green(Clone)":
                        CollisionBubbles(collision, "Green(Clone)", "Turquoise");
                        break;

                    // Turquoise + Turquoise = Black
                    case "Turquoise(Clone)":
                        CollisionBubbles(collision, "Turquoise(Clone)", "Black");
                        break;

                    // Black + Black = Multicolor
                    case "Black(Clone)":
                        CollisionBubbles(collision, "Black(Clone)", "Multicolor");
                        break;
                }
            }
        }
    }

}
