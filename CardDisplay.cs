using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Text NameText;
    public Text StageText;
    public Text EffectText;

    public RawImage HeadShot;
    public GameObject BackgroundImageRed;
    public GameObject BackgroundImageYellow;
    public GameObject BackgroundImageBlue;
    public GameObject BackgroundImageGreen;
    public GameObject BackgroundImagePurple;
    private ImageCartoon imageCartoon;

    public Card card;
    // Start is called before the first frame update
    void Start()
    {
        HideBackground();
        imageCartoon = gameObject.GetComponent<ImageCartoon>();
        imageCartoon.LoadAllImage();
        ShowCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideBackground()
    {
        BackgroundImageRed.SetActive(false);
        BackgroundImageYellow.SetActive(false);
        BackgroundImageBlue.SetActive(false);
        BackgroundImageGreen.SetActive(false);
        BackgroundImagePurple.SetActive(false);
    }
    public void ShowCard()
    {
        NameText.text = card.CardName;
        StageText.text = card.CardStage;
        EffectText.text = card.CardEffect;
        if (card.CardStage == "Attack")
        {
            BackgroundImageRed.SetActive(true);
        }
        else
        if (card.CardStage == "Defense")
        {
            BackgroundImageYellow.SetActive(true);
        }
        else
        if (card.CardStage == "Equip")
        {
            BackgroundImageBlue.SetActive(true);
        }
        else
        if (card.CardStage == "Supply")
        {
            BackgroundImageGreen.SetActive(true);
        }
        else
        {
            BackgroundImagePurple.SetActive(true);
        }
        
        HeadShot.texture = imageCartoon.allTex2d[card.Id];
    }
}