using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryDisplay : MonoBehaviour
{
    public string[] dataRow;
    public Text StoryShow;
    public TextAsset StoryData;
    // Start is called before the first frame update
    void Start()
    {
        dataRow = StoryData.text.Split('*');
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowStory_1()
    {
        StoryShow.text = dataRow[1];
    }
    public void ShowStory_2()
    {
        StoryShow.text = dataRow[2];
    }
    public void ShowStory_3()
    {
        StoryShow.text = dataRow[3];
    }
    public void ShowStory_4()
    {
        StoryShow.text = dataRow[4];
    }
    public void ShowStory_5()
    {
        StoryShow.text = dataRow[5];
    }
    public void ShowStory_6()
    {
        StoryShow.text = dataRow[6];
    }
    public void ShowStory_7()
    {
        StoryShow.text = dataRow[7];
    }
    public void ShowStory_8()
    {
        StoryShow.text = dataRow[8];
    }
    public void ShowStory_9()
    {
        StoryShow.text = dataRow[9];
    }
    public void ShowStory_10()
    {
        StoryShow.text = dataRow[10];
    }
    public void ShowStory_11()
    {
        StoryShow.text = dataRow[11];
    }
    public void ShowStory_12()
    {
        StoryShow.text = dataRow[12];
    }
    public void ShowStory_13()
    {
        StoryShow.text = dataRow[13];
    }
    public void ShowStory_14()
    {
        StoryShow.text = dataRow[14];
    }
    public void ShowStory_15()
    {
        StoryShow.text = dataRow[15];
    }
    public void ShowStory_16()
    {
        StoryShow.text = dataRow[16];
    }
    public void ShowStory_17()
    {
        StoryShow.text = dataRow[17];
    }
    public void ShowStory_18()
    {
        StoryShow.text = dataRow[18];
    }
    public void ShowStory_19()
    {
        StoryShow.text = dataRow[19];
    }
    public void ShowStory_20()
    {
        StoryShow.text = dataRow[20];
    }
}
