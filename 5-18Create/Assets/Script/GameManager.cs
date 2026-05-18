using System.Linq;
using Assets.Script;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player Player;
    [SerializeField] private Monster[] Monsters;
    // Start is called once before the first execution of Update after the MonoBehaviour is created




    void StartCombat()
    {
        while (!Player.IsDead && Monsters.Any(m => !m.IsDead))
        {
            foreach (Monster m in Monsters)
            {

                if (m.IsDead)
                {
                    continue;
                }
                Player.Attack(m);

                if (m.IsDead)
                {
                    Player.GainExp(m.MonsterExp);
                    continue;
                }

                m.Attack(Player);
            }


        }
        if (Player.IsDead)
        {
            Debug.Log("플레이어 패배");

        }
        else
        {
            Debug.Log("승리!");

        }

    }


    private void Start()
    {
        StartCombat();
    }

}
