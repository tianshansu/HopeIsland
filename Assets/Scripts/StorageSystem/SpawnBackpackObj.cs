using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    ///<summary>
    ///
    ///</summary>

public class SpawnBackpackObj : MonoBehaviour
{
    public PlayerBackpack playerBackPack;
    public SingleGrid grid;
    public ItemType type;
    

    private void OnEnable()
    {
        switch (type)
        {
            case ItemType.Fish:
                List<BackpackItem> fishList = playerBackPack.playerBackpack.GetItemsByType(ItemType.Fish);//获取所有背包中的鱼
                foreach(BackpackItem fish in fishList)//遍历背包里所有的鱼
                {
                    GameObject emptyGrid = FindEmptyGrid();//找到下一个空格子
                    emptyGrid.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = fish.itemIcon;//将当前背包里的鱼的icon替换显示
                    string quantitySt = emptyGrid.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text;
                }

                break;
        }
    }


    private GameObject FindEmptyGrid()
    {
        for(int i=0;i<gameObject.transform.childCount;i++)
        {
            SingleGrid currentGrid = gameObject.transform.GetChild(i).gameObject.GetComponent<SingleGrid>();
            if (currentGrid.hasBeenChanged == false)
            {
                return currentGrid.gameObject;
            }
        }
        //如果当前没有空grid，说明背包已满，显示text已满
        return null;
    }
}
