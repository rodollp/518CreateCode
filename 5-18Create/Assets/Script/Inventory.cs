using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // 아이템 이름을 Key로 사용
    // 같은 이름의 아이템을 빠르게 찾기 위한 Dictionary
    // ex) mybag["Potion"]
    private Dictionary<string, Item> mybag =
        new Dictionary<string, Item>();


    private void Start()
    {
        // 인벤토리 초기화
        mybag = new Dictionary<string, Item>();
    }


    // 아이템 추가
    public void AddItem(Item item)
    {
        // 수량이 0 이하이면 추가하지 않음
        if (item.Count <= 0)
        {
            return;
        }

        // 이미 같은 이름의 아이템이 존재하는지 확인
        if (mybag.TryGetValue(item.itemName, out Item curitem))
        {
            // 기존 아이템 수량 증가
            curitem.Count += item.Count;
        }
        else
        {
            // 새로운 아이템 등록
            mybag[item.itemName] = item;
        }

        // 현재 아이템 보유 수량 출력
        Debug.Log(
            $"{item.itemName}을 {item.Count}개 얻었습니다 " +
            $"현재 {mybag[item.itemName].Count}개 보유중"
        );
    }


    // 특정 수량만큼 아이템 제거
    public void RemoveItem(string itemName, int count)
    {
        // 아이템 존재 확인
        if (mybag.TryGetValue(itemName, out Item curItem))
        {
            // 아이템 수량 감소
            curItem.Count -= count;

            // 수량이 0 이하이면 인벤토리에서 제거
            if (curItem.Count <= 0)
            {
                mybag.Remove(itemName);
            }
        }
    }


    // 아이템 1개 제거용 오버로드 함수
    public void RemoveItem(string itemName)
    {
        RemoveItem(itemName, 1);
    }


    // 아이템을 안전하게 가져오기
    // 성공 시 true 반환
    public bool TryGetItem(string itemName, out Item curitem)
    {
        return mybag.TryGetValue(itemName, out curitem);
    }


    // 아이템 반환
    // 없으면 null 반환
    public Item GetItem(string itemName)
    {
        if (mybag.TryGetValue(itemName, out Item curitem))
        {
            return curitem;
        }

        return null;
    }


    // 아이템 사용
    // count 개수만큼 target 에게 사용
    public bool TryUseItem(
        string itemName,
        int count,
        Creature target)
    {
        // 아이템 존재 확인
        if (TryGetItem(itemName, out Item item))
        {
            // 아이템 효과 사용
            item.UseTo(count, target);

            // 수량이 0 이하이면 제거
            if (item.Count <= 0)
            {
                RemoveItem(itemName);
            }

            return true;
        }

        // 아이템이 없으면 실패
        return false;
    }


    // 아이템 1개 사용용 오버로드 함수
    public bool TryUseItem(string itemName, Creature target)
    {
        return TryUseItem(itemName, 1, target);
    }


    // 현재 인벤토리 아이템 출력
    public void PrintItems()
    {
        // Dictionary 전체 순회
        foreach (KeyValuePair<string, Item> pair in mybag)
        {
            // 아이템 정보 출력
            pair.Value.Print();
        }
    }
}