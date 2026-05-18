using UnityEngine;

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

    private void LevelUp()
    {
        if (exp >= 100)
        {
            exp -= 100;
            level++;

            Debug.Log($"레벨업! 현재 레벨 : {level}");
        }
    }

}
