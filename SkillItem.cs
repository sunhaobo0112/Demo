using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItem : MonoBehaviour
{
    private UISprite skillIcon;
    private UISprite mask;
    private UILabel skillName;
    private UILabel lockLevel;
    private UILabel describe;
    public int id;


    void Init()
    {
        skillIcon = transform.Find("SkillIcon").GetComponent<UISprite>();
        mask = transform.Find("SkillIcon/mask").GetComponent<UISprite>();
        skillName = transform.Find("skillName").GetComponent<UILabel>();
        lockLevel = transform.Find("lockLevel").GetComponent<UILabel>();
        describe = transform.Find("describe").GetComponent<UILabel>();

    }
    public void SetSkillInfo(int id)
    {
        Skill sk = SkillInfoList.Instance.GetSkillInfo(id);
        this.id = id;
        Init();
        skillIcon.spriteName = sk.icon_name;
        skillName.text = sk._name;
        describe.text = sk.des;
        lockLevel.text = sk.level + "";


        skillIcon.gameObject.GetComponent<SkillUI>().skillID = id;

    }



}

