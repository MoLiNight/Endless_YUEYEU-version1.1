using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public bool Operation;
    public int TempOriginHP;
    public int LostHP;
    public int CurrentHP;
    public int CurrentATK;
    public int CurrentDFS;
    public int OriginHarm;
    private int SummonCounter;
    public int Shields;

    public int RepeatCard;
    public int AttackTwice;
    public bool ProtectCard;
    public bool TempSucking;
    public bool SkipEnemyDraw;
    public bool KillPossibility;
    public double OverToHarm;
    public double OverToShields;
    public double BloodLosing;
    public double BloodSucking;
    public double RealityAttack;

    public CardStore cardStore;
    public PlayerData playerData;
    public GameObject cardPrefab;
    public GameObject handArea;
    public GameObject DataManager;
    public List<Card> CardDeck = new List<Card>();

    public Text DeckCounter;
    public Text CurHP;
    public Text MaxHP;
    public Text CurATK;
    public Text CurDFS;
    public Text CurShields;
    // Start is called before the first frame update
    void Start()
    {
        cardStore = DataManager.GetComponent<CardStore>();
        playerData = DataManager.GetComponent<PlayerData>();
        
        FirstDraw();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCardDeck()
    {
        for(int i=0;i<cardStore.CardList.Count;i++)
        {
            if (playerData.PlayerDecks[i] > 0)
            {
                for(int j = 0; j < playerData.PlayerDecks[i];j++)
                {
                    CardDeck.Add(cardStore.CardList[i]);
                }
            }
        }
    }

    public void MessUpCardDeck()
    {
        for(int i=0;i<CardDeck.Count;i++)
        {
            int randomCard = Random.Range(0, CardDeck.Count);
            Card tempCard = CardDeck[i];
            CardDeck[i] = CardDeck[randomCard];
            CardDeck[randomCard] = tempCard;
        }
    }

    public void SummonCard()
    {
        if (SummonCounter >= CardDeck.Count) return;
        GameObject newCard = GameObject.Instantiate(cardPrefab, handArea.transform);
        newCard.GetComponent<CardDisplay>().card = CardDeck[SummonCounter++];
        DeckCounter.text = (CardDeck.Count - SummonCounter).ToString();
    }

    public void TestCardDeck()
    {
        foreach (var card in CardDeck)
        {
            Debug.Log(card.Id + card.CardName);
        }
    }

    public void FirstDraw()
    {
        Operation = false;

        LostHP = 0;
        OriginHarm = 0;
        CurrentHP = playerData.OriginHP;
        CurrentATK = playerData.OriginATK;
        CurrentDFS = playerData.OriginDFS;
        TempOriginHP = playerData.OriginHP;

        Shields = 0;
        SummonCounter = 0;
        RepeatCard = 0;
        AttackTwice = 0;
        ProtectCard = false;
        TempSucking = false;
        SkipEnemyDraw = false;
        KillPossibility = false;
        BloodLosing = 0;
        BloodSucking = 0;
        RealityAttack = 0;

        LoadCardDeck();
        MessUpCardDeck();
        //TestCardDeck();
        SummonCard(); SummonCard(); SummonCard();
        CurHP.text=CurrentHP.ToString();
        CurATK.text=CurrentATK.ToString();
        CurDFS.text=CurrentDFS.ToString();
        MaxHP.text= TempOriginHP.ToString();
        CurShields.text=Shields.ToString();
    }

    public void JudgeAndUseCard(Card card, int Id)
    {
        OriginHarm = 0;
        if(KillPossibility)
        {
            int randomNumber = Random.Range(0, 100);
            if (randomNumber % 5 == 0)
            {
                OriginHarm += CurrentATK * 5;
            }
        }
        for(int i=0;i<=RepeatCard;i++)
        {
            switch (Id)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    if (Id == 1)
                    {
                        AttackTwice = 1;
                    }
                    TempOriginHP = (int)(TempOriginHP * card.Amount_MaxHP);
                    CurrentHP = (int)(CurrentHP * card.Amount_RemainHP);
                    LostHP = (int)(LostHP * card.Amount_LostHP);
                    CurrentATK = (int)(CurrentATK * card.Amount_ATK);
                    CurrentDFS = (int)(CurrentDFS * card.Amount_DFS);
                    break;
                case 4:
                    Shields += (int)(card.Amount_MaxHP * TempOriginHP);
                    CurrentHP = (int)(CurrentHP * card.Amount_RemainHP);
                    break;
                case 5:
                    Shields += (int)(card.Amount_DFS * CurrentDFS);
                    CurrentDFS = 0;
                    break;
                case 6:
                    CurrentATK += (int)(card.Amount_DFS * CurrentDFS);
                    break;
                case 7:
                    CurrentDFS += (int)(card.Amount_ATK * CurrentATK);
                    break;
                case 8:
                    BloodSucking += 0.5f;
                    break;
                case 9:
                    BloodLosing += 0.25f;
                    CurrentATK = (int)(CurrentATK * card.Amount_ATK);
                    break;
                case 10:
                    KillPossibility = true;
                    break;
                case 11:
                    RealityAttack += 10.0f;
                    break;
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                    if (Id == 13)
                    {
                        SkipEnemyDraw = true;
                    }
                    if (Id >= 13 && Id <= 17)
                    {
                        RealityAttack += 1.0f;
                    }
                    OriginHarm += (int)(card.Amount_MaxHP * TempOriginHP + card.Amount_RemainHP * CurrentHP + card.Amount_LostHP * LostHP + card.Amount_ATK * CurrentATK + card.Amount_DFS * CurrentDFS);
                    if (Id == 20)
                    {
                        OriginHarm = (int)(Shields * 1.5f);
                        Shields = 0;
                    }
                    break;
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                    Shields += (int)(card.Amount_MaxHP * TempOriginHP + card.Amount_RemainHP * CurrentHP + card.Amount_LostHP * LostHP + card.Amount_ATK * CurrentATK + card.Amount_DFS * CurrentDFS);
                    break;
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                case 32:
                    CurrentHP += (int)(card.Amount_MaxHP * TempOriginHP + card.Amount_RemainHP * CurrentHP + card.Amount_LostHP * LostHP + card.Amount_ATK * CurrentATK + card.Amount_DFS * CurrentDFS);
                    if (CurrentHP > TempOriginHP)
                    {
                        if (OverToHarm > 0)
                        {
                            OriginHarm += (int)(OverToHarm * (CurrentHP - TempOriginHP));
                            OverToHarm = 0;
                        }
                        if (OverToShields > 0)
                        {
                            Shields += (int)(OverToShields * (CurrentHP - TempOriginHP));
                            OverToShields = 0;
                        }
                        CurrentHP = TempOriginHP;
                    }
                    break;
                case 33:
                    Shields *= 2;
                    break;
                case 34:
                    TempOriginHP = (int)(TempOriginHP * card.Amount_MaxHP);
                    CurrentHP = TempOriginHP;
                    break;
                case 35:
                    BloodSucking += 3.0f;
                    TempSucking = true;
                    break;
                case 36:
                    OverToShields = 1.5f;
                    break;
                case 37:
                    OverToHarm = 1.5f;
                    break;
                case 38:
                    ProtectCard = true;
                    break;
                case 39:
                    RepeatCard = 1;
                    break;
                default:
                    {
                        break;
                    }
            }
        }
        if (RepeatCard == 1 && Id != 39)
        {
            RepeatCard = 0;
        }
        Operation = true;
    }
}
