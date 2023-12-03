using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitCards : MonoBehaviour
{
    public int idCard;
    public int CategoryCard;
    public Button BtnCard;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI StrokeTitle;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Counting;
    public TextMeshProUGUI RequireUnlock;
    public GameObject isLoked;
    public GameObject isPrenium;
    public GameObject TitleStroke;
    public GameObject ObjLevel;
    public GameObject Stroke;
    public GameObject Stats;
    public Image BarLevel;
    public Image ImgPower;
    public Image ImageAccuracy;
    public Image ImgTrajectory;
    public Image ImgObj;
    public Image Card;
    public Sprite[] stats;

    void Start()
    {
        BtnCard.onClick.AddListener(() => CardClicked(idCard, CategoryCard));
    }

    void CardClicked(int id, int cat)
    {
        UI.instance.PlayAudioEffects();
        GenerateObjects.instance.ChooseNewItem(id, cat);
    }
}
