using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitMemberList : MonoBehaviour
{
    public GameObject ChallengeBtn;
    public GameObject SendGiftBtn;
    public GameObject ReceiveGiftBtn;
    public GameObject GainRanking;
    public GameObject StarLevel;
    public GameObject TextGift;
    public GameObject RankObj;

    public TextMeshProUGUI GiftText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI LoginText;
    public TextMeshProUGUI GainText;
    public TextMeshProUGUI RankText;

    public Button BtnPrefab;
    public Image Portrait;

    ListMembers LMembers;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PrefabForChallenge(string login, int level, Sprite img)
    {
        Portrait.sprite = img;
        SendGiftBtn.SetActive(false);
        ReceiveGiftBtn.SetActive(false);
        GainRanking.SetActive(false);
        TextGift.SetActive(false);
        RankObj.SetActive(false);
        BtnPrefab.interactable = false;

        ChallengeBtn.SetActive(true);
        StarLevel.SetActive(true);

        LevelText.text = level.ToString("00");
        LoginText.text = login;
    }

    public void PrefabForSendGift(string login, string text, Sprite img)
    {
        Portrait.sprite = img;
        StarLevel.SetActive(false);
        ReceiveGiftBtn.SetActive(false);
        GainRanking.SetActive(false);
        ChallengeBtn.SetActive(false);
        RankObj.SetActive(false);
        BtnPrefab.interactable = false;

        TextGift.SetActive(true);
        SendGiftBtn.SetActive(true);

        GiftText.text = text;
        LoginText.text = login;
        SendGiftBtn.GetComponentInChildren<Button>().onClick.AddListener(() => ClickBtn());
    }

    public void PrefabForAcceptGift(string login, string text, Sprite img)
    {
        Portrait.sprite = img;
        StarLevel.SetActive(false);
        SendGiftBtn.SetActive(false);
        GainRanking.SetActive(false);
        ChallengeBtn.SetActive(false);
        RankObj.SetActive(false);
        BtnPrefab.interactable = false;

        TextGift.SetActive(true);
        ReceiveGiftBtn.SetActive(true);

        GiftText.text = text;
        LoginText.text = login;
        ReceiveGiftBtn.GetComponentInChildren<Button>().onClick.AddListener(() => ClickBtn());
    }

    public void PrefabForRanking(ListMembers Lm, int id, string login, int level, string gain, int rank, Sprite img)
    {
        LMembers = Lm;
        Portrait.sprite = img;
        SendGiftBtn.SetActive(false);
        ChallengeBtn.SetActive(false);
        TextGift.SetActive(false);
        ReceiveGiftBtn.SetActive(false);

        BtnPrefab.interactable = true;
        RankObj.SetActive(true);
        StarLevel.SetActive(true);
        GainRanking.SetActive(true);

        RankText.text = rank.ToString("00");
        GainText.text = gain;
        LevelText.text = level.ToString("00");
        LoginText.text = login;

        BtnPrefab.onClick.AddListener(() => UI.instance.ShowStatsRank(LMembers, id));
    }


    //After clicked of Prefab in MailBox list
    public void ClickBtn()
    {
        UI.instance.PlayAudioEffects();
        anim.SetBool("click", true);
    }

    public void DeleteFriendsList()
    {
        Destroy(this.gameObject);
    }
}
