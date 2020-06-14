using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerinfoUI : MonoBehaviour
{
    public UISprite playerSprite;
    public UILabel nameLabel;
    public UILabel levelLabel;
    public UISlider hpSlider;
    public UISlider mpSlider;
    public UILabel hpLabel;
    public UILabel mpLabel;

    void Start()
    {
        UpdateData();
        PlayerState.instance.RegisterEvent((int)GameCommon.PanelType.playerinfo, UpdateData);
    }

    void UpdateData()
    {
        PlayerState ps = PlayerState.instance;
        playerSprite.spriteName = ps.playerIcon;
        nameLabel.text = ps.playerName;
        levelLabel.text ="Lv."+ ps.level + "";
        hpSlider.value = ps.hp / ps.maxHp;
        mpSlider.value = ps.mp / ps.maxMp;
        hpLabel.text = ps.hp + "/" + ps.maxHp;
        mpLabel.text = ps.mp + "/" + ps.maxMp;
    }

   
}
