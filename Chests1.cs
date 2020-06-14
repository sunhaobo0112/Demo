using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests1 : MonoBehaviour
{

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
                GetInventory();
            }
        }
    }

    void GetInventory()
    {
        InventoryList._instance.FillInBag(1004, 5);
        InventoryList._instance.FillInBag(2009, 1);
        //Inventory it = ObjectsInfoList._instance.ReadObjectInfo(id);
        MessageBox._instance.ShowMessageBox("蜂蜜、靴:冽泉屐を入手した。", TipsCode.pickup);
    }
}
