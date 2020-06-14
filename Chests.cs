using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour
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
        int id = 1003;
        int id2 = 4002;
        InventoryList._instance.FillInBag(id, 3);
        InventoryList._instance.FillInBag(id2, 1);
        Inventory it = ObjectsInfoList._instance.ReadObjectInfo(id);
        MessageBox._instance.ShowMessageBox(it._name+"、青銅剣を入手した。",TipsCode.pickup);
    }
}
