using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillList : MonoBehaviour
{

    private UIGrid grid;
    public GameObject skillItem;

    void Awake()
    {
        grid = GetComponentInChildren<UIGrid>();
        for (int i = 1001; i <= 1005; i++)
        {
            NGUITools.AddChild(grid.gameObject, skillItem);
            skillItem.GetComponent<SkillItem>().SetSkillInfo(i);
        }
        InventoryList._instance.FillInBag(4001,1);

    }


    void Start()
    {
        MessageBox._instance.ShowMessageBox("木剣を入手した", TipsCode.pickup);
        ClosePanel();
    }


    public void ClosePanel()
    {
        transform.parent.gameObject.SetActive(false);
    }
    public void ShowPanel()
    {
        transform.parent.gameObject.SetActive(true);
    }

}
