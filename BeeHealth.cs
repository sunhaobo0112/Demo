using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHealth : EnemyHealth
{
    public override void Init()
    {
        Level = 3;
        Hp = 300;
        Maxhp = 300;
        Mp = 100;
        Maxmp = 100;
        Name = "古墓玉蜂";
        Str = 50;
        Def = 50;
        Agi = 0.1f;
        Crit = 0.1f;
        Damage = Str;
        Exp = 30;
    }
}
