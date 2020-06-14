using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBase : MonoBehaviour
{
    public GameObject enemyPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == GameCommon.player)
        {
            EnemySpawn();
            Destroy(this.gameObject);
        }
    }
    void EnemySpawn()
    {
        List<Transform> list = GameCommon.GetChildList(transform);
        foreach(Transform t in list)
        {
            GameObject.Instantiate(enemyPrefab, t.position, Quaternion.identity);
        }
    }

}
