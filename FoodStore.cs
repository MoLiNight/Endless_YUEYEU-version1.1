using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStore : MonoBehaviour
{
    public TextAsset KitchenData;
    public List<Food> FoodList = new List<Food>();
    // Start is called before the first frame update
    void Start()
    {
        LoadFoodStore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFoodStore()
    {
        string[] dataRow = KitchenData.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(';');
            int id = int.Parse(rowArray[0]);
            int AddHP = int.Parse(rowArray[2]);
            int AddATK = int.Parse(rowArray[3]);
            int AddDFS = int.Parse(rowArray[4]);

            Food NewFood = new Food(id, rowArray[1], AddHP, AddATK, AddDFS);
            FoodList.Add(NewFood);
        }
    }
}
