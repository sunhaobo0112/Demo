using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList : MonoBehaviour
{
    public static InventoryList _instance { get; private set; }
    public InventoryGrid[] itemList;

    public UIButton closeBtn;
    public UILabel coinLabel;
    public UILabel desLabel;
    public UIButton sellBtn;
   
    public InventoryGrid clickItem;

    public Dictionary<int, InventoryGrid> itemDic = new Dictionary<int, InventoryGrid>();

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        ClosePannel();
    }

    private void Update()
    {
        #region get random equip or item
        if (Input.GetKeyDown(KeyCode.Z))
        {
            FillInBag(Random.Range(1001, 1011), 1);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            FillInBag(Random.Range(2001, 2007), 1);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            FillInBag(Random.Range(2008, 2014), 1);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            FillInBag(Random.Range(2028, 2036), 1);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            FillInBag(Random.Range(2037, 2040), 1);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            FillInBag(Random.Range(4002, 4017), 1);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            FillInBag(Random.Range(4021, 4022), 1);
        }
        #endregion

        SetSellBtnState();
    }

    //get items to knap
    public void FillInBag(int id, int num)
    {
        InventoryGrid temp = null;
        foreach (InventoryGrid ig in itemList)
        {
            //same item?
            if (ig.ID == id)
            {
                temp = ig;
            }
        }
        if (temp != null)
        {
            temp.SetUI(id, num);
        }
        else
        {
            foreach (InventoryGrid ig in itemList)
            {
                if (ig.ID == 0)
                {
                    temp = ig;
                    break;
                }
            }
            if (temp != null)
            {
                temp.SetUI(id, num);
            }
            else
            {
                MessageBox._instance.ShowMessageBox("アイテムの所持上限を超えています。", TipsCode.wrong);
            }
        }
    }

    //Remove item from knap
    public void RemoveItem(InventoryGrid ig, int num)
    {
        ig.count -= num;
        if (ig.count <= 0)
        {
            ig.Clear();
        }
        else if (ig.count == 1)
        {
            ig.countLabel.text = "";
        }
        else
        {
            ig.countLabel.text = ig.count.ToString();
        }
    }

    //Sell items from kanp
    public void SellItem()
    {
        float price = clickItem.it.sellPrice * clickItem.count;
        int value = int.Parse(coinLabel.text);
        coinLabel.text = (value + price).ToString();
        //clear grid and info
        clickItem.count = 0;
        clickItem.Clear();
        desLabel.text = "";
        clickItem = null;
    }

    //close pannel
    public void ClosePannel()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
    public void ShowPannel()
    {
        this.transform.parent.gameObject.SetActive(true);
    }

    //整理knap
    public void Settel()
    {
        //find all of objects in kanp
        foreach(InventoryGrid ig in itemList)
        {
            if (ig.ID != 0)
            {
                itemDic.Add(ig.ID, ig);
                ig.Clear();
            }
        }
        foreach(int i in itemDic.Keys)
        {
            int id = i;
            int count = itemDic[i].count;
            itemDic[i].count = 0;
            FillInBag(id,count);
        }
        itemDic.Clear();
    }

    //sell button config
    void SetSellBtnState()
    {
        if (clickItem == null)
        {
            sellBtn.enabled = false;
            sellBtn.SetState(UIButtonColor.State.Disabled,false);
        }
        else
        {
            sellBtn.enabled = true;
        }
    }
}
