using System;
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


public enum MonsterRank
{
    Common,
    Elite,
    Boss
}
public enum MonsterState
{
    Idle,
    Chase,
    Attack,
    Dead
}
public class Monster : Creature
{
    [SerializeField] protected Reward reward;
    [SerializeField] protected Point point;
    [SerializeField] private int monsterExp;
    [SerializeField] protected MonsterState monsterState;
    [SerializeField] protected MonsterRank monsterRank;

    public event Action<Monster> OnDeadEvent;
    public Reward Reward => reward;
    public MonsterRank MonsterRank => monsterRank;
    public MonsterState CurrentState => monsterState;
    public Point Point => point;

    public int MonsterExp => monsterExp;


    protected void UpDateAI()
    {
        switch (CurrentState)
        {
            case MonsterState.Idle:
                {
                    Debug.Log("주변을 배회 합니다");
                }
                break;
            case MonsterState.Chase:
                {
                    Debug.Log("플레이어를 따라다닙니다");

                }
                break;
            case MonsterState.Attack:
                {
                    Debug.Log("플레이어를 공격합니다");

                }
                break;
            case MonsterState.Dead:
                {
                    Debug.Log("퇴치당했습니다");

                }
                break;

        }

    }

    protected void AddAtk()
    {
        switch (MonsterRank)
        {
            case MonsterRank.Common:
                {
                    int CommonAtk = 3;
                    Atk += CommonAtk;
                    Debug.Log($"{MonsterRank.Common}은 공격력이 {CommonAtk}증가!");
                    
                }
                break;
            case MonsterRank.Elite:
                {
                    int EliteAtk = 5;
                    Atk += EliteAtk;
                    Debug.Log($"{MonsterRank.Elite}은 공격력이 {EliteAtk}증가!");
                }
                break;
            case MonsterRank.Boss:
                {
                    int BossAtk = 10;
                    Atk += BossAtk;
                    Debug.Log($"{MonsterRank.Boss}은 공격력이 {BossAtk}증가!");
                }
                break;


        }
    }

    protected override void Awake()
    {
        base.Awake();
        AddAtk();
        
    }
    protected override void Die()
    {
        base.Die();
        OnDeadEvent?.Invoke(this);
    }
}
