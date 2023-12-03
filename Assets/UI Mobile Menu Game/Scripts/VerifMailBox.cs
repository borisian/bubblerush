using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifMailBox : MonoBehaviour
{
    public Transform Content;
    public GameObject EmptyGift;
    public GameObject ViewportMailbox;

    void Update()
    {
        int childsCount = Content.childCount;

        if (childsCount == 0)
        {
            if (!EmptyGift.activeSelf)
            {
                EmptyGift.SetActive(true);
                ViewportMailbox.SetActive(false);
            }
        }
        else
        {
            if (!ViewportMailbox.activeSelf)
            {
                ViewportMailbox.SetActive(true);
                EmptyGift.SetActive(false);
            }
        }
    }
}
