using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;
using System.IO;

public class SkillInfoList : MonoBehaviour
{
    public static SkillInfoList instance;

    public static SkillInfoList Instance
    {
        get
        {
            return SkillInfoList.instance;
        }

    }

    private Dictionary<int, Skill> skillDic = new Dictionary<int, Skill>();
    private XmlDocument xml = new XmlDocument();
    private string path;

    void Awake()
    {
        instance = this;

        //path = Application.dataPath + "/Script/UI/skillInfoList.xml";
        //xml.Load(path);

        TextAsset textAsset = (TextAsset)Resources.Load("SkillInfoList", typeof(TextAsset));
        xml.LoadXml(textAsset.text);


        ReadSkillInfo();
    }


    void ReadSkillInfo()
    {
        XmlNode xn = xml.FirstChild;
        XmlNodeList nodeLsit = xn.ChildNodes;
        foreach (XmlNode xln in nodeLsit)
        {
            Skill sk = new Skill();
            XmlNodeList temp = xln.ChildNodes;
            sk.id = int.Parse(temp[0].InnerText);
            sk._name = temp[1].InnerText;
            sk.icon_name = temp[2].InnerText;
            sk.people = temp[3].InnerText;

            switch (temp[4].InnerText)
            {
                case "output":
                    sk.useType = UseType.output;
                    sk.atk = float.Parse(temp[5].InnerText);
                    sk.des = temp[6].InnerText;
                    sk.level = int.Parse(temp[7].InnerText);
                    sk.coldtime = float.Parse(temp[8].InnerText);
                    sk.costMP = float.Parse(temp[9].InnerText);
                    break;
                case "buff":
                    sk.useType = UseType.buff;
                    sk.str = float.Parse(temp[5].InnerText);
                    sk.def = float.Parse(temp[6].InnerText);
                    sk.plusMaxHP = float.Parse(temp[7].InnerText);
                    sk.plusMaxMP = float.Parse(temp[8].InnerText);
                    sk.crit = float.Parse(temp[9].InnerText);
                    sk.agi = float.Parse(temp[10].InnerText);
                    sk.recovery = float.Parse(temp[11].InnerText);
                    sk.des = temp[12].InnerText;
                    sk.level = int.Parse(temp[13].InnerText);
                    sk.coldtime = float.Parse(temp[14].InnerText);
                    sk.costMP = float.Parse(temp[15].InnerText);

                    break;
                case "other":
                    sk.recovery = float.Parse(temp[5].InnerText);
                    sk.des = temp[6].InnerText;
                    sk.level = int.Parse(temp[7].InnerText);
                    sk.coldtime = float.Parse(temp[8].InnerText);
                    sk.costMP = float.Parse(temp[9].InnerText);
                    break;


            }

            skillDic.Add(sk.id, sk);

        }

    }


    public Skill GetSkillInfo(int id)
    {
        Skill sk = null;
        skillDic.TryGetValue(id, out sk);
        return sk;

    }


}
 