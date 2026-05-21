using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Player : Creature
{
    [SerializeField] private int exp = 0;
    [SerializeField] private int level = 1;


    public int Level => level;
    public int Exp => exp;
    public void GainExp(int amount)
    {
        exp += amount;

        LevelUp();

    }

    public void ArryAttack(List<Monster> monsters)
    {
        Debug.Log("범위 공겨어어억!");
        monsters.ForEach(monster => monster.TakeDamage(Atk) );
        

    }

    private void LevelUp()
    {
        while (exp >= 100)
        {
            exp -= 100;
            level++;
            Atk += 3;
            Hp += 10;
            MaxHp += 10;
            Debug.Log($"레벨업! 현재 레벨 : {level}");
            Debug.Log(GetStatusText());
        }
    }

}
