using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance { get; private set; }
    List<Transform> weaponList = new List<Transform>();
    public bool takeon;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        weaponList = GameCommon.GetChildList(this.transform);
        foreach(Transform t in weaponList)
        {
            t.gameObject.SetActive(false);
        }
    }

    public void ShowWeapon(string str)
    {
        foreach(Transform t in weaponList)
        {
            if (str == t.gameObject.name)
            {
                t.gameObject.SetActive(true);
                takeon = true;
            }
            else
            {
                t.gameObject.SetActive(false);
            }
        }
    }
}