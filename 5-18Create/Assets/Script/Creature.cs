using Assets.Script;
using UnityEngine;

public class Creature : MonoBehaviour , IDamageable
{
    [SerializeField] private string _name;
    [SerializeField] private int _Atk;
    [SerializeField] private int _MaxHp;

    protected int _Hp;
    public string Name => _name;

    protected virtual void Awake()
    {
       
        Hp = MaxHp;
     
    }


    public int Atk
    {
        get { return _Atk; }

        set
        {
            _Atk = Mathf.Max(0, value);
        }
    }

    public string GetStatusText()
    {
        return $"{Name} : HP[{Hp}/{MaxHp}], 공격력[{Atk}]";
    }



    public int Hp
    {
        get => _Hp;

        protected set
        {
            _Hp = Mathf.Clamp(value, 0, MaxHp);
        }
    }

    public int MaxHp
    {
        get
        {
            return _MaxHp;
        }

        protected set
        {
            _MaxHp = Mathf.Max(1, value);
            Hp = Mathf.Min(Hp, _MaxHp);
        }
    }

    public virtual void TakeDamage(int damage)
    {
        Hp -= damage;
        Debug.Log($"<{Name}>가(이) [{damage}]의 피해를 입었습니다. Hp : [{Hp}]");

        if (Hp <= 0)
        {
            Die();
        }

    }



    public virtual void Attack(Creature target)
    {
        Debug.Log($"<{Name}>가(이) [{Atk}]의 공격력으로 공격했습니다.");

        target.TakeDamage(Atk);
    }



    public bool IsDead
    {
        get
        {
            return Hp <= 0;
        }
    }



    protected virtual void Die()
    {
        Hp = 0;
        Debug.Log($"<{Name}>가(이) 사망했습니다.");



    }
}

