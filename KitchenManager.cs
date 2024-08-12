using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenManager : MonoBehaviour
{    
    public Text HPText;
    public Text ATKText;
    public Text DFSText;
    public Text EffectText;
    public RawImage rawImage;
    public GameObject MoneylessTip;

    private FoodStore foodStore;
    private PlayerData playerData;
    private ImageCartoon imageCartoon;

    // Start is called before the first frame update
    void Start()
    {
        MoneylessTip.SetActive(false);
        imageCartoon = gameObject.GetComponent<ImageCartoon>();
        playerData = gameObject.GetComponent<PlayerData>();
        foodStore = gameObject.GetComponent<FoodStore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomFoodMake()
    {
        if (playerData.PlayerCoins > 0)
        {
            playerData.PlayerCoins--;
            int Id = Random.Range(0, 20);
            playerData.OriginHP += foodStore.FoodList[Id].AddHP;
            playerData.OriginATK += foodStore.FoodList[Id].AddATK;
            playerData.OriginDFS += foodStore.FoodList[Id].AddDFS;
            playerData.SavePlayerData();
            if (foodStore.FoodList[Id].AddHP >= 0)
            {
                HPText.text = "+" + foodStore.FoodList[Id].AddHP.ToString();
            }
            else 
                HPText.text = foodStore.FoodList[Id].AddHP.ToString();
            if (foodStore.FoodList[Id].AddATK >= 0)
            {
                ATKText.text = "+" + foodStore.FoodList[Id].AddATK.ToString();
            }
            else 
                ATKText.text = foodStore.FoodList[Id].AddATK.ToString();
            if(foodStore.FoodList[Id].AddDFS >= 0)
            {
                DFSText.text = "+" + foodStore.FoodList[Id].AddDFS.ToString();
            }
            else
                DFSText.text = foodStore.FoodList[Id].AddDFS.ToString();
            EffectText.text= foodStore.FoodList[Id].FoodEffect;
            rawImage.texture = imageCartoon.allTex2d[Id];
        }
        else
        {
            MoneylessTip.SetActive(true);
            return;
        }
    }

}
