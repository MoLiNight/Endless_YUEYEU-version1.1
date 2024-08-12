using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public Text ShowCoins;
    public Text ShowHP;
    public Text ShowATK;
    public Text ShowDFS;

    public int PlayerCoins;
    public int OriginHP;
    public int OriginATK;
    public int OriginDFS;
    public float MusicVolume;

    public int[] PlayerCards;
    public int[] PlayerDecks;
    public CardStore CardStore;
    // Start is called before the first frame update
    void Start()
    {
        CardStore.LoadCardData();
        //CardStore.TestLoad_CardStore();
        LoadPlayerData();
        ShowHP.text = OriginHP.ToString();
        ShowATK.text = OriginATK.ToString();
        ShowDFS.text = OriginDFS.ToString();
        ShowCoins.text = PlayerCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadPlayerData()
    {
        PlayerCards = new int[CardStore.CardList.Count];
        PlayerDecks = new int[CardStore.CardList.Count];
        string PlayerDatas = File.ReadAllText(Application.streamingAssetsPath + "/Datas/PlayerData.txt");
        string[] dataRow = PlayerDatas.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "Rabbit_Head")
            {
                PlayerCoins = int.Parse(rowArray[1]);
            }
            else if (rowArray[0] == "OriginHP")
            {
                OriginHP = int.Parse(rowArray[1]);
            }
            else if (rowArray[0] == "OriginATK")
            {
                OriginATK = int.Parse(rowArray[1]);
            }
            else if (rowArray[0] == "OriginDFS")
            {
                OriginDFS = int.Parse(rowArray[1]);
            }
            else if (rowArray[0] == "MusicVolume") 
            {
                MusicVolume = float.Parse(rowArray[1]);
            }
            else if (rowArray[0] == "Card")
            {
                int id = int.Parse(rowArray[1]);
                int num = int.Parse(rowArray[2]);
                PlayerCards[id] = num;
            }
            else if (rowArray[0] == "Deck")
            {
                int id = int.Parse(rowArray[1]);
                int num = int.Parse(rowArray[2]);
                PlayerDecks[id] = num;
            }
        }

        Debug.Log("Successful Load");

    }

    public void SavePlayerData()
    {
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        string path = Application.streamingAssetsPath + "/Datas/PlayerData.txt";

        List<string> datas = new List<string>();
        datas.Add("Rabbit_Head," + PlayerCoins.ToString());
        datas.Add("OriginHP," + OriginHP.ToString());
        datas.Add("OriginATK," + OriginATK.ToString());
        datas.Add("OriginDFS," + OriginDFS.ToString());
        datas.Add("MusicVolume," + MusicVolume.ToString());

        for (int i = 0; i < PlayerCards.Length; i++)
        {
            if (PlayerCards[i] != 0)
            {
                datas.Add("Card," + i.ToString() + "," + PlayerCards[i].ToString());
            }
        }

        for (int i = 0; i < PlayerDecks.Length; i++)
        {
            if (PlayerDecks[i] != 0)
            {
                datas.Add("Deck," + i.ToString() + "," + PlayerDecks[i].ToString());
            }
        }

        File.WriteAllLines(path, datas);
        #if UNITY_EDITOR
            AssetDatabase.Refresh();
        #endif
        ShowHP.text = OriginHP.ToString();
        ShowATK.text = OriginATK.ToString();
        ShowDFS.text = OriginDFS.ToString();
        ShowCoins.text = PlayerCoins.ToString();

        Debug.Log("Successful Save");
    }

    public void StartNewGame()
    {
        PlayerCoins = 15;
        OriginHP = 100;
        OriginATK = 50;
        OriginDFS = 25;
        MusicVolume = 0.5f;

        for (int i = 0; i < PlayerCards.Length; i++)
        {
            PlayerCards[i] = 0;
        }
        for (int i = 0; i < PlayerDecks.Length; i++)
        {
            PlayerDecks[i] = 0;
        }

        SavePlayerData();
        Debug.Log("StartNewGame");
    }
}
