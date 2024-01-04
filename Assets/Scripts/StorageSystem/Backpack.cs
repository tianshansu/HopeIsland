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

    public void AddItem(BackpackItem item)//添加物体的方法
    {
        if(items.Contains(item))
        {
            item.quantity+=1;//如果这个item已经存在，就直接quantity+1
        }
        else
        {
            items.Add(item);//如果不存在，就将这个item添加到list里
        }
       
    }

    public void RemoveItem(BackpackItem item)//移除物体的方法
    {
        if (items.Contains(item))
        {
            item.quantity -= 1;//如果这个item已经存在，就直接quantity-1
        }
        else
        {
            items.Remove(item);//如果不存在，就将这个item移走
        }
    }

    public List<BackpackItem> GetItemsByType(ItemType type)//使用这个方法获取某一类的所有物体的list-用于display三类物体的界面
    {
        // Return a list of items filtered by the specified type
        return items.Where(item => item.itemType == type).ToList();
    }

}
