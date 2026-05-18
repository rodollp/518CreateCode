using System.Linq;
using Assets.Script;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player Player;
    [SerializeField] private Monster[] Monsters;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {

        

    }



    private bool TryGetLoof(Monster m,out string lootName)
    {
        if(m.IsDead)
        {
            lootName = "동전"; return true;
        }
        else
        {
            lootName = "없음"; return false;
        }
    }


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
                    
                    Player.GainExp(100);
                    
                    if (TryGetLoof(m,out string lootName))
                    {
                        Debug.Log($"아이템 획득 : {lootName}");
                    }
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
