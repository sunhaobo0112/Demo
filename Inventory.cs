using UnityEngine;
using System.Collections;


public enum InfoType
{
    drug,
    equip,
    weapon,
    other

}
public enum SexType
{ 
    man,
    woman,
    common
}

public enum DressType
{ 
    Weapon,
    Armor,
    Neck,
    Waist,
    Shoe,
    
}

public class Inventory{
    public int id;
    public string icon_name;
    public string _name;
    public InfoType infoType;
    public float plusHP;
    public float plusMP;
    public float sellPrice;
    public float buyPrice;
    public float plusMaxHP;
    public float plusMaxMP;
    public float plusStr;
    public float plusDef;
    public float plusAgi;
    public DressType dressType;
    public SexType sexType;
    public string desc;
    public int level;
    public float plusCrit;
   
}
