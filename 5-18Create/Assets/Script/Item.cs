using Unity.VisualScripting;
using UnityEngine;


public class Item
{
    public string itemName;
    public int Count;

    public Item(string itemName, int count)
    {
        this.itemName = itemName;
        this.Count = count;
    }

    public Item(string name) : this(name, 1) { }


    public void UseTo(int count, Creature target)
    {
        if (Count <= 0)
        {
            Debug.Log($"{itemName}이 없습니다");
            return;
        }

        int useableCount = Mathf.Max(count, Count);
        Debug.Log($"{itemName}을  {useableCount}개 사용");

        for (int i = 0; i < useableCount; i++)
        {

        }
        
        Count -= useableCount;
    }

    public void Print()
    {
        Debug.Log(GetItemText());
    }
    public string GetItemText()
    {
        return $"{itemName} : {Count}개 ";
    }
    protected void UseEffect(Creature target)
    {

    }

}
