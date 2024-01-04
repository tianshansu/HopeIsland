using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>

[System.Serializable]//这个类可以被序列化,告诉系统这个类的实例可以转换为bite并存储
public class BackpackItem
{
    public ItemType itemType;//类别
    public string itemName;//名字
    public Sprite itemIcon;//图标
    public int quantity;//数量

    // Constructor
    public BackpackItem(ItemType itemType, string itemName, Sprite itemIcon, int quantity)//使用constructor来定义物品
    {
        this.itemType = itemType;
        this.itemName = itemName;
        this.itemIcon = itemIcon;
        this.quantity = quantity;
    }
}
