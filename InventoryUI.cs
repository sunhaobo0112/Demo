using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : UIDragDropItem
{
    public int drugID;
    public int num;

    protected override void OnDragDropStart()
    {
        base.OnDragDropStart();
        transform.parent = transform.root.Find("Panel_top").transform;
        InventoryGrid ig = this.GetComponent<InventoryGrid>();
        ig.SetDragItem();
        num = ig.count;
        drugID = ig.ID;
    }
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if (surface != null && surface.tag == GameCommon.shortCut)
        {
            surface.GetComponent<ShortCutItem>().SetDrugIcon(drugID, num);
        }
    }
}
