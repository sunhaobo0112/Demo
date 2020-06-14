using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeArea : MonoBehaviour
{
    private EnemyPatrol ep;

    private void Start()
    {
        ep = transform.parent.GetComponent<EnemyPatrol>();
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
