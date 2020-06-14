using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // Start is called before the first frame update

    public static PlayerState instance { get; private set; }
    public string playerName;
    public string playerIcon;
    public int level;
    public float hp;
    public float maxHp;
    public float mp;
    public float maxMp;
    public float exp;
    public float maxExp;
    public float atk;
    public float str;
    public float def;
    public float agi;
    public float crit;
    public SexType sexType;


    public Dictionary<int, GameCommon.InfoChangeEvent> infochangeDic = new Dictionary<int, GameCommon.InfoChangeEvent>();

    public void Awake()
    {
        instance = this;
        Init();
    }

    public void Init()
    {
        this.playerName = "主人公";
        this.playerIcon = "天青";
        this.level = 3;
        this.hp = 100;
        this.maxHp = 100;
        this.mp = 80;
        this.maxMp = 80;
        this.exp = 0;
        this.maxExp = 30;
        this.atk = 180;
        this.str = 150;
        this.def = 80;
        this.agi = 0.2f;
        this.crit = 0.1f;
        sexType = SexType.man;
    }

    public void PutOn(float _maxhp, float _maxmp, float _str, float _def, float _agi, float _crit)
    {
        this.maxHp += _maxhp;
        this.hp += _maxhp;
        this.maxMp += _maxmp;
        this.mp += _maxmp;
        this.str += _str;
        this.def += _def;
        this.agi += _agi;
        this.crit += _crit;
        this.atk = (int)(this.str + (this.hp / this.maxHp) * 10 * level);
        ChangeEvent();
    }

    public void Takeoff(float _maxhp, float _maxmp, float _str, float _def, float _agi, float _crit)
    {
        this.maxHp -= _maxhp;
        this.hp -= _maxhp;
        this.maxMp -= _maxmp;
        this.mp -= _maxmp;
        this.str -= _str;
        this.def -= _def;
        this.agi -= _agi;
        this.crit -= _crit;
        this.atk = (int)(this.str + (this.hp / this.maxHp) * 10 * level);
        ChangeEvent();
    }

    public void RegisterEvent(int key, GameCommon.InfoChangeEvent infochange)
    {
        infochangeDic.Add(key, infochange);
    }

    void ChangeEvent()
    {
        if (infochangeDic.Count > 0)
        {
            foreach (int i in infochangeDic.Keys)
            {
                if (infochangeDic.ContainsKey(i))
                {
                    infochangeDic[i]();
                }
            }
        }
    }

    public void TakeDamage(float value)
    {
        ChangeEvent();
        if (this.hp < 0) return;
        float temp = value * (1 - (this.def / (this.def + 20))) / 2;
        if (temp < 1)
        {
            this.hp--;
        }
        else
        {
            print("player-" + temp);
            this.hp -= (int)temp;
        }
        if (this.hp <= 0)
        {
            this.GetComponent<PlayerController>().pb = PlayerBehaviour.Dead;
        }
    }

    public void CostMp(float value)
    {
        this.mp -= value;
        ChangeEvent();
    }
    //get exp
    public void GetExpAndUpGrade(float exp)
    {
        this.exp += exp;
        while (this.exp >= maxExp)
        {
            level++;
            this.exp -= maxExp;
            maxExp = (level - 2) * 30;
            maxHp += 10;
            hp += 10;
            maxMp += 2;
            mp += 2;
            str += 10;
            def += 5;
            atk = (int)(str + (hp / maxHp) * 10 * level);
            LevelMessageBox._instance.ShowLevelMessageBox("Lv." + level + "になりました", TipsCode.levelup);
        }
        ChangeEvent();
    }
    //drug
    public void UpdateDateUp(float hp, float mp)
    {
        this.hp += hp;
        this.mp += mp;
        if (this.hp > this.maxHp)
        {
            this.hp = this.maxHp;
        }
        if (this.mp > maxMp)
        {
            this.mp = this.maxMp;
        }
        ChangeEvent();
    }

    public void Skill1002Start()
    {
        this.maxHp += 110;
        this.maxMp += 20;
        this.hp += 110;
        this.mp += 20;
        this.crit += 0.1f;
        ChangeEvent();
    }
    public void Skill1002End()
    {
        this.maxHp -= 110;
        this.maxMp -= 30;
        if (this.hp > this.maxHp)
        {
            this.hp = this.maxHp;
        }
        if (this.mp > this.maxMp)
        {
            this.mp = this.maxMp;
        }
        this.crit -= 0.1f;
        ChangeEvent();
    }

    public void Skill1003Start()
    {
        this.maxHp += 200;
        this.hp += 200;
        this.def += 100;
        this.agi += 0.15f;
        ChangeEvent();
    }
    public void Skill1003End()
    {
        this.maxHp -= 200;
        if (this.hp > this.maxHp)
        {
            this.hp = this.maxHp;
        }
        this.def -= 100;
        this.agi -= 0.15f;
        ChangeEvent();
    }

}
