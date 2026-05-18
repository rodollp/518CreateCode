using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script
{
    internal interface IDamageable
    {
        void TakeDamage(int  damage);
        bool IsDead {  get; }
    }
}
