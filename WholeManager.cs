using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WholeManager : MonoBehaviour
{
    private int ActionDraw;
    private bool EndSignal;
    private bool StartSignal;

    private BattleManager battleManager;
    private EnemyManager enemyManager;

    public Text DrawCounter;
    public Text EnemyCardName;
    public Text EnemyCardStage;
    public Text EnemyCardEffect;

    public GameObject DrawText;
    public GameObject VictoryDialog;
    public GameObject FailDialog;
    public GameObject TimeDialog;
    public GameObject PlayerDataManager;
    public GameObject EnemyDataManager;
    // Start is called before the first frame update
    void Start()
    {
        battleManager = PlayerDataManager.GetComponent<BattleManager>();
        enemyManager = EnemyDataManager.GetComponent<EnemyManager>();
        
        NewBattle();
    }

    // Update is called once per frame
    void Update()
    {
        if (!EndSignal)
        {
            if (battleManager.Operation)
            {
                int FinalHarm = 0;
                double Amount_Reality = 1;
                if (battleManager.RealityAttack > 0)
                {
                    Amount_Reality = 0;
                    battleManager.RealityAttack -= 1.0f;
                }
                FinalHarm = (int)(battleManager.OriginHarm - (int)(enemyManager.CurrentDFS * Amount_Reality));
                if(FinalHarm < 0) 
                { 
                    FinalHarm = 0; 
                }
                for (int i = 0; i <= battleManager.AttackTwice; i++)
                {
                    enemyManager.Shields -= FinalHarm;
                    battleManager.CurrentHP += (int)(FinalHarm * battleManager.BloodSucking);
                    battleManager.CurrentHP -= (int)(FinalHarm * battleManager.BloodLosing);
                }

                if (enemyManager.Shields < 0)
                {
                    enemyManager.CurrentHP += enemyManager.Shields;
                    enemyManager.Shields = 0;
                }
                if (battleManager.TempSucking)
                {
                    battleManager.TempSucking = false;
                    battleManager.BloodSucking -= 3.0f;
                }
                enemyManager.Operation = false;
                battleManager.Operation = false;

                StartSignal = true;
                UpdateTextAndJudgeResult();

            }
            else
            if (!enemyManager.Operation && StartSignal)
            {
                if (!battleManager.SkipEnemyDraw)
                {
                    enemyManager.JudgeAndUseCard(enemyManager.enemyData.EnemyDesign[ActionDraw], enemyManager.enemyData.EnemyDesign[ActionDraw].Id);
                    
                    int FinalHarm = 0;
                    double Amount_Reality = 1;
                    if (enemyManager.RealityAttack > 0)
                    {
                        Amount_Reality = 0;
                        enemyManager.RealityAttack = 0;
                    }
                    FinalHarm = (int)(enemyManager.OriginHarm - (int)(battleManager.CurrentDFS * Amount_Reality));
                    if (FinalHarm < 0)
                    {
                        FinalHarm = 0;
                    }
                    for (int i = 0; i <= enemyManager.AttackTwice; i++)
                    {
                        battleManager.Shields -= FinalHarm;
                        enemyManager.CurrentHP += (int)(FinalHarm * enemyManager.BloodSucking);
                        enemyManager.CurrentHP -= (int)(FinalHarm * enemyManager.BloodLosing);
                    }
                    if (enemyManager.AttackTwice == 1)
                    {
                        enemyManager.AttackTwice = 0;
                    }

                    if (battleManager.Shields < 0)
                    {
                        battleManager.CurrentHP += battleManager.Shields;
                        battleManager.Shields = 0;
                    }

                    EnemyCardName.text = enemyManager.enemyData.EnemyDesign[ActionDraw].CardName;
                    EnemyCardStage.text = enemyManager.enemyData.EnemyDesign[ActionDraw].CardStage;
                    EnemyCardEffect.text = enemyManager.enemyData.EnemyDesign[ActionDraw].CardEffect;

                }

                ActionDraw++;
                battleManager.SkipEnemyDraw = false;
                battleManager.SummonCard();
                enemyManager.Operation = true;
                
                UpdateTextAndJudgeResult();
            }
            
        }
    }

    public void NewBattle()
    {
        ActionDraw = 0;
        EndSignal = false;
        StartSignal = false;
        TimeDialog.SetActive(false);
        FailDialog.SetActive(false);
        VictoryDialog.SetActive(false);
        DrawCounter.text = (ActionDraw + 1).ToString();
        DrawText.SetActive(true);
    }

    public void UpdateTextAndJudgeResult()
    {
        if (battleManager.CurrentHP <= 0)
        {
            EndSignal = true;
            FailDialog.SetActive(true);
            DrawText.SetActive(false);
        }
        else
        if (ActionDraw >= 10)
        {
            EndSignal = true;
            TimeDialog.SetActive(true);
            DrawText.SetActive(false);
        }
        else
        if (enemyManager.CurrentHP <= 0)
        {
            EndSignal = true;
            VictoryDialog.SetActive(true);
            DrawText.SetActive(false);
            battleManager.playerData.PlayerCoins += 10;
            battleManager.playerData.SavePlayerData();
        }

        enemyManager.LostHP = enemyManager.TempOriginHP - enemyManager.CurrentHP;
        battleManager.LostHP = battleManager.TempOriginHP - battleManager.CurrentHP;

        DrawCounter.text = (ActionDraw + 1).ToString();

        battleManager.CurHP.text = battleManager.CurrentHP.ToString();
        battleManager.CurATK.text = battleManager.CurrentATK.ToString();
        battleManager.CurDFS.text = battleManager.CurrentDFS.ToString();
        battleManager.MaxHP.text = battleManager.TempOriginHP.ToString();
        battleManager.CurShields.text = battleManager.Shields.ToString();

        enemyManager.CurHP.text = enemyManager.CurrentHP.ToString();
        enemyManager.CurATK.text = enemyManager.CurrentATK.ToString();
        enemyManager.CurDFS.text = enemyManager.CurrentDFS.ToString();
        enemyManager.MaxHP.text = enemyManager.TempOriginHP.ToString();
        enemyManager.CurShields.text = enemyManager.Shields.ToString();
        enemyManager.BloodLosingText.text = enemyManager.BloodLosing.ToString();
        enemyManager.BloodSuckingText.text = enemyManager.BloodSucking.ToString();
    }

}
