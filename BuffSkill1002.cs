using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSkill1002 : MonoBehaviour
{
    public Transform player;
    public float bufftimer = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(GameCommon.player).transform;
        transform.position = player.position;
        PlayerState ps = PlayerState.instance;
        ps.Skill1002Start();
    }
    void Update()
    {
        bufftimer += Time.deltaTime;
        transform.position = player.position;
        PlayerState ps = PlayerState.instance;
        if (bufftimer >= 7.9f)
        {
            ps.Skill1002End();
            bufftimer = 0;
            Destroy(this.gameObject);
        }
    }
}
