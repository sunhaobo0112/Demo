using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectsInfoList : MonoBehaviour {
    public static ObjectsInfoList _instance { get; private set; }
    public TextAsset objectinfo;
    public Dictionary<int,Inventory> objectInfoDic=new Dictionary<int,Inventory>();//all items list

    void Awake()
    {
        _instance = this;
        ReadObjectlist();
       // gameObject.AddComponent<SkillInfoList>();
    }
    

    void ReadObjectlist()
    {
        string[] strArrary = objectinfo.text.Split('\n');
       
        foreach(string str in strArrary)
        {
            string[] elemt = str.Split(',');
            Inventory it = new Inventory();
            it.id =int.Parse(elemt[0].Trim());
            it._name = elemt[1].Trim();
            it.icon_name = elemt[2].Trim();
            
            switch(elemt[3].Trim())
            {
                case "Drug":
                    it.infoType = InfoType.drug;
                    it.plusHP =float.Parse(elemt[4].Trim());
                    it.plusMP = float.Parse(elemt[5].Trim());
                    it.sellPrice = float.Parse(elemt[6].Trim());
                    it.buyPrice = float.Parse(elemt[7].Trim());
                    it.level = int.Parse(elemt[8].Trim());
                    it.desc = elemt[9].Trim();
                    break;
                case"Equip":
                    it.infoType = InfoType.equip;
                    it.plusMaxHP = float.Parse(elemt[4].Trim());
                    it.plusMaxMP = float.Parse(elemt[5].Trim());
                    it.plusStr = float.Parse(elemt[6].Trim());
                    it.plusDef = float.Parse(elemt[7].Trim());
                    it.plusAgi = float.Parse(elemt[8].Trim());
                    it.sellPrice = float.Parse(elemt[9].Trim());
                    it.buyPrice = float.Parse(elemt[10].Trim());
                    if (elemt[11].Trim() == "Man")
                    {
                        it.sexType = SexType.man;
                    }
                    else if (elemt[11].Trim() == "WoMan")
                    {
                        it.sexType = SexType.woman;
                    }
                    else
                    {
                        it.sexType = SexType.common;
                    }
                    switch(elemt[12].Trim())
                    {
                        case "Armor":
                            it.dressType = DressType.Armor;
                            break;
                        case "Shoe":
                            it.dressType = DressType.Shoe;
                            break;
                        case "Waist":
                            it.dressType = DressType.Waist;
                            break;
                        case "Neck":
                            it.dressType = DressType.Neck;
                            break;
                    }
                    it.level = int.Parse(elemt[13]);
                    it.desc = elemt[14].Trim();
                    break;
                case"Mat":
                    it.infoType = InfoType.other;
                    it.desc = elemt[4].Trim();
                    break;
                case"Weapon":
                    it.infoType = InfoType.weapon;
                    it.plusStr =float.Parse( elemt[4].Trim());
                    it.plusAgi = float.Parse(elemt[5].Trim());
                    it.plusCrit = float.Parse(elemt[6].Trim());
                    it.sellPrice = float.Parse(elemt[7].Trim());
                    it.buyPrice = float.Parse(elemt[8].Trim());
                    it.level =int.Parse(elemt[9].Trim());
                    it.desc = elemt[10].Trim();
                    break;

            }
            objectInfoDic.Add(it.id,it);
        
        }

    
    }//read info

    public Inventory ReadObjectInfo(int id)
    {
        Inventory it;
        objectInfoDic.TryGetValue(id,out it);
       
        return it;
    }//use ID to get items info
}
