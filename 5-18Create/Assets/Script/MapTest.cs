using System.Text;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;




public class MapTest : MonoBehaviour
{
    [SerializeField] private List<Monster> monsters;

    public List<Monster> Monsters => monsters;
    Monster[,] worldMap = new Monster[5, 5];
    private void Start()
    {
        

        foreach (Monster m in Monsters)
        {
            int num = Random.Range(0, 5);
            int num2 = Random.Range(0, 5);
            worldMap[num,num2] = m;

        }


        PrintMonster();

        SearchMonster("  orc    ");
    }

    private void SearchMonster(string input)
    {
        input = input.Trim().ToLower();
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                Monster m = worldMap[x,y];
                if (m == null) continue;

                string monsterName = 
                    m.name.ToLower();
                
                if (monsterName == input)
                {
                    Debug.Log($"좌표 : ({x},{y})" + $" 이름:{m.name}" + $"체력:{m.Hp}" + $"등급:{m.MonsterRank}");
                }
                return;
            }
        }
        Debug.Log("없음");
    }

    private void PrintMonster()
    {
        StringBuilder sb = new StringBuilder();
        for (int y = 0; y < 5; y++)
        {
            for(int x = 0; x < 5; x++)
            {
                Monster mons = worldMap[x,y];
                if (mons == null)
                {
                    continue;
                }

                sb.AppendFormat(
                    "좌표 : {0},{1} | 이름: {2} | 공격력 : {3} | 체력 : {4} | 등급 : {5} \n",
                    x,
                    y,
                    mons.name,
                    mons.Atk,
                    mons.Hp,
                    mons.MonsterRank);
            }
        }
        Debug.Log(sb.ToString());
    }

}
