using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum CardState
{
    Library,Deck
}
public class ClickCard : MonoBehaviour,IPointerDownHandler
{
    private DeckManager deckManager;
    private PlayerData playerData;

    public CardState cardState;
    // Start is called before the first frame update
    void Start()
    {
        deckManager = GameObject.Find("DeckManager").GetComponent<DeckManager>();
        playerData = GameObject.Find("DataManager").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        int Id = this.GetComponent<CardDisplay>().card.Id;
        deckManager.UpdateCard(cardState, Id);
    }
}
