using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPackage : MonoBehaviour
{
    public GameObject CardPrefabs;
    public GameObject CardPool;
    public GameObject MoneyLessTips;

    CardStore cardStore;
    List<GameObject> Cards=new List<GameObject> ();
    
    public PlayerData PlayerDatas;
    // Start is called before the first frame update
    void Start()
    {
        cardStore = GetComponent<CardStore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickOpen()
    {
        if (PlayerDatas.PlayerCoins >= 3)
        {
            ClearPool();
            PlayerDatas.PlayerCoins -= 3;
            for (int i = 0; i < 5; i++)
            {
                GameObject NewCard = GameObject.Instantiate(CardPrefabs, CardPool.transform);

                NewCard.GetComponent<CardDisplay>().card = cardStore.RandomCard();

                while (true)
                {
                    int flag = 0;
                    foreach (var Card in Cards)
                    {
                        if (Card == NewCard)
                        {
                            flag = 1;
                            NewCard.GetComponent<CardDisplay>().card = cardStore.RandomCard();
                            break;
                        }
                    }
                    if (flag == 0) break;
                }

                Cards.Add(NewCard);
            }

            SaveCardData();
            PlayerDatas.SavePlayerData();
        }
        else
        {
            MoneyLessTips.SetActive(true);
        }
        
    }

    public void ClearPool()
    {
        foreach(var Card in Cards)
        {
            Destroy(Card);
        }
        Cards.Clear();
    }

    public void SaveCardData()
    {
        foreach (var Card in Cards)
        {
            int Id = Card.GetComponent<CardDisplay>().card.Id;
            PlayerDatas.PlayerCards[Id]++;
        }
    }
}
