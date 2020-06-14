using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillArea : MonoBehaviour
{
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 20);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == GameCommon.enemy)
        {
            other.SendMessage("TakeDamage", 500);
            //Destroy(this.gameObject);
        }
    }
}

