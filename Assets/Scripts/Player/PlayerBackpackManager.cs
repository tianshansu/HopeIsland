using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>

public class PlayerBackpackManager : MonoBehaviour
{
    public PlayerBackpack playerBackPack;
    public FishBasket fishBasket;
    public List<BackpackItem> fishItems;

    public void TransferFishToBackpack()
    {
        foreach (KeyValuePair<string, int> fishEntry in fishBasket.keptFishBasket)//对keptFishBasket里所有的物体做遍历
        {
            string fishName = fishEntry.Key;//新建的string fishName就是dict里的key-鱼名字
            int quantity = fishEntry.Value;//新建的int就是代表鱼数量

            BackpackItem fishItem = fishItems.Find(item => item.itemName == fishName);//新建backPackItem类别的物体，找到其中和dict里鱼名称一样的物体
            //Debug.Log();
            if (fishItem != null)//如果找到这个一样名字的物体了
            {
                if(quantity> 0)//如果这条鱼大于1条，那就添加进backpack里
                {
                    //Debug.Log("fishItem found");
                    fishItem.quantity = quantity;
                    playerBackPack.AddItemToBag(fishItem);//将这个物体加进player的backpack里
                }
                
            }
        }

        //PrintAllFish();
        fishBasket.ClearBasket(fishBasket.keptFishBasket);//将所有的鱼传完之后，清空keptBasket
    }

    public void PrintAllFish()
    {
        //Debug.Log("h");
        List<BackpackItem> fish = playerBackPack.playerBackpack.GetItemsByType(ItemType.Fish);
        foreach (BackpackItem item in fish)
        {
            if (item.itemType == ItemType.Fish)
            { 
                Debug.Log("Fish Name: " + item.itemName + ", Quantity: " + item.quantity);
            }
        }
    }
}
