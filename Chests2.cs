using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests2 : MonoBehaviour
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
        InventoryList._instance.FillInBag(1006, 3);
        InventoryList._instance.FillInBag(1005, 3);
        InventoryList._instance.FillInBag(2003, 1);
        InventoryList._instance.FillInBag(2030, 1);
        //Inventory it = ObjectsInfoList._instance.ReadObjectInfo(id);
        MessageBox._instance.ShowMessageBox("焼き鶏、玉子、防具:清阳太昭袍、アクセサリー:疾風吊牌を入手した。", TipsCode.pickup);
    }
}
