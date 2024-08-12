using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public TextAsset EnemyDatas;

    public int OriginHP;
    public int OriginATK;
    public int OriginDFS;

    public EnemyStore enemyStore;
    public List<Card> EnemyDesign = new List<Card>();
    // Start is called before the first frame update
    void Start()
    {
        enemyStore.LoadEnemyStore();
        LoadEnemyData();
        //TestLoadEnemyData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadEnemyData()
    {
        string[] dataRow = EnemyDatas.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "OriginHP")
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
            else
            {
                int id = int.Parse(rowArray[1]);
                EnemyDesign.Add(enemyStore.EnemyList[id]);
            }
        }
    }

    public void TestLoadEnemyData()
    {
        Debug.Log(OriginHP);
        Debug.Log(OriginATK);
        Debug.Log(OriginDFS);
        foreach (var card in EnemyDesign)
            Debug.Log(card.Id + card.CardName);
    }
}
