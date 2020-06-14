using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerBehaviour
{
    ExitAtt,
    EnterAtt,
    Skill,
    Dead,
    Hurt,
    Controlled
}

public class PlayerController : MonoBehaviour
{
    public PlayerBehaviour pb;
    public PlayerBehaviour old_pb;
    public CharacterController cc;
    private Vector3 targetPoint;//targetpoint on the ground
    private float distance;
    public float speed;

    public Transform target = null;//enemy target
    private float attDistance;//attack range
    public float att_rate = 1.5f;
    private float timer;

    //public PlayerBehaviour value = PlayerBehaviour.ExitAtt;
    public GameObject ef_move;//move effect
    public GameObject ef_skill01;
    public GameObject ef_skill04;
    public Vector3 skillPoint = Vector3.zero;
    public Transform skill01_point;

    public GameObject Replay;

    void Start()
    {

        cc = this.GetComponent<CharacterController>();
        targetPoint = transform.position;        
        speed = 4f;
        pb = PlayerBehaviour.ExitAtt;
    }

    private void Update()
    {
        ControlLogic();
        if (Input.GetKeyDown(KeyCode.U))
        {
            PlayerState.instance.GetExpAndUpGrade((PlayerState.instance.level-2)*30);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.localPosition = new Vector3(10, 11, 2);
            targetPoint = transform.position;
        }
    }

    void ControlLogic()
    {
        switch (pb)
        {
            case PlayerBehaviour.ExitAtt:
                MoveControl();
                break;
            case PlayerBehaviour.EnterAtt:
                AttackControl();
                break;
            case PlayerBehaviour.Hurt:
                HurtControl();
                break;
            case PlayerBehaviour.Skill:
                SkillControl();
                break;
            case PlayerBehaviour.Dead:
                MessageBox._instance.ShowMessageBox("Game Over",TipsCode.none);
                Replay.gameObject.SetActive(true);              
                break;
            case PlayerBehaviour.Controlled:
                break;
        }
    }

    //keyboard
    /*void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            cc.SimpleMove(transform.forward*speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            cc.SimpleMove(transform.forward * -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cc.SimpleMove(transform.right * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            cc.SimpleMove(transform.right * -speed);
        }
    }*/
    //mouse
    void MoveControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isCrash = Physics.Raycast(ray, out hit);
            if (isCrash && !UICamera.isOverUI && WeaponManager.instance.takeon == true) 
            {
                if (hit.collider.tag == GameCommon.ground)
                {
                    pb = PlayerBehaviour.ExitAtt;
                    targetPoint = hit.point;
                    LookAtTarget(targetPoint);
                    ShowMoveEffect(hit.point);
                }
                else if (hit.collider.tag == GameCommon.enemy)
                {
                    pb = PlayerBehaviour.EnterAtt;
                    targetPoint = transform.position;
                    target = hit.collider.transform;
                }
            }
        }
        distance = Vector3.Distance(transform.position, targetPoint);
        if (distance > 0.3f)
        {
            LookAtTarget(targetPoint);
            cc.SimpleMove(transform.forward * speed);
            GetComponent<Animation>().CrossFade("run");
        }
        else
        {
            GetComponent<Animation>().CrossFade("att_idle");
        }
    }

    void AttackControl()
    {
        if (target != null)
        {
            attDistance = Vector3.Distance(transform.position, target.position);
            print(attDistance);
            LookAtTarget(target.position);
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCrash = Physics.Raycast(ray, out hit,200,1<<11);
                if(isCrash && !UICamera.isOverUI)
                {
                    target = null;
                    attDistance = 0;
                    timer = 0;
                    targetPoint = hit.point;
                }
            }
            if (attDistance > 1.5f)
            {
                cc.SimpleMove(transform.forward * speed);
                GetComponent<Animation>().CrossFade("run");
            }
            else
            {
                GetComponent<Animation>().CrossFade("att01");
                timer += Time.deltaTime;
                if (timer > 0.5f)
                {
                    GetComponent<Animation>().CrossFade("att_idle");
                }
                if (timer > att_rate)
                {
                    timer = 0;
                }
            }
        }
        else
        {
            pb = PlayerBehaviour.ExitAtt;
        }
    }

    void HurtControl()
    {
        GetComponent<Animation>().CrossFade("hurt");
    }

    public void SkillControl(int id = 0, PlayerBehaviour value = PlayerBehaviour.EnterAtt)
    {
        switch (id)
        {
            case 1001:
                GetComponent<Animation>().CrossFade("skill1001");
                break;
            case 1002:
                GetComponent<Animation>().CrossFade("skill1002");
                break;
            case 1003:
                GetComponent<Animation>().CrossFade("skill1003");
                break;
            case 1004:
                GetComponent<Animation>().CrossFade("skill1004");
                break;
            case 1005:
                GetComponent<Animation>().CrossFade("skill1000");
                PlayerState.instance.hp += 20;
                if (PlayerState.instance.hp > PlayerState.instance.maxHp)
                {
                    PlayerState.instance.hp = PlayerState.instance.maxHp;
                }
                break;
        }
        old_pb = value;
    }

    void AttackForEnemy()
    {
        if (target != null)
        {
            EnemyBase eb = target.GetComponent<EnemyBase>();
            float value = target.GetComponent<EnemyHealth>().Agi;
            eb.es = EnemyState.Attack;
            if (Random.value >= value)
            {
                float damage = PlayerState.instance.atk;
                //target.GetComponent<EnemyHealth>().TakeDamage(atk);
                if (Random.value > 0.7)
                {
                    eb.es = EnemyState.Hurt;
                }
                target.SendMessage("TakeDamage", damage);
            }
            else
            {
                //miss
            }
        }
    }

    void EnterAttackStatus()
    {
        pb = PlayerBehaviour.EnterAtt;
    }

    void ResetStatus()
    {
        this.pb = old_pb;   
    }

    void PlaySound(AudioClip ac)
    {
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().PlayOneShot(ac);
        }
        else
        {
            this.gameObject.AddComponent<AudioSource>();
            GetComponent<AudioSource>().PlayOneShot(ac);
        }
    }

    void PlayEffect(GameObject effect)
    {
        if (skillPoint == Vector3.zero)
        {
            GameObject.Instantiate(effect, transform.position, Quaternion.identity);
        }
        else
        {
            GameObject.Instantiate(effect, skillPoint + Vector3.up * 1f, Quaternion.identity);
            skillPoint = Vector3.zero;
        }
    }

    void ShowMoveEffect(Vector3 point)
    {
        GameObject.Instantiate(ef_move, point + Vector3.up * 0.1f, Quaternion.identity);
    }

    void Showskill01Effect()
    {
        GameObject.Instantiate(ef_skill01, skill01_point.position + Vector3.up * 1f, this.transform.rotation);
    }

    public void LookAtTarget(Vector3 point)
    {
        Vector3 target = new Vector3(point.x, transform.position.y, point.z);
        transform.LookAt(target);
    }

}

