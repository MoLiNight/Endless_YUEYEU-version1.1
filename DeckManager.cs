using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public Transform LibraryPanel;
    public Transform DeckPanel;

    public GameObject LibraryPrefab;
    public GameObject DeckPrefab;

    public GameObject DataManager;

    private PlayerData playerData;
    private CardStore cardStore;

    private Dictionary<int, GameObject> LibraryDic = new Dictionary<int, GameObject>();
    private Dictionary<int, GameObject> DeckDic = new Dictionary<int, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        playerData = DataManager.GetComponent<PlayerData>();
        cardStore = DataManager.GetComponent<CardStore>();

        //cardStore.LoadCardData();
        //playerData.LoadPlayerData();

        UpdateLibrary();
        UpdateDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLibrary()
    {
        for (int i = 0; i < playerData.PlayerCards.Length; i++)
        {
            if (playerData.PlayerCards[i] > 0)
            {
                CreateCard(CardState.Library,i);
            }
        }
    }

    public void UpdateDeck()
    {
        for (int i = 0; i < playerData.PlayerDecks.Length; i++)
        {
            if (playerData.PlayerDecks[i] > 0)
            {
                CreateCard(CardState.Deck, i);
            }
        }
    }

    public void UpdateCard(CardState cardState,int Id)
    {
        if (cardState == CardState.Library)
        {
            playerData.PlayerCards[Id]--;
            playerData.PlayerDecks[Id]++;

            if (!LibraryDic[Id].GetComponent<CardCounter>().SetCounter(-1))
            {
                LibraryDic.Remove(Id);
            }
            if (DeckDic.ContainsKey(Id))
            {
                DeckDic[Id].GetComponent<CardCounter>().SetCounter(1);
            }
            else
            {
                CreateCard(CardState.Deck, Id);
            }
        }
        else if(cardState == CardState.Deck)
        {
            playerData.PlayerCards[Id]++;
            playerData.PlayerDecks[Id]--;

            if (!DeckDic[Id].GetComponent<CardCounter>().SetCounter(-1))
            {
                DeckDic.Remove(Id);
            }
            if (LibraryDic.ContainsKey(Id))
            {
                LibraryDic[Id].GetComponent<CardCounter>().SetCounter(1);
            }
            else
            {
                CreateCard(CardState.Library, Id);
            }
        }
    }

    public void CreateCard(CardState cardState,int Id)
    {
        if(cardState == CardState.Library)
        {
            GameObject newCard = GameObject.Instantiate(LibraryPrefab, LibraryPanel);
            newCard.GetComponent<CardDisplay>().card = cardStore.CardList[Id];
            newCard.GetComponent<CardCounter>().SetCounter(playerData.PlayerCards[Id]);
            LibraryDic.Add(Id, newCard);
        }
        else if (cardState == CardState.Deck)
        {
            GameObject newCard = GameObject.Instantiate(DeckPrefab, DeckPanel);
            newCard.GetComponent<CardDisplay>().card = cardStore.CardList[Id];
            newCard.GetComponent<CardCounter>().SetCounter(playerData.PlayerDecks[Id]);
            DeckDic.Add(Id, newCard);
        }
    }
}
