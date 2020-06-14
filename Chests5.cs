using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests5 : MonoBehaviour
{
    private GameObject Cube;
    private bool isNear;
    private bool isOpen = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GameCommon.player)
        {
            isNear = true;

        }
    }

    private void Update()
    {
        if (isNear)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOpen == false) 
            {
                GetComponent<Animation>().Play("Open");
                isOpen = true;
                InfoCube2.instance.OpenNewRoad();
                BGM.instance.ChangeBGM();
                GetInventory();
            }
        }
    }

    void GetInventory()
    {
        InventoryList._instance.FillInBag(1008, 3);
        InventoryList._instance.FillInBag(2039, 1);
        InventoryList._instance.FillInBag(4021, 1);
        MessageBox._instance.ShowMessageBox("龍胆草、アクセサリー:青玉赤爪、宝剣:慑天を入手した。", TipsCode.pickup);
    }
}
