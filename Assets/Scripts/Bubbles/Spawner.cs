using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleRush
{
    public class Spawner : MonoBehaviour
    {
        public GameManager gm;
        public int bubblesCount;
        private int LastBubble = 0;

        private float xMin = -1.5f;
        private float xMax = 1.5f;

        private Touch touch;
        public GameObject actualBubbles;
        public GameObject AncienBubble;
        public GameObject noTouchZone;
        public GameObject Tutorial;
        public int FirstTuto;

        private Vector3 touchPosWorld;

        public bool BonusChangeBubble = false;
        public bool instantiated = false;
        public bool inLaunch = false;

        private bool OnTouchZone;

        private void Awake()
        {
            OnTouchZone = false;
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            FirstTuto = PlayerPrefs.GetInt("FirstTuto", FirstTuto);
            if (FirstTuto == 1)
            {
                Tutorial.SetActive(false);
            }
        }

        public void Update()
        {
            // INSTANTIATE + TRANSFORMATION OF TWO BUBBLES
            if (!instantiated && !inLaunch)
            {
                InstantiateBubble();
            }


            if (instantiated && !inLaunch && gm.gameStarted)
            {
                // No Touch Zone ("Bonus Zone")
                try
                {
                    touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                }
                catch
                {
                    return;
                }

                Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

                //We now raycast with this information. If we have hit something we can process it.
                RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

                if (hitInformation == true && hitInformation.transform.gameObject == noTouchZone)
                {
                    Debug.Log("Raycast hit bonus zone");
                    OnTouchZone = true;
                }
                else
                {
                    OnTouchZone = false;
                }
                // No Touch Zone End

                if (Input.touchCount > 0 && !OnTouchZone)
                {
                    // On r�cup�re les infos du premier doigt pos� sur l'�cran tactile
                    touch = Input.GetTouch(0);
                    // Stop Tuto
                    if (FirstTuto == 0)
                    {
                        Tutorial.SetActive(false);
                        FirstTuto = 1;
                        PlayerPrefs.SetInt("FirstTuto", FirstTuto);
                    }
                    
                    // On teste si le joueur bouge le doigt
                    if (touch.phase == TouchPhase.Moved)
                    {
                        // On bouge le spawner en suivant le mouvement du doigt
                        transform.position = new Vector2(
                            transform.position.x + touch.deltaPosition.x * 0.005f,
                            transform.position.y
                            );
                        actualBubbles.transform.position = new Vector2(
                            transform.position.x, transform.position.y);
                    }

                    // Bloquer le cube entre 2 valeurs sur l'axe X
                    if (transform.position.x < xMin)
                    {
                        transform.position = new Vector2(
                            xMin,
                            transform.position.y
                            );
                    }
                    if (transform.position.x > xMax)
                    {
                        transform.position = new Vector2(
                            xMax,
                            transform.position.y
                            );
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        Debug.Log("touch ended, launching bubbles");
                        actualBubbles.GetComponent<Rigidbody2D>().isKinematic = false;
                        actualBubbles.tag = "Bubbles";
                        inLaunch = true;
                        if (bubblesCount > 1 && AncienBubble)
                        {
                            AncienBubble.GetComponent<Bubbles>().CanCombo = true;
                        }
                        AncienBubble = actualBubbles;
                    }
                }
                // ====== //
            }
        } // Update

        public void InstantiateBubble()
        {
            // BONUS Change Bubble
            // - 6 pour permettre d'instantier que les "premières" bulles.
            int id = Random.Range(0, (gm.Bubbles.Length - 8));
            if (BonusChangeBubble)
            {
                if (bubblesCount > 1)
                {
                    while (id == LastBubble)
                    {
                        id = Random.Range(0, gm.Bubbles.Length);
                    }
                }
            }
            LastBubble = id;
            //
            actualBubbles = Instantiate(gm.Bubbles[id], transform.position, Quaternion.identity);
            actualBubbles.GetComponent<Rigidbody2D>().isKinematic = true;
            actualBubbles.tag = "Nothing";
            bubblesCount += 1;
            Debug.Log("Bubbles Count = " + bubblesCount);
            instantiated = true;
        }

    } // Class
} // Namespace