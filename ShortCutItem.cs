using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShortCutType
{
    Skill,
    Drug,
    None
}

public class ShortCutItem : MonoBehaviour
{
    public KeyCode key;
    private UISprite itemSprite;
    private UILabel numLabel;
    private UISprite mask;
    private UISprite mask2;
    private int drugCount;
    private float coldingTime = 10;
    private List<Transform> shortCutList = new List<Transform>();

    private Inventory it;
    public ShortCutType scType = ShortCutType.None;
    private Skill sk;
    private int id;

    private bool isStartColding;
    private bool isUse;

    private PlayerController pc;

    public GameObject skillArea;//skill area picture prefab
    private GameObject sa;//save skill area effect temporarery
    bool bCheck = false;

    private void Start()
    {
        itemSprite = transform.Find("itemSprite").GetComponent<UISprite>();
        numLabel = transform.Find("numLabel").GetComponent<UILabel>();
        mask = transform.Find("mask").GetComponent<UISprite>();
        mask2 = transform.Find("mask2").GetComponent<UISprite>();
        pc = GameObject.FindGameObjectWithTag(GameCommon.player).GetComponent<PlayerController>();
    }

    private void Update()
    {
        ControlCommand();
        SkillIDCheck();
        Colding(coldingTime);
        if (this.scType == ShortCutType.Skill)
        {
            SkillIconCheck();
        }
        if (this.scType == ShortCutType.Drug)
        {
            DrugIconCheck();
        }
    }

    public void ControlCommand()
    {
        if (Input.GetKeyDown(key) && isStartColding == false)
        {
            switch (scType)
            {
                case ShortCutType.Drug:
                    if (PlayerState.instance.level >= it.level)
                    {
                        OnUseDrug();
                    }
                    else
                    {
                        MessageBox._instance.ShowMessageBox("Levelがたりない！！！", TipsCode.wrong);
                    }
                    break;
                case ShortCutType.Skill:
                    if (PlayerState.instance.level >= sk.level)
                    {
                        if (PlayerState.instance.mp - sk.costMP >= 0)
                        {
                            if (sk.id == 1004)
                            {
                                bCheck = true;
                                sa = GameObject.Instantiate(skillArea) as GameObject;
                            }
                            else
                            {
                                OnUseSkill();
                                PlayerState.instance.CostMp(sk.costMP);
                                isUse = true;
                            }
                        }
                        else
                        {
                            MessageBox._instance.ShowMessageBox("MPがたりない！！！", TipsCode.wrong);
                        }
                    }
                    else
                    {
                        MessageBox._instance.ShowMessageBox("Levelがたりない！！！", TipsCode.wrong);
                    }
                    break;
            }
        }
    }
    //set skill icon
    public void SetSkillIcon(int id)
    {
        sk = SkillInfoList.Instance.GetSkillInfo(id);
        scType = ShortCutType.Skill;
        itemSprite.spriteName = sk.icon_name;
        this.id = id;
    }
    //set drug icon
    public void SetDrugIcon(int id,int num)
    {
        it = ObjectsInfoList._instance.ReadObjectInfo(id);
        if (it != null && it.infoType != InfoType.equip && it.infoType != InfoType.weapon) 
        {
            itemSprite.spriteName = it.icon_name;
            scType = ShortCutType.Drug;
            drugCount = 0;
            drugCount += num;
            if (drugCount > 1)
            {
                numLabel.text = drugCount + "";
            }
            else
            {
                numLabel.text = "";
            }
        }
    }
    //use skill
    public void OnUseSkill()
    {
        PlayerBehaviour old_pb = pc.pb;//remenber last behaviour
        pc.pb = PlayerBehaviour.Skill;
        pc.SkillControl(sk.id, old_pb);
        //SynchronizedCooling();
    }
    //use drug
    public void OnUseDrug()
    {
        PlayerState.instance.UpdateDateUp(it.plusHP, it.plusMP);
        SynchronizedCooling();
        drugCount--;
        if (drugCount > 1)
        {
            numLabel.text = drugCount + "";
            isUse = true;
        }
        else if (drugCount == 1)
        {
            numLabel.text = "";
            isUse = true;
        }
        else
        {
            ClearUp();
        }       
    }
    //clear grid
    public void ClearUp()
    {
        numLabel.text = "";
        scType = ShortCutType.None;
        itemSprite.spriteName = "选框";
        drugCount = 0;
        it = null;

    }

    public void Clear()
    {
        numLabel.text = "";
        scType = ShortCutType.None;
        itemSprite.spriteName = "选框";
        it = null;

    }
    //Synchronized CD with knap
    public void SynchronizedCooling()
    {
        InventoryGrid[] iglist = InventoryList._instance.itemList;
        foreach (InventoryGrid temp in iglist)
        {
            if (temp.ID==this.it.id)
            {
                temp.isUse = true;
                InventoryList._instance.RemoveItem(temp, 1);
                if (temp.count <= 0)
                {
                    Clear();
                }
                break;
            }
        }
    }

    public void Colding(float timer = 10)
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
                mask.fillAmount -= (1/timer) * Time.deltaTime;
                if (mask.fillAmount < 0.01f)
                {
                    StopColding();
                }
            }
        }
    }

    public void StopColding()
    {
        mask.fillAmount = 0;
        isStartColding = false;
        isUse = false;
    }

    public void SkillIconCheck()
    {
        if (PlayerState.instance.level < sk.level)
        {
            mask2.fillAmount = 1;
        }
        else
        {
            mask2.fillAmount = 0;
        }
    }

    public void DrugIconCheck()
    {
        if (PlayerState.instance.level < it.level)
        {
            mask2.fillAmount = 1;
        }
        else
        {
            mask2.fillAmount = 0;
        }
    }

    public void SkillIDCheck()
    {
        if (bCheck && sa)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100, 1 << 11);
            pc.LookAtTarget(hit.point);
            sa.transform.position = hit.point + Vector3.up * 0.3f;
            float distance = Vector3.Distance(pc.gameObject.transform.position, hit.point);
            if (distance < 3)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pc.skillPoint = hit.point;
                    PlayerState.instance.CostMp(sk.costMP);
                    OnUseSkill();
                    isUse = true;
                    Destroy(sa);
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Destroy(sa);
                }
            }
            else
            {
                Destroy(sa);
            }
        }
    }
}
