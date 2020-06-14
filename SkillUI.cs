using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : UIDragDropItem
{
    public int skillID;

    protected override void OnDragDropStart()
    {//在克隆的icon上调用的
        base.OnDragDropStart();
        transform.parent = transform.root.Find("Panel_top").transform;


    }
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if (surface != null && surface.tag == GameCommon.shortCut)
        {//当一个技能拖到了快捷方式上的时候

            surface.GetComponent<ShortCutItem>().SetSkillIcon(skillID);
        }


    }
}
