using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActive : EnemyBase
{
    public int AnimaID = 1;

    public float timer=0;
    public float att01_time;
    public float att02_time;
    public float att_rate;

    public override void Init()
    {
        base.Init();
        att01_time = 0.8f;
        att02_time = 0.8f;
        att_rate = 2;
        es = EnemyState.Attack;
    }


    public override void Attack()
    {
        LookAtTarget(player.position);
        distance = Vector3.Distance(transform.position, player.position);
        if (distance > 1.0f)
        {
            //print(distance);
            MoveForward();
            ap = PlayRun;
        }
        else
        {
            if (AnimaID == 1)
            {
                ap = PlayAtt01;
            }
            if (AnimaID == 2)
            {
                ap = PlayAtt02;
            }
            timer += Time.deltaTime;
            if (timer >= att01_time)
            {
                ap = PlayAttIdle;
            }
            if (timer > att_rate)
            {
                timer = 0;
                AnimaID = Random.Range(1, 3);
            }
        }
    }


}
