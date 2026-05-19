using UnityEngine;
[System.Serializable]
public struct Reward
{
    public string itemName;
    public int gold;

    public Reward(string itemName, int gold)
    {
        this.itemName = itemName;
        this.gold = gold;

    }
}
[System.Serializable]
public struct Point
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class Monster : Creature
{
    [SerializeField] protected Reward reward;
    [SerializeField] protected Point point;
    [SerializeField] private int monsterExp;
    public Reward Reward => reward;
    public Point Point => point;

    public int MonsterExp => monsterExp;

    protected override void Awake()
    {
        base.Awake();
        
    }
    protected override void Die()
    {
        base.Die();
        Debug.Log($"위치 :  ({point.x},{point.y}) 몬스터 보상 : {reward.itemName} , {reward.gold}골드");

    }
}
