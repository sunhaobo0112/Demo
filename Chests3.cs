using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests3 : MonoBehaviour
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
        InventoryList._instance.FillInBag(4003, 1);
        MessageBox._instance.ShowMessageBox("剣:生鉄剣を入手した。", TipsCode.pickup);
    }
}
