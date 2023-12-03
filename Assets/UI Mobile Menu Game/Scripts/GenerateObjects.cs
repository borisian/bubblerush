using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateObjects : MonoBehaviour
{
    public static GenerateObjects instance;
    public Transform ContentObj;
    public Transform ContentTopObjCat;
    public Sprite[] ItemRandomImg;

    public List<CategoryObjects> categoryObj = new List<CategoryObjects>();
    public List<Bag> currentBag = new List<Bag>();

    [System.Serializable]
    public class Bag
    {
        public string name;
        public int id;
        public int category;
        public GameObject Prefab;
    }

    [System.Serializable]
    public class CategoryObjects
    {
        public string name;
        public int id;
        public bool isLocked;
        public GameObject Prefab;
        public Color colorCard;
        public TextMeshProUGUI NameCat;
        public Transform ContentCat;
        public List<Objectsist> ObjList = new List<Objectsist>();
    }

    [System.Serializable]
    public class Objectsist
    {
        public string name;
        public int id;
        public GameObject Prefab;
        public GameObject CurrentObj;
        public int power;
        public int accuracy;
        public int trajectory;
        public bool isLocked;
        public bool isEquipped;
        public bool isPrenium;
        public string Required;
        public int level;
        public int Counting;
        public int MaxCounting;
        public Sprite imageObj;
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    //Create all category and all cards from all lists
    void Start()
    {

        //create all category
        for (int i = 0; i < categoryObj.Count; i++)
        {
            GameObject cardObj = Instantiate(categoryObj[i].Prefab, transform.position, Quaternion.identity);
            cardObj.transform.SetParent(ContentObj);
            cardObj.transform.localScale = Vector3.one;

            if (categoryObj[i].isLocked)//if category is locked in the list
            {
                cardObj.GetComponent<InitObjects>().BtnCat.interactable = false;
                cardObj.GetComponent<InitObjects>().Stroke.SetActive(false);
                cardObj.GetComponent<InitObjects>().TitleStroke.SetActive(true);
                cardObj.GetComponent<InitObjects>().Title.gameObject.SetActive(false);
                cardObj.GetComponent<InitObjects>().isLoked.SetActive(true);
                cardObj.GetComponent<InitObjects>().LokedText.SetActive(true);
                cardObj.GetComponent<InitObjects>().ObjLevel.SetActive(false);
                cardObj.GetComponent<InitObjects>().ImageObj.SetActive(false);
            }
            else//so
            {
                if (i == 0)//if category is first
                {
                    cardObj.GetComponent<InitObjects>().Stroke.SetActive(true);
                    cardObj.GetComponent<InitObjects>().BtnCat.interactable = false;
                }
                else//so
                {
                    cardObj.GetComponent<InitObjects>().Stroke.SetActive(false);
                    cardObj.GetComponent<InitObjects>().BtnCat.interactable = true;
                }
                cardObj.GetComponent<InitObjects>().TitleStroke.SetActive(true);
                cardObj.GetComponent<InitObjects>().Title.gameObject.SetActive(true);
                cardObj.GetComponent<InitObjects>().isLoked.SetActive(false);
                cardObj.GetComponent<InitObjects>().LokedText.SetActive(false);
                cardObj.GetComponent<InitObjects>().ObjLevel.SetActive(true);
                cardObj.GetComponent<InitObjects>().ImageObj.SetActive(true);
            }

            cardObj.GetComponent<InitObjects>().StrokeTitle.text = categoryObj[i].name;
            cardObj.GetComponent<InitObjects>().CatObj = i + 1;
            cardObj.GetComponent<InitObjects>().Card.color = categoryObj[i].colorCard;

            categoryObj[i].NameCat.text = categoryObj[i].name+" :";

            Bag addBag = new Bag();
            addBag.name = categoryObj[i].name;
            addBag.category = i + 1;
            addBag.Prefab = cardObj;
            currentBag.Add(addBag);
        }

        //create all category cards
        for (int i = 0; i < categoryObj.Count; i++)
        {
            for (int j = 0; j < categoryObj[i].ObjList.Count; j++)
            {
                GameObject card = Instantiate(categoryObj[i].ObjList[j].Prefab, transform.position, Quaternion.identity);
                card.transform.SetParent(categoryObj[i].ContentCat);
                card.transform.localScale = Vector3.one;

                int RandomImageItem = Random.Range(0, ItemRandomImg.Length);
                categoryObj[i].ObjList[j].imageObj = ItemRandomImg[RandomImageItem];

                if (categoryObj[i].ObjList[j].isLocked)//if card is locked in the list
                {
                    card.GetComponent<InitCards>().ObjLevel.SetActive(false);
                    card.GetComponent<InitCards>().Stroke.SetActive(false);
                    card.GetComponent<InitCards>().TitleStroke.SetActive(false);
                    card.GetComponent<InitCards>().isLoked.SetActive(true);
                    card.GetComponent<InitCards>().Stats.SetActive(false);
                    card.GetComponent<InitCards>().RequireUnlock.text = categoryObj[i].ObjList[j].Required;
                    card.GetComponent<InitCards>().BtnCard.interactable = false;
                }
                else//so
                {
                    if (categoryObj[i].ObjList[j].isEquipped)//if card is equipped in the list
                    {
                        card.GetComponent<InitCards>().Stroke.SetActive(true);
                        card.GetComponent<InitCards>().TitleStroke.SetActive(true);
                        card.GetComponent<InitCards>().StrokeTitle.text = "EQUIPPED";

                        currentBag[i].Prefab.GetComponent<InitObjects>().Title.text = categoryObj[i].ObjList[j].name;
                        currentBag[i].Prefab.GetComponent<InitObjects>().TitleStroke.SetActive(true);
                        currentBag[i].Prefab.GetComponent<InitObjects>().ObjLevel.SetActive(true);
                        currentBag[i].Prefab.GetComponent<InitObjects>().Level.text = categoryObj[i].ObjList[j].level.ToString("0");
                        currentBag[i].Prefab.GetComponent<InitObjects>().BarLevel.fillAmount = ((100f * categoryObj[i].ObjList[j].level) / categoryObj[i].ObjList[j].MaxCounting) / 100f;
                        currentBag[i].Prefab.GetComponent<InitObjects>().Counting.text = categoryObj[i].ObjList[j].level.ToString("0") + "/" + categoryObj[i].ObjList[j].MaxCounting;
                        currentBag[i].Prefab.GetComponent<InitObjects>().ImgObj.sprite = categoryObj[i].ObjList[j].imageObj;
                    }
                    else//so
                    {
                        card.GetComponent<InitCards>().Stroke.SetActive(false);
                        card.GetComponent<InitCards>().TitleStroke.SetActive(false);
                    }

                    card.GetComponent<InitCards>().ObjLevel.SetActive(true);
                    card.GetComponent<InitCards>().Stats.SetActive(true);
                    card.GetComponent<InitCards>().Level.text = categoryObj[i].ObjList[j].level.ToString("0");
                    card.GetComponent<InitCards>().ImgPower.sprite = card.GetComponent<InitCards>().stats[categoryObj[i].ObjList[j].power];
                    card.GetComponent<InitCards>().ImageAccuracy.sprite = card.GetComponent<InitCards>().stats[categoryObj[i].ObjList[j].accuracy];
                    card.GetComponent<InitCards>().ImgTrajectory.sprite = card.GetComponent<InitCards>().stats[categoryObj[i].ObjList[j].trajectory];
                    card.GetComponent<InitCards>().BtnCard.interactable = true;
                }

                if (categoryObj[i].ObjList[j].isPrenium)//if card is prenium in the list
                {
                    card.GetComponent<InitCards>().isPrenium.SetActive(true);
                }
                else//so
                {
                    card.GetComponent<InitCards>().isPrenium.SetActive(false);
                }

                card.GetComponent<InitCards>().idCard = j;
                card.GetComponent<InitCards>().CategoryCard = i+1;
                card.GetComponent<InitCards>().Card.color = categoryObj[i].colorCard;
                card.GetComponent<InitCards>().ImgObj.sprite = categoryObj[i].ObjList[j].imageObj;
                card.GetComponent<InitCards>().Title.text = categoryObj[i].ObjList[j].name;
                card.GetComponent<InitCards>().BarLevel.fillAmount = ((100f * categoryObj[i].ObjList[j].Counting) / categoryObj[i].ObjList[j].MaxCounting) / 100f;
                card.GetComponent<InitCards>().Counting.text = categoryObj[i].ObjList[j].Counting.ToString("0") + "/" + categoryObj[i].ObjList[j].MaxCounting;
                categoryObj[i].ObjList[j].CurrentObj = card;
            }
        }
        SortItemWithEquipped();
    }

    //function is launched after clicked of new card
    public void ChooseNewItem(int idItem, int Category)
    {
        int AjustCat = Category - 1;
        currentBag[AjustCat].Prefab.GetComponent<InitObjects>().Title.text = categoryObj[AjustCat].ObjList[idItem].name;
        currentBag[AjustCat].Prefab.GetComponent<InitObjects>().ObjLevel.SetActive(true);
        currentBag[AjustCat].Prefab.GetComponent<InitObjects>().Level.text = categoryObj[AjustCat].ObjList[idItem].level.ToString("0");
        currentBag[AjustCat].Prefab.GetComponent<InitObjects>().BarLevel.fillAmount = ((100f * categoryObj[AjustCat].ObjList[idItem].Counting) / categoryObj[AjustCat].ObjList[idItem].MaxCounting) / 100f;
        currentBag[AjustCat].Prefab.GetComponent<InitObjects>().Counting.text = categoryObj[AjustCat].ObjList[idItem].Counting.ToString("0") + "/" + categoryObj[AjustCat].ObjList[idItem].MaxCounting;
        currentBag[AjustCat].Prefab.GetComponent<InitObjects>().ImgObj.sprite = categoryObj[AjustCat].ObjList[idItem].imageObj;
        currentBag[AjustCat].Prefab.GetComponent<InitObjects>().isPrenium.SetActive(categoryObj[AjustCat].ObjList[idItem].isPrenium);

        for (int i = 0; i < categoryObj[AjustCat].ObjList.Count; i++)
        {
            if (categoryObj[AjustCat].ObjList[i].isEquipped)
            {
                categoryObj[AjustCat].ObjList[i].isEquipped = false;
                categoryObj[AjustCat].ObjList[i].CurrentObj.GetComponent<InitCards>().Stroke.SetActive(false);
                categoryObj[AjustCat].ObjList[i].CurrentObj.GetComponent<InitCards>().TitleStroke.SetActive(false);
            }

            if(i == idItem)
            {
                categoryObj[AjustCat].ObjList[i].isEquipped = true;
                categoryObj[AjustCat].ObjList[i].CurrentObj.GetComponent<InitCards>().Stroke.SetActive(true);
                categoryObj[AjustCat].ObjList[i].CurrentObj.GetComponent<InitCards>().TitleStroke.SetActive(true);
                categoryObj[AjustCat].ObjList[i].CurrentObj.GetComponent<InitCards>().StrokeTitle.text = "EQUIPPED";
            }
        }
    }

    //sort all cards in function of category selected
    public void SortInSelectCat(int Cat)
    {
        ContentTopObjCat.SetSiblingIndex(0);

        for (int i = 1; i < currentBag.Count+1; i++)
        {
            if (i == Cat)
            {
                categoryObj[i-1].ContentCat.SetSiblingIndex(1);
            }
            else
            {
                categoryObj[i-1].ContentCat.SetSiblingIndex(i);
            }
        }

        for (int i = 0; i < currentBag.Count; i++)
        {
            if (i == Cat-1)
            {
                currentBag[i].Prefab.GetComponent<InitObjects>().Stroke.SetActive(true);
                currentBag[i].Prefab.GetComponent<InitObjects>().BtnCat.interactable = false;
            }
            else
            {
                if (categoryObj[i].isLocked)
                {
                    currentBag[i].Prefab.GetComponent<InitObjects>().Stroke.SetActive(false);
                    currentBag[i].Prefab.GetComponent<InitObjects>().BtnCat.interactable = false;
                }
                else
                {
                    currentBag[i].Prefab.GetComponent<InitObjects>().Stroke.SetActive(false);
                    currentBag[i].Prefab.GetComponent<InitObjects>().BtnCat.interactable = true;
                }
            }
        }
        SortItemWithEquipped();
    }

    //sort all the cards by placing the "equipped" card first
    public void SortItemWithEquipped()
    {
        for(int i = 0; i < categoryObj.Count; i++)
        {
            for (int j = 0; j < categoryObj[i].ObjList.Count; j++)
            {
                if (categoryObj[i].ObjList[j].isEquipped)
                {
                    categoryObj[i].ObjList[j].CurrentObj.transform.SetSiblingIndex(0);
                }
                else
                {
                    if (!categoryObj[i].ObjList[j].isLocked)
                    {
                        categoryObj[i].ObjList[j].CurrentObj.transform.SetSiblingIndex(j);
                    }
                }
            }
        }
    }
}
