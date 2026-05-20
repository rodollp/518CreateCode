using System.Linq;
using System.Collections.Generic;
using Assets.Script;
using Unity.VisualScripting;
using UnityEngine;

class Spawner
{
    public void Spawn<T>(T entity) where T : class, IDamageable
    {
        Debug.Log($"{entity}");

    }
}

public class Storage<T> where T : class
{
    private List<T> items = new List<T>();
    public void Add(T item)
    {
        items.Add(item);
        Debug.Log($"{item} 저장");
    }

    public T Get(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            return null;
        }
        return items[index];
    }

}
public class GameManager : MonoBehaviour
{
    [SerializeField] private Player Player;
    [SerializeField] private List<Monster> Monsters;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private Storage<Monster> monsterStorage = new Storage<Monster>();
    private Dictionary<string, Monster> findMons = new Dictionary<string, Monster>();
    private Queue<Monster> spawnQueue = new Queue<Monster>();
    private Queue<string> logs = new Queue<string>();

    
    

    void PrintLogs()
    {
        Debug.Log("===ComBatlog===");

        while (logs.Count > 0)
        {
            Debug.Log (logs.Dequeue());
        }
    }
    private Monster FindMonster(string monsterName)
    {
        // 딕셔너리에 이름이 존재하는지 확인
       if(findMons.TryGetValue(monsterName, out Monster monster))
        {
          return monster;  

        }
       return null;
    }
    void StartCombat()
    {
        FindMonster("Orc");
        FindMonster("Slime");

        while (!Player.IsDead && spawnQueue.Count > 0 )
        {
            Monster currentMonster = spawnQueue.Dequeue();
            
            
            
            logs.Enqueue($"{currentMonster.name} 등장!");
            
            
            while (!currentMonster.IsDead && !Player.IsDead)
            {
                Player.Attack(currentMonster);
                logs.Enqueue($"{Player.name} =>{currentMonster.name}공격");

                if (currentMonster.IsDead)
                {
                    Player.GainExp(currentMonster.MonsterExp);
                    logs.Enqueue($"{currentMonster.name} 처치");
                    break;
                }

                currentMonster.Attack(Player);
                logs.Enqueue($"{currentMonster.name}=>{Player.name} 공격");

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

        PrintLogs();
        
    }


    private void Start()
    {
        Spawner spawner = new Spawner();
        

        // 몬스터 초기 등록
        foreach (Monster m in Monsters)
        {
            // 몬스터 소환
            spawner.Spawn(m);

            // 저장소에 보관
            monsterStorage.Add(m);

            // 이름으로 검색 가능하게 등록
            findMons[m.name] = m;

            // 스폰 큐에 등록
            spawnQueue.Enqueue(m);

            // 생성 로그 저장
            logs.Enqueue($"{m.name} 소환됨");
        }

     
        StartCombat();

    }


}


