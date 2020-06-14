using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillArea04 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == GameCommon.enemy)
        {
            other.SendMessage("TakeDamage", 2000);
            //Destroy(this.gameObject);
        }
    }
}

