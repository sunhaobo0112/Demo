using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipAndStatus : MonoBehaviour
{
    public static EquipAndStatus instance { get; private set; }

    public UISprite playerSprite;
    public UILabel nameLabel;
    public UILabel levelLabel;
    public UISlider hpSlider;
    public UISlider mpSlider;

    public UISlider expSlider;
    public UILabel expLabel;

    public UILabel atkLabel;
    public UILabel strLabel;
    public UILabel defLabel;
    public UILabel agiLabel;
    public UILabel critLabel;

    public MyEquipItem[] equipLsit;
    

    private void Awake()
    {
        instance = this;
        playerSprite = transform.Find("PlayerInfoContainer/Sprite/PlayerSprite").GetComponent<UISprite>();
        nameLabel = transform.Find("PlayerInfoContainer/Sprite/NameLabel").GetComponent<UILabel>();
        levelLabel = transform.Find("PlayerInfoContainer/Sprite/LevelBG/Label").GetComponent<UILabel>();
        hpSlider = transform.Find("PlayerInfoContainer/Sprite/HPSprite").GetComponent<UISlider>();
        mpSlider = transform.Find("PlayerInfoContainer/Sprite/MPSprite").GetComponent<UISlider>();

        expSlider = transform.Find("ExpSprite").GetComponent<UISlider>();
        expLabel = transform.Find("ExpSprite/ExpLabel").GetComponent<UILabel>();
        atkLabel = transform.Find("Property/atkLabel").GetComponent<UILabel>();
        strLabel = transform.Find("Property/strLabel").GetComponent<UILabel>();
        defLabel = transform.Find("Property/defLabel").GetComponent<UILabel>();
        agiLabel = transform.Find("Property/agiLabel").GetComponent<UILabel>();
        critLabel = transform.Find("Property/critLabel").GetComponent<UILabel>();


    }


    void Start()
    {

        UpdateData();
        PlayerState.instance.RegisterEvent((int)GameCommon.PanelType.equip, UpdateData);
        ClosePanel();
    }

    void UpdateData()
    {
        PlayerState ps = PlayerState.instance;
        playerSprite.spriteName = ps.playerIcon;
        nameLabel.text = ps.playerName;
        levelLabel.text = "Lv." + ps.level + "";
        hpSlider.value = ps.hp / ps.maxHp;
        mpSlider.value = ps.mp / ps.maxMp;
        expLabel.text = ps.exp + "/" + ps.maxExp;
        expSlider.value = ps.exp / ps.maxExp;
        atkLabel.text = ps.atk + "";
        strLabel.text = ps.str + "";
        defLabel.text = ps.def + "";
        agiLabel.text = (int)(ps.agi * 100) + "%";
        critLabel.text =(int)(ps.crit * 100) + "%";

    }

    public void ClosePanel()
    {
        this.transform.gameObject.SetActive(false);
    }

    public void ShowPanel()
    {
        this.transform.gameObject.SetActive(true);
    }

    public void SetEquipUI(DressType dt,int id)
    {
        foreach(MyEquipItem et in equipLsit)
        {
            if (et.dresstype == dt)
            {
                if (et.id != 0)
                {
                    InventoryList._instance.FillInBag(et.id, 1);
                    PlayerState.instance.Takeoff(et.it.plusMaxHP, et.it.plusMaxMP, et.it.plusStr, et.it.plusDef, et.it.plusAgi, et.it.plusCrit);
                }
                et.SetEquipItemUI(id);
            }
        }
    }
}