using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float OriginTime;
    private float RestTime;
    private int ShowTime;
    private bool StartMessage;

    public Text TimeText;
    public GameObject EndTips;
    // Start is called before the first frame update
    void Start()
    {
        RestTime = OriginTime;
        StartMessage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartMessage)
        {
            if (RestTime > 0)
            {
                RestTime -= Time.deltaTime;
                ShowTime = (int)RestTime % 60;
                TimeText.text = ShowTime.ToString();
            }
            else
            {
                EndTips.SetActive(true);
            }
        }
    }

    public void UpdateTime()
    {
        RestTime = OriginTime;
        EndTips.SetActive(false);
        StartMessage = true;
    }
}
