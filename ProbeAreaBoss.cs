using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeAreaBoss : MonoBehaviour
{
    private EnemyPatrolBoss ep;

    private void Start()
    {
        ep = transform.parent.GetComponent<EnemyPatrolBoss>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == GameCommon.player)
        {
            if (ep.es != EnemyState.Attack)
            {
                ep.es = EnemyState.Attack;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == GameCommon.player)
        {
            if (ep.es == EnemyState.Attack)
            {
                ep.es = EnemyState.Normal;
            }
        }
    }
}
