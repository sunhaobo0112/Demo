using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int level;
    private string _name;
    private float hp;
    private float mp;
    private float maxhp;
    private float maxmp;
    private float str;
    private float def;
    private float agi;
    private float crit;
    private float exp;
    private float damage;

    public float temp;
    private GameObject RoadBlock1;
    private GameObject RoadBlock2;

    public int Level { get => level; set => level = value; }
    public string Name { get => _name; set => _name = value; }
    public float Hp { get => hp; set => hp = value; }
    public float Mp { get => mp; set => mp = value; }
    public float Maxhp { get => maxhp; set => maxhp = value; }
    public float Maxmp { get => maxmp; set => maxmp = value; }
    public float Str { get => str; set => str = value; }
    public float Def { get => def; set => def = value; }
    public float Agi { get => agi; set => agi = value; }
    public float Crit { get => crit; set => crit = value; }
    public float Exp { get => exp; set => exp = value; }
    public float Damage { get => damage; set => damage = value; }

    private void Start()
    {
        Init();
    }

    public virtual void Init()
    {

    }

    public void TakeDamage(float value)
    {
        if (this.Hp < 0) return;
        if (Random.value > PlayerState.instance.crit)
        {
            temp = value * (1 - (this.def / (this.def + 50)));
        }
        else
        {
            temp = value * (1 - (this.def / (this.def + 50)))*1.5f;
        }
        if (temp < 1){
            this.Hp--;
            DamageLabel.instance.Show((int)temp);
        }
        else
        {
            print("enemy-" + temp);
            this.Hp -= (int)temp;
            DamageLabel.instance.Show((int)temp);
        }
        if (this.Hp <= 0)
        {
            //print(this.Maxhp);
            if (this.Maxhp == 2000)
            {
                MessageBox._instance.ShowMessageBox("新たな道は開いた！", TipsCode.pickup);
                RoadBlock1 = GameObject.FindGameObjectWithTag("RoadBlock1").gameObject;
                Destroy(RoadBlock1);
            }
            if (this.Maxhp == 2500)
            {
                MessageBox._instance.ShowMessageBox("新たな道は開いた！", TipsCode.pickup);
                RoadBlock2 = GameObject.FindGameObjectWithTag("RoadBlock2").gameObject;
                Destroy(RoadBlock2);
            }
            if (this.Maxhp == 4000)
            {
                MessageBox._instance.ShowMessageBox("ゲームクリア!!おめでとうございます!!", TipsCode.levelup);
            }
            this.GetComponent<EnemyBase>().es = EnemyState.Dead;
        }
    }

}
