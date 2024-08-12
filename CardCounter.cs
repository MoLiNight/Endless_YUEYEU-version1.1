using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCounter : MonoBehaviour
{
    public Text CounterText;
    private int CounterValue = 0;
    public bool SetCounter(int counter)
    {
        CounterValue += counter;
        CounterText.text = CounterValue.ToString();
        if(CounterValue==0)
        {
            Destroy(gameObject);
            return false;
        }
        return true;
    }
}
