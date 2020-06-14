using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCommon
{
    public enum PanelType : int
    {
        playerinfo=1,
        equip
    }
    public delegate void InfoChangeEvent();

    //public static bool isSpwan = false;

    public const string shortCut = "ShortCut";
    public const string player = "Player";
    public const string ground = "ground";
    public const string enemy = "enemy";

    /*public const string panel_equip = "Panel_Equip";
    public const string panel_knap = "Panel_Knap";
    public const string panel_task = "Panel_Task";
    public const string panel_message = "Panel_Message";
    public const string panel_skill = "Panel_Skill";*/

    public MyAnimationName my_Anim_Name = new MyAnimationName();
    public class MyAnimationName
    {
        public string idle = "idle";
        public string run = "run";
        public string dead = "dead";
        public string hurt = "hurt";
        public string walk = "walk";
        public string att01 = "att01";
        public string att02 = "att02";
        public string att_idle = "att_idle";

    }
    public static List<Transform> GetChildList(Transform parent)
    {

        List<Transform> list = new List<Transform>();

        for (int i = 0; i < parent.childCount; ++i)
        {
            Transform t = parent.GetChild(i);
            list.Add(t);
        }
        return list;
    }



}