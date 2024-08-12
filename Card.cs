public class Card
{
    public int Id;
    public string CardName;
    public string CardStage;
    public string CardEffect;

    public double Amount_MaxHP;
    public double Amount_RemainHP;
    public double Amount_LostHP;
    public double Amount_ATK;
    public double Amount_DFS;

    public Card(int _Id, string _CardName, string _CardStage, string _CardEffect, double _Amount_MaxHP, double _Amount_RemainHP, double _Amount_LostHP, double _Amount_ATK, double _Amount_DFS)
    {
        this.Id = _Id;
        this.CardName = _CardName;
        this.CardStage = _CardStage;
        this.CardEffect = _CardEffect;
        this.Amount_MaxHP = _Amount_MaxHP;
        this.Amount_RemainHP = _Amount_RemainHP;
        this.Amount_LostHP = _Amount_LostHP;
        this.Amount_ATK = _Amount_ATK;
        this.Amount_DFS = _Amount_DFS;
    }
}

/*public class Card
{
    public int Id;
    public string CardName;
    public string CardStage;
    public string CardEffect;
    public Card(int _Id, string _CardName, string _CardStage,string _CardEffect)
    {
        this.Id = _Id;
        this.CardName = _CardName;
        this.CardStage = _CardStage;
        this.CardEffect = _CardEffect;
    }
}

public class AttackCard : Card
{
    public double AttackAmount_HP;
    public double AttackAmount_ATK;
    public double AttackAmount_DFS;
    public AttackCard(int _Id, string _CardName, string _CardStage, string _CardEffect, double _AttackAmount_HP, double _AttackAmount_ATK, double _AttackAmount_DFS) : base(_Id, _CardName, _CardStage, _CardEffect)
    {
        this.AttackAmount_HP = _AttackAmount_HP;
        this.AttackAmount_ATK = _AttackAmount_ATK;
        this.AttackAmount_DFS = _AttackAmount_DFS;
    }
}

public class DefenseCard : Card
{
    public double DefenseAmount_HP;
    public double DefenseAmount_ATK;
    public double DefenseAmount_DFS;
    public DefenseCard(int _Id, string _CardName, string _CardStage, string _CardEffect, double _DefenseAmount_HP, double _DefenseAmount_ATK, double _DefenseAmount_DFS) : base(_Id, _CardName, _CardStage, _CardEffect)
    {
        this.DefenseAmount_HP = _DefenseAmount_HP;
        this.DefenseAmount_ATK = _DefenseAmount_ATK;
        this.DefenseAmount_DFS = _DefenseAmount_DFS;
    }
}

public class SupplyCard : Card
{
    public double SupplyAmount_HP;
    public double SupplyAmount_ATK;
    public double SupplyAmount_DFS;
    public SupplyCard(int _Id, string _CardName, string _CardStage, string _CardEffect, double _SupplyAmount_HP, double _SupplyAmount_ATK, double _SupplyAmount_DFS) : base(_Id, _CardName, _CardStage, _CardEffect)
    {
        this.SupplyAmount_HP=_SupplyAmount_HP;
        this.SupplyAmount_ATK=_SupplyAmount_ATK;
        this.SupplyAmount_DFS = _SupplyAmount_DFS;
    }
}

public class EquipCard : Card
{
    public double EquipAmount_HP;
    public double EquipAmount_ATK;
    public double EquipAmount_DFS;
    public EquipCard(int _Id, string _CardName, string _CardStage, string _CardEffect, double _EquipAmount_HP, double _EquipAmount_ATK, double _EquipAmount_DFS) : base(_Id, _CardName, _CardStage, _CardEffect)
    {
        this.EquipAmount_HP=_EquipAmount_HP;
        this.EquipAmount_ATK=_EquipAmount_ATK;
        this.EquipAmount_DFS=_EquipAmount_DFS;
    }
}*/

