using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class Backpack
{
    private List<BackpackItem> items = new List<BackpackItem>();

    public void AddItem(BackpackItem item)//�������ķ���
    {
        if(items.Contains(item))
        {
            item.quantity+=1;//������item�Ѿ����ڣ���ֱ��quantity+1
        }
        else
        {
            items.Add(item);//��������ڣ��ͽ����item��ӵ�list��
        }
       
    }

    public void RemoveItem(BackpackItem item)//�Ƴ�����ķ���
    {
        if (items.Contains(item))
        {
            item.quantity -= 1;//������item�Ѿ����ڣ���ֱ��quantity-1
        }
        else
        {
            items.Remove(item);//��������ڣ��ͽ����item����
        }
    }

    public List<BackpackItem> GetItemsByType(ItemType type)//ʹ�����������ȡĳһ������������list-����display��������Ľ���
    {
        // Return a list of items filtered by the specified type
        return items.Where(item => item.itemType == type).ToList();
    }

}
