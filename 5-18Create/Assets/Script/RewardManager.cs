using UnityEngine;
using System.Linq;
using System.Collections.Generic;
public class RewardManager
{
    private Monster monster;


    public Monster Monster => monster;


    public void TryAdd(Monster monster)
    {

        monster.OnDeadEvent += RewardDrop;

    }

    void RewardDrop(Monster monster)
    {
        Reward reward = monster.Reward;

        Debug.Log($"{monster.name}Ã³Ä¡!" +
            $"º¸»ó :{reward.itemName} , °ñµå : {reward.gold}°ñµå");


    }

}
