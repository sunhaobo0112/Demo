using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Normal,
    Hurt,
    Attack,
    Controlled,
    Dead
}

public enum NormalState
{
    Idle,
    Walk
}

public class EnemyBase : MonoBehaviour
{

    public delegate void AnimationPlay();
    protected AnimationPlay ap;

    protected Transform player;
    protected float distance;
    protected float speed;

    private EnemyHealth eh;

    public EnemyState es = EnemyState.Normal;
    public NormalState ns = NormalState.Idle;

    bool isdead = false;

    void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        player = GameObject.FindGameObjectWithTag(GameCommon.player).transform;
        eh=this.GetComponent<EnemyHealth>();
        speed = 4f;
    }

    void Update()
    {
        StatueLogic();
        if (ap != null)
        {
            ap();
        }
    }

    public void StatueLogic()
    {
        //if (eh.Hp < 0) return;
        switch(es)
        {
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Controlled:
                //
                break;
            case EnemyState.Dead:
                Death();
                break;
            case EnemyState.Hurt:
                Hurt();
                break;
            case EnemyState.Normal:
                Patrol();
                break;

        }
    }

    public void StateTransToAttack()
    {
        es = EnemyState.Attack;
    }

    public virtual void Patrol()
    {

    }

    public virtual void Hurt()
    {
        ap = PlayHurt;
    }

    public virtual void Death()
    {
        if (isdead == false)
        {
            PlayDead();
            ap = null;
            isdead = true;
            PlayerState.instance.GetExpAndUpGrade(eh.Exp);
        }
        player.GetComponent<PlayerController>().target = null;
        Destroy(this.gameObject, 1);
    }

    public virtual void Attack()
    {

    }

    public void AttackForPlayer()
    {
        //player.GetComponent<PlayerController>().target = this.transform;
        float temp = PlayerState.instance.agi;
        //player.GetComponent<PlayerController>().pb = PlayerBehaviour.EnterAtt;
        if (Random.value > temp)
        {
            float damage = this.GetComponent<EnemyHealth>().Damage;
            player.SendMessage("TakeDamage", damage);
            if (Random.value > 0.8)
            {
                player.GetComponent<PlayerController>().pb = PlayerBehaviour.Hurt;
            }
        }
        else
        {
            //miss
        }

    }

    public void LookAtTarget(Vector3 point)
    {
        Vector3 target = new Vector3(point.x, transform.position.y, point.z);
        transform.LookAt(target);
    }

    public void MoveForward()
    {
        if (GetComponent<Rigidbody>()!=null)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }
        else
        {
            this.gameObject.AddComponent<Rigidbody>();
        }
    }

    #region animation and sound
    public void PlayRun()
    {
        GetComponent<Animation>().CrossFade(new GameCommon().my_Anim_Name.run);
    }
    public void PlayAttIdle()
    {
        GetComponent<Animation>().CrossFade(new GameCommon().my_Anim_Name.att_idle);
    }
    public void PlayAtt01()
    {
        GetComponent<Animation>().CrossFade(new GameCommon().my_Anim_Name.att01);
    }
    public void PlayAtt02()
    {
        GetComponent<Animation>().CrossFade(new GameCommon().my_Anim_Name.att02);
    }
    public void PlayDead()
    {
        GetComponent<Animation>().CrossFade(new GameCommon().my_Anim_Name.dead);
    }
    public void PlayWalk()
    {
        GetComponent<Animation>().CrossFade(new GameCommon().my_Anim_Name.walk);
    }
    public void PlayIdle()
    {
        GetComponent<Animation>().CrossFade(new GameCommon().my_Anim_Name.idle);
    }
    public void PlayHurt()
    {
        GetComponent<Animation>().CrossFade(new GameCommon().my_Anim_Name.hurt);
    }

    public void PlayAnimation(string str)
    {
        GetComponent<Animation>().CrossFade(str);
    }

    public void PlaySound(AudioClip ac)
    {
        if(GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().PlayOneShot(ac);
        }
        else
        {
            this.gameObject.AddComponent<AudioSource>();
            GetComponent<AudioSource>().PlayOneShot(ac);
        }
    }
    #endregion

    public void OnMouseEnter()
    {
        CursorManager.instance.SetAttack();
    }

    public void OnMouseExit()
    {
        CursorManager.instance.SetNormal();
    }

}
