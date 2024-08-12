using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathTestMaker : MonoBehaviour
{
    private int FirstNumber;
    private int SecondNumber;
    private int TrueAnswer;
    private int TruePosition;
    private int TrueCounter = 0;
    private int FalseCounter = 0;
    private bool SuccessFlag = false;

    public Text Question;
    public Text AnswerOne;
    public Text AnswerTwo;
    public Text AnswerThree;
    public Text TrueCounterText;
    public Text FalseCounterText;
    public Text TotalCounterText;
    public Text ResultText;

    private PlayerData playerData;
    public GameObject DataManager;
    public GameObject TruePicture;
    public GameObject FalsePicture;
    // Start is called before the first frame update
    void Start()
    {
        playerData = DataManager.GetComponent<PlayerData>();
        playerData.CardStore.LoadCardData();
        playerData.LoadPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomAddTest()
    {
        TruePicture.SetActive(false);
        FalsePicture.SetActive(false);
        FirstNumber = Random.Range(1, 21);
        SecondNumber = Random.Range(1, 21);
        TrueAnswer = FirstNumber + SecondNumber;
        Question.text = FirstNumber.ToString() + " + " + SecondNumber.ToString() + " =  ?";
        RandomAnswerLayer(TrueAnswer - Random.Range(1, 6), TrueAnswer, TrueAnswer + Random.Range(1, 6));
    }

    public void RandomMultiplyTest()
    {
        TruePicture.SetActive(false);
        FalsePicture.SetActive(false);
        FirstNumber = Random.Range(1, 10);
        SecondNumber = Random.Range(1, 10);
        TrueAnswer = FirstNumber * SecondNumber;
        Question.text = FirstNumber.ToString() + " × " + SecondNumber.ToString() + " =  ?";
        RandomAnswerLayer(TrueAnswer - Random.Range(1, 10), TrueAnswer, TrueAnswer + Random.Range(1, 10));
    }

    public void RandomAnswerLayer(int firstAnswer, int trueAnswer, int thirdAnswer)
    {
        TruePosition = Random.Range(1, 4);
        switch (TruePosition)
        {
            case 1: AnswerOne.text = trueAnswer.ToString(); AnswerTwo.text = firstAnswer.ToString(); AnswerThree.text = thirdAnswer.ToString(); break;
            case 2: AnswerTwo.text = trueAnswer.ToString(); AnswerOne.text = firstAnswer.ToString(); AnswerThree.text = thirdAnswer.ToString(); break;
            case 3: AnswerThree.text = trueAnswer.ToString(); AnswerOne.text = firstAnswer.ToString(); AnswerTwo.text = thirdAnswer.ToString(); break;
        }
    }

    public void JudgeFirstButton()
    {
        if (TruePosition == 1)
        {
            TrueCounter++;
            TruePicture.SetActive(true);
        }
        else
        {
            FalseCounter++;
            FalsePicture.SetActive(true);
        }
        UpdateCounterText();
    }

    public void JudgeSecondButton()
    {
        if(TruePosition == 2)
        {
            TrueCounter++;
            TruePicture.SetActive(true);
        }
        else
        {
            FalseCounter++;
            FalsePicture.SetActive(true);
        }
        UpdateCounterText();
    }

    public void JudgeThirdButton()
    {
        if (TruePosition == 3)
        {
            TrueCounter++;
            TruePicture.SetActive(true);
        }
        else
        {
            FalseCounter++;
            FalsePicture.SetActive(true);
        }
        UpdateCounterText();
    }

    public void UpdateCounter()
    {
        TrueCounter = 0;
        FalseCounter = 0;
        SuccessFlag = false;
    }

    public void UpdateCounterText()
    {
        TrueCounterText.text = TrueCounter.ToString();
        FalseCounterText.text = FalseCounter.ToString();
        TotalCounterText.text = (TrueCounter + FalseCounter).ToString();
        if (TrueCounter - FalseCounter >= 10)
        {
            ResultText.text = "挑战成功，兔头+10";
            if (!SuccessFlag)
            {
                SuccessFlag = true;
                playerData.PlayerCoins += 10;
                playerData.SavePlayerData();
            }
        }
        else
        {
            if (SuccessFlag)
            {
                SuccessFlag = false;
                playerData.PlayerCoins -= 10;
                playerData.SavePlayerData();
            }
            ResultText.text = "挑战失败";
        }
    }
}
