using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{


    public int ID;
    public UISprite inventoryBG;
    public UISprite item;
    private UISprite mask;
    public UILabel countLabel;
    //public UISprite uiSprite;
    public int count;

    private bool isStartColding;
    public bool isUse;
    public Inventory it;

    void Awake()
    {
        inventoryBG = this.GetComponent<UISprite>();
        item = transform.Find("Inventoryitem").GetComponent<UISprite>();
        mask = transform.Find("mask").GetComponent<UISprite>();
        countLabel = transform.Find("countLabel").GetComponent<UILabel>();
    }

    private void Update()
    {
        Colding();
    }

    //cooldown
    public void Colding(float value = 0.1f)
    {
        if (isUse)
        {
            if (!isStartColding)
            {
                isStartColding = true;
                mask.fillAmount = 1;
            }
            if (isStartColding)
            {
                mask.fillAmount -= value * Time.deltaTime;
                if (mask.fillAmount < 0.01f)
                {
                    StopColding();
                }
            }
        }
    }

    //stop cooldown
    public void StopColding()
    {
        mask.fillAmount = 0;
        isStartColding = false;
        isUse = false;
    }

    //display items
    public void SetUI(int id, int num)
    {
        this.ID = id;
        it = ObjectsInfoList._instance.ReadObjectInfo(id);
        item.spriteName = it.icon_name;
        this.count += num;
        if (count > 1)
        {
            countLabel.text = this.count + "";
        }
        else
        {
            countLabel.text = "";
        }
    }

    //clear grid
    public void Clear()
    {
        this.ID = 0;
        item.spriteName = "选框";
        it = null;
        countLabel.text = "";
    }

    //click (collider) only on buttonup
    void OnClick()
    {
        if (this.ID == 0) return;
        InventoryList temp = InventoryList._instance;
        PlayerState ps = PlayerState.instance;
        if (Input.GetMouseButtonUp(0))
        {
            temp.clickItem = this;
            temp.desLabel.text = it.desc;
            //uiSprite.spriteName = "选中框";           
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (ps.level >= it.level)
            {
                switch (it.infoType)
                {
                    case InfoType.drug:
                        if (isStartColding != true)
                        {
                            PlayerState.instance.UpdateDateUp(it.plusHP, it.plusMP);
                            temp.RemoveItem(this, 1);
                            //player state update together

                            if (this.count <= 0)
                            {
                                Clear();
                                temp.desLabel.text = "";
                            }
                            else if (this.count == 1)
                            {
                                this.countLabel.text = "";
                                //cd
                                isUse = true;
                            }
                            else
                            {
                                isUse = true;
                            }
                        }
                        break;
                    case InfoType.equip:
                        if (ps.sexType != it.sexType && it.sexType != SexType.common)
                        {
                            MessageBox._instance.ShowMessageBox("装備できません", TipsCode.wrong);
                        }
                        else
                        {
                            EquipAndStatus.instance.SetEquipUI(it.dressType, ID);
                            temp.RemoveItem(this, 1);
                            //player state update together

                        }
                        break;
                    case InfoType.weapon:
                        EquipAndStatus.instance.SetEquipUI(it.dressType, ID);
                        WeaponManager.instance.ShowWeapon(it.icon_name);
                        temp.RemoveItem(this, 1);

                        break;
                }
            }
            else
            {
                MessageBox._instance.ShowMessageBox("レベルが足りない", TipsCode.wrong);
            }
        }
    }

    public void SetDragItem()
    {
        countLabel.text = "";
        inventoryBG.enabled = false;
    }

}
