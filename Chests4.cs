﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests4 : MonoBehaviour
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
        InventoryList._instance.FillInBag(1007, 2);
        MessageBox._instance.ShowMessageBox("护心丹を入手した。", TipsCode.pickup);
    }
}
