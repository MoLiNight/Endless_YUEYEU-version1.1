using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public bool Operation;

    public int TempOriginHP;
    public int LostHP;
    public int CurrentHP;
    public int CurrentATK;
    public int CurrentDFS;
    public int OriginHarm;
    public int Shields;

    public int AttackTwice;
    public double BloodLosing;
    public double BloodSucking;
    public double RealityAttack;

    public Text CurHP;
    public Text MaxHP;
    public Text CurATK;
    public Text CurDFS;
    public Text CurShields;
    public Text BloodLosingText;
    public Text BloodSuckingText;

    public EnemyStore enemyStore;
    public EnemyData enemyData;

    // Start is called before the first frame update
    void Start()
    {
        enemyStore.LoadEnemyStore();
        enemyData.LoadEnemyData();

        FirstDraw();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstDraw()
    {
        Operation = false;
        
        LostHP = 0;
        CurrentHP = enemyData.OriginHP;
        CurrentATK = enemyData.OriginATK;
        CurrentDFS = enemyData.OriginDFS;
        TempOriginHP = enemyData.OriginHP;

        Shields = 0;
        AttackTwice = 0;
        BloodLosing = 0;
        BloodSucking = 0;
        RealityAttack = 0;

        CurHP.text = CurrentHP.ToString();
        CurATK.text = CurrentATK.ToString();
        CurDFS.text = CurrentDFS.ToString();
        MaxHP.text = TempOriginHP.ToString();
        CurShields.text = Shields.ToString();
        BloodLosingText.text = BloodLosing.ToString();
        BloodSuckingText.text = BloodSucking.ToString();
    }

    public void JudgeAndUseCard(Card card, int Id)
    {
        OriginHarm = 0;
        switch (Id)
        {
            case 0:
                {
                    TempOriginHP = (int)(TempOriginHP * card.Amount_MaxHP);
                    CurrentHP = (int)(CurrentHP * card.Amount_RemainHP);
                    CurrentATK = (int)(CurrentATK * card.Amount_ATK);
                    CurrentDFS = (int)(CurrentDFS * card.Amount_DFS);
                    break;
                }
            case 1:
            case 2:
                {
                    CurrentATK += (int)(CurrentDFS * card.Amount_DFS);
                    CurrentDFS += (int)(CurrentATK * card.Amount_ATK);
                    if(Id==1) 
                    { 
                        CurrentDFS = 0;
                    }
                    if(Id==2) 
                    {  
                        CurrentATK = 0;
                    }
                    break;
                }
            case 3:
            case 4:
                {
                    OriginHarm = (int)(card.Amount_ATK * CurrentATK + card.Amount_DFS * CurrentDFS);
                    break;
                }
            case 5:
                {
                    OriginHarm = Shields * 3;
                    Shields = 0;
                    break;
                }
            case 6:
            case 7:
            case 8:
                {
                    Shields += (int)(CurrentDFS +  CurrentATK + card.Amount_RemainHP * CurrentHP);
                    if (Id == 6)
                    {
                        CurrentDFS = (int)(CurrentDFS * card.Amount_DFS);
                    }
                    if(Id == 7)
                    {
                        CurrentATK = (int)(CurrentATK * card.Amount_ATK);
                    }
                    if(Id == 8)
                    {
                        CurrentHP = (int)(CurrentHP * card.Amount_RemainHP);
                        CurrentATK = (int)(CurrentATK * card.Amount_ATK);
                    }
                    break;
                }
            case 9:
            case 10:
            case 11:
                {
                    CurrentHP += (int)(CurrentATK * card.Amount_ATK + CurrentDFS * card.Amount_DFS + CurrentHP * card.Amount_RemainHP + LostHP * card.Amount_LostHP);
                    if (CurrentHP > TempOriginHP)
                    {
                        CurrentHP = TempOriginHP;
                    }
                    break;
                }
            case 12:
            case 13:
                {
                    AttackTwice = 1;
                    OriginHarm = (int)(CurrentATK * card.Amount_ATK + CurrentHP * card.Amount_RemainHP);
                    break;
                }
            case 14:
                {
                    BloodSucking += 0.25f;
                    break;
                }
            case 15:
                {
                    BloodSucking += BloodLosing * 1.5f;
                    break;
                }
            case 16:
                {
                    OriginHarm = (int)(BloodSucking * 5 * CurrentATK);
                    break;
                }
            case 17:
                {
                    BloodLosing += 0.25f;
                    break;
                }
            case 18:
                {
                    BloodLosing += BloodSucking * 1.5f;
                    break;
                }
            case 19:
                {
                    OriginHarm = (int)(BloodLosing * 10 * CurrentATK);
                    break;
                }
            case 20:
            case 21:
            case 22:
                {
                    OriginHarm = (int)(CurrentATK * card.Amount_ATK + CurrentDFS * card.Amount_DFS + LostHP * card.Amount_LostHP);
                    RealityAttack = 1.0f;
                    break;
                }
            default: break;
        }

        Operation = true;
    }

}
