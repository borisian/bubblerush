using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI instance;

    public AudioSource Music;
    public AudioSource audioEffects;
    public AudioClip click;

    public ScrollRect scrollviewShop;
    public Transform ContentMailBox;
    public GameObject EmptyGiftMailBox;
    public GameObject ViewportMailbox;
    public GameObject NotifMainMenu;
    public GameObject NotifReceiveGift;
    public TextMeshProUGUI NbrNotifMainMenu;
    public TextMeshProUGUI NbrNotifReceiveGift;

    public GameObject BottomMenu;
    public GameObject WindowStats;

    public GameObject[] bottom_btn;
    public GameObject[] Panels;
    public GameObject[] TabsFriends;
    public GameObject[] PanelsFriends;
    public Color colorDisableTextTabFriends;
    public Button AddGems;
    public Button AddCoins;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //animBottom_Button(2);
        StartCoroutine("SelectButtonStart");
    }

    void Update()
    {
        int childsCount = ContentMailBox.childCount;

        if (childsCount == 0)
        {
            if (!EmptyGiftMailBox.activeSelf)
            {
                EmptyGiftMailBox.SetActive(true);
                ViewportMailbox.SetActive(false);
            }

            if(NotifMainMenu.activeSelf || NotifReceiveGift.activeSelf)
            {
                NotifMainMenu.SetActive(false);
                NotifReceiveGift.SetActive(false);
            }
        }
        else
        {
            if (!ViewportMailbox.activeSelf)
            {
                ViewportMailbox.SetActive(true);
                EmptyGiftMailBox.SetActive(false);
            }

            if (!NotifMainMenu.activeSelf || !NotifReceiveGift.activeSelf)
            {
                NotifMainMenu.SetActive(true);
                NotifReceiveGift.SetActive(true);
            }
        }

        NbrNotifMainMenu.text = childsCount.ToString("0");
        NbrNotifReceiveGift.text = childsCount.ToString("0");
    }

    public void animBottom_Button(int idButton)
    {
        for (int i = 0; i < bottom_btn.Length; i++)
        {
            if (i != idButton)
            {
                bottom_btn[i].GetComponent<Animator>().SetBool("open", false);
                Panels[i].SetActive(false);
            }
            else
            {
                bottom_btn[idButton].GetComponent<Animator>().SetBool("open", true);
                Panels[idButton].SetActive(true);
                if(i == 3)
                {
                    ClickTabsFriends(0);
                }
            }

            bottom_btn[i].GetComponent<Button>().interactable = false;
        }
        PlayAudioEffects();
        StartCoroutine(ActiveInteract(0.2f, idButton));
    }

    IEnumerator ActiveInteract(float time, int idBtn)
    {
        yield return new WaitForSeconds(time);
        for (int i = 0; i < bottom_btn.Length; i++)
        {
            if (i != idBtn)
            {
                bottom_btn[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void ClickTabsFriends(int idtab)
    {
        if(idtab == 0)
        {
            TabsFriends[0].GetComponent<Button>().interactable = false;
            TabsFriends[0].GetComponentInChildren<TextMeshProUGUI>().color = Color.white; 
            TabsFriends[1].GetComponent<Button>().interactable = true;
            TabsFriends[1].GetComponentInChildren<TextMeshProUGUI>().color = colorDisableTextTabFriends;
            TabsFriends[2].GetComponent<Button>().interactable = true;
            TabsFriends[2].GetComponentInChildren<TextMeshProUGUI>().color = colorDisableTextTabFriends;
            PanelsFriends[0].SetActive(true);
            PanelsFriends[1].SetActive(false);
            PanelsFriends[2].SetActive(false);
        }
        else if (idtab == 1)
        {
            TabsFriends[1].GetComponent<Button>().interactable = false;
            TabsFriends[1].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            TabsFriends[0].GetComponent<Button>().interactable = true;
            TabsFriends[0].GetComponentInChildren<TextMeshProUGUI>().color = colorDisableTextTabFriends;
            TabsFriends[2].GetComponent<Button>().interactable = true;
            TabsFriends[2].GetComponentInChildren<TextMeshProUGUI>().color = colorDisableTextTabFriends;
            PanelsFriends[1].SetActive(true);
            PanelsFriends[0].SetActive(false);
            PanelsFriends[2].SetActive(false);
        }
        else if (idtab == 2)
        {
            TabsFriends[2].GetComponent<Button>().interactable = false;
            TabsFriends[2].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            TabsFriends[0].GetComponent<Button>().interactable = true;
            TabsFriends[0].GetComponentInChildren<TextMeshProUGUI>().color = colorDisableTextTabFriends;
            TabsFriends[1].GetComponent<Button>().interactable = true;
            TabsFriends[1].GetComponentInChildren<TextMeshProUGUI>().color = colorDisableTextTabFriends;
            PanelsFriends[2].SetActive(true);
            PanelsFriends[0].SetActive(false);
            PanelsFriends[1].SetActive(false);
        }
        PlayAudioEffects();
    }

    IEnumerator SelectButtonStart()
    {
        yield return new WaitForSeconds(0.1f);
        animBottom_Button(2);
        StopCoroutine("SelectButtonStart");
    }

    public void OpenTabGifts()
    {
        animBottom_Button(3);
        ClickTabsFriends(2);
    }

    public void ShowHideOptionsPanel()
    {
        if (Panels[5].activeSelf)
        {
            Panels[5].SetActive(false);
            Panels[2].SetActive(true);
            BottomMenu.SetActive(true);
            StartCoroutine("SelectButtonStart");
            AddGems.gameObject.SetActive(true);
            AddCoins.gameObject.SetActive(true);
        }
        else
        {
            Panels[5].SetActive(true);
            Panels[2].SetActive(false);
            BottomMenu.SetActive(false);
            AddGems.gameObject.SetActive(false);
            AddCoins.gameObject.SetActive(false);
        }
    }

    public void SelectShopItemMoneyGems()
    {
        for(int i = 0; i < Panels.Length; i++)
        {
            if(i > 0)
            {
                Panels[i].SetActive(false);
            }
        }

        animBottom_Button(0);
        StartCoroutine(ScrollVerticalposition(0.2f));
    }

    public void SelectShopItemMoneyCoins()
    {
        for (int i = 0; i < Panels.Length; i++)
        {
            if (i > 0)
            {
                Panels[i].SetActive(false);
            }
        }

        animBottom_Button(0);
        StartCoroutine(ScrollVerticalposition(0f));
    }

    IEnumerator ScrollVerticalposition(float pos)
    {
        yield return new WaitForSeconds(0.1f);
        scrollviewShop.verticalNormalizedPosition = pos;
        StopCoroutine("ScrollVerticalposition");
    }

    public void ShowStatsRank(ListMembers Lm, int id)
    {
        PlayAudioEffects();
        WindowStats.SetActive(true);
        WindowStats.GetComponent<InitStats>().LoginText.text = Lm.membersList[id].Login;
        WindowStats.GetComponent<InitStats>().LevelText.text = Lm.membersList[id].Level.ToString("00");
        WindowStats.GetComponent<InitStats>().WinsText.text = Lm.membersList[id].totalWins.ToString("00");
        WindowStats.GetComponent<InitStats>().GainText.text = Lm.membersList[id].Gain;
        WindowStats.GetComponent<InitStats>().Avatar.sprite = Lm.membersList[id].avatar;

        AddGems.gameObject.SetActive(false);
        AddCoins.gameObject.SetActive(false);
    }

    public void HideWindowStats()
    {
        PlayAudioEffects();
        if (WindowStats.activeSelf)
        {
            WindowStats.SetActive(false);
        }

        AddGems.gameObject.SetActive(true);
        AddCoins.gameObject.SetActive(true);
    }

    public void PlayAudioEffects()
    {
        if (!audioEffects.isPlaying)
        {
            audioEffects.PlayOneShot(click);
        }
    }
}
