using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHealthBoss2 : EnemyHealth
{
    public override void Init()
    {
        Level = 10;
        Hp = 2500;
        Maxhp = 2500;
        Mp = 100;
        Maxmp = 100;
        Name = "古墓玉蜂boss";
        Str = 600;
        Def = 100;
        Agi = 0.1f;
        Crit = 0.15f;
        Damage = Str;
        Exp = 1500;
    }

}
