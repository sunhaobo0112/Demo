using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEquipItem : MonoBehaviour
{
    public DressType dresstype;
    private UISprite itemSprite;
    private UILabel itemLabel;
    public int id;
    public Inventory it;

    public bool isInit;

    // Start is called before the first frame update
    void Start()
    {
        itemSprite = this.GetComponentInChildren<UISprite>();
        itemLabel = this.GetComponentInChildren<UILabel>();
    }

    //show equipment
    public void SetEquipItemUI(int id)
    {
        this.id = id;
        it = ObjectsInfoList._instance.ReadObjectInfo(id);
        itemSprite.spriteName = it.icon_name;
        itemLabel.text = it._name;
        PlayerState.instance.PutOn(it.plusMaxHP, it.plusMaxMP, it.plusStr, it.plusDef, it.plusAgi, it.plusCrit);
    }
    void OnClick()
    {
        if (Input.GetMouseButtonUp(1))
        {
            if (this.id != 0)
            {
                InventoryList._instance.FillInBag(id, 1);
                PlayerState.instance.Takeoff(it.plusMaxHP, it.plusMaxMP, it.plusStr, it.plusDef, it.plusAgi, it.plusCrit);
                Clear();
            }
        }

    }
    void Clear()
    {
        this.id = 0;
        it = null;
        itemSprite.spriteName = "选框";
        itemLabel.text = "";
    }

}
