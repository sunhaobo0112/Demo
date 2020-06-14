using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHealth1 : EnemyHealth
{
    public override void Init()
    {
        Level = 10;
        Hp = 800;
        Maxhp = 800;
        Mp = 100;
        Maxmp = 100;
        Name = "古墓玉蜂";
        Str = 300;
        Def = 80;
        Agi = 0.1f;
        Crit = 0.1f;
        Damage = Str;
        Exp = 180;
    }
}
