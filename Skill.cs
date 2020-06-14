using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UseType
{
    output,
    buff,
    other

}

public class Skill
{

    public int id;
    public string _name;
    public string icon_name;
    public string people;//对单人还是对多人
    public UseType useType;//作用类型
    public float atk;//伤害
    public float str;//攻击
    public float def;//防御
    public float plusMaxHP;//血上限
    public float plusMaxMP;//蓝上限
    public float crit;//暴击率
    public float agi;//闪避率
    public string des;//描述
    public float recovery;//恢复率
    public int level;//解锁等级
    public float coldtime;//冷却时间
    public float costMP;//花费的魔法值
}