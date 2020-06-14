using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHealthBoss3 : EnemyHealth
{
    public override void Init()
    {
        Level = 10;
        Hp = 4000;
        Maxhp = 4000;
        Mp = 100;
        Maxmp = 100;
        Name = "古墓玉蜂boss";
        Str = 900;
        Def = 300;
        Agi = 0.1f;
        Crit = 0.15f;
        Damage = Str;
        Exp = 0;
    }

}
