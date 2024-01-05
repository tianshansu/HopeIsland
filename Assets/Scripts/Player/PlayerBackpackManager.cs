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
        foreach (KeyValuePair<string, int> fishEntry in fishBasket.keptFishBasket)//��keptFishBasket�����е�����������
        {
            string fishName = fishEntry.Key;//�½���string fishName����dict���key-������
            int quantity = fishEntry.Value;//�½���int���Ǵ���������

            BackpackItem fishItem = fishItems.Find(item => item.itemName == fishName);//�½�backPackItem�������壬�ҵ����к�dict��������һ��������
            //Debug.Log();
            if (fishItem != null)//����ҵ����һ�����ֵ�������
            {
                if(quantity> 0)//������������1�����Ǿ���ӽ�backpack��
                {
                    //Debug.Log("fishItem found");
                    fishItem.quantity = quantity;
                    playerBackPack.AddItemToBag(fishItem);//���������ӽ�player��backpack��
                }
                
            }
        }

        //PrintAllFish();
        fishBasket.ClearBasket(fishBasket.keptFishBasket);//�����е��㴫��֮�����keptBasket
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
