using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBoss : EnemyBase
{
    //public float patrol_timer;
    //public float idle_time;
    //public float walk_time;

    public int AnimaID = 1;

    public float timer;
    public float att01_time;
    public float att02_time;
    public float att_rate;

    public override void Init()
    {
        base.Init();
        att01_time = 0.8f;
        att02_time = 0.8f;
        att_rate = 2;
    }

    /*public override void Patrol()
    {
        patrol_timer += Time.deltaTime;
        if (ns == NormalState.Idle)
        {
            ap = PlayIdle;
        }
        if (patrol_timer > idle_time)
        {
            ns = NormalState.Walk;
            ap = PlayWalk;
            MoveForward();
        }
        if (patrol_timer > walk_time)
        {
            patrol_timer = 0;
            transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            ns = NormalState.Idle;
        }
    }*/

    public override void Attack()
    {
        LookAtTarget(player.position);
        distance = Vector3.Distance(transform.position, player.position);
        if (distance > 1f)
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
