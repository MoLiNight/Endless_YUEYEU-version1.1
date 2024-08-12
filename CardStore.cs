using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStore : MonoBehaviour
{
    public TextAsset CardData;
    public List<Card> CardList=new List<Card> ();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCardData()
    {
        string[] DataRow = CardData.text.Split('\n');
        foreach (var Row in DataRow)
        {
            string[] RowArray = Row.Split(',');
            if (RowArray[0] == "#")
            {
                continue;
            }
            else
            {
                int Id = int.Parse(RowArray[1]);
                double Amount_MaxHP = double.Parse(RowArray[4]);
                double Amount_RemainHP= double.Parse(RowArray[5]);
                double Amount_LostHP= double.Parse(RowArray[6]);
                double Amount_ATK = double.Parse(RowArray[7]);
                double Amount_DFS = double.Parse(RowArray[8]);
                
                Card NewCard = new Card(Id, RowArray[2], RowArray[0], RowArray[3], Amount_MaxHP, Amount_RemainHP, Amount_LostHP, Amount_ATK, Amount_DFS);
                CardList.Add(NewCard);
            }
        }
    }

    public Card RandomCard()
    {
        Card card = CardList[Random.Range(0,CardList.Count)];
        return card;
    }

    public void TestLoad_CardStore()
    {
        foreach (var card in CardList)
        {
            Debug.Log(card.Id + card.CardName);
        }
    }
}