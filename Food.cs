public class Food
{
    public int FoodId;
    public int AddHP;
    public int AddATK;
    public int AddDFS;
    public string FoodEffect;

    public Food(int _FoodId, string _FoodEffect, int _AddHP, int _AddATK, int _AddDFS)
    {
        FoodId = _FoodId;
        FoodEffect = _FoodEffect;
        AddHP = _AddHP;
        AddATK = _AddATK;
        AddDFS = _AddDFS;
    }
}