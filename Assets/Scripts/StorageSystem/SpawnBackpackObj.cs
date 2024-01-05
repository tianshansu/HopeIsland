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
                List<BackpackItem> fishList = playerBackPack.playerBackpack.GetItemsByType(ItemType.Fish);//��ȡ���б����е���
                foreach(BackpackItem fish in fishList)//�������������е���
                {
                    GameObject emptyGrid = FindEmptyGrid();//�ҵ���һ���ո���
                    emptyGrid.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = fish.itemIcon;//����ǰ����������icon�滻��ʾ
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
        //�����ǰû�п�grid��˵��������������ʾtext����
        return null;
    }
}
