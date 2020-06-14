using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSkill1003 : MonoBehaviour
{
    public Transform player;
    public float bufftimer = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(GameCommon.player).transform;
        transform.position = player.position;
        PlayerState ps = PlayerState.instance;
        ps.Skill1003Start();      
    }
    void Update()
    {
        bufftimer += Time.deltaTime;
        transform.position = player.position;
        PlayerState ps = PlayerState.instance;
        if (bufftimer >= 9.9f)
        {
            ps.Skill1003End();
            bufftimer = 0;
            Destroy(this.gameObject);
        }
    }
}
