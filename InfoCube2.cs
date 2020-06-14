using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCube2 : MonoBehaviour
{

    public static InfoCube2 instance { get; private set; }

    public GameObject newroad1;
    public GameObject newroad2;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == GameCommon.player)
        {
            Destroy(this.gameObject,1);
        }
    }


    public void OpenNewRoad()
    {
        newroad1.gameObject.SetActive(true);
        newroad2.gameObject.SetActive(true);
    }
}
