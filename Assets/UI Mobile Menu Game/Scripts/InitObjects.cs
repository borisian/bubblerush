using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitObjects : MonoBehaviour
{
    public int CatObj;
    public Button BtnCat;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI StrokeTitle;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Counting;
    public GameObject isLoked;
    public GameObject isPrenium;
    public GameObject LokedText;
    public GameObject TitleStroke;
    public GameObject ObjLevel;
    public GameObject Stroke;
    public GameObject ImageObj;
    public Image BarLevel;
    public Image ImgObj;
    public Image Card;

    void Start()
    {
        BtnCat.onClick.AddListener(() => CatClicked(CatObj));
    }

    void CatClicked(int cat)
    {
        UI.instance.PlayAudioEffects();
        GenerateObjects.instance.SortInSelectCat(cat);
    }
}