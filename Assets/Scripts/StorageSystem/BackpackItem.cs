using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>

//[System.Serializable]//�������Ա����л�,����ϵͳ������ʵ������ת��Ϊbite���洢
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class BackpackItem : ScriptableObject
{
    public ItemType itemType;//���
    public string itemName;//����
    public Sprite itemIcon;//ͼ��
    public int quantity;//����  

    // Constructor
    public BackpackItem(ItemType itemType, string itemName, Sprite itemIcon, int quantity)//ʹ��constructor��������Ʒ
    {
        this.itemType = itemType;
        this.itemName = itemName;
        this.itemIcon = itemIcon;
        this.quantity = quantity;
    }
}
