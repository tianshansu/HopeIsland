using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>

public class FishBasket : MonoBehaviour
{
    //public FishBasket Instance;
    public FishBasketCount fishBasketCount;

    public Dictionary<string, int> currentFishBasket = new Dictionary<string, int>()
    {
        { "qingYu", 0 },
        { "jinQiangYu", 0 },
        { "xueYu", 0 },
        { "sanWenYu", 0 }
    };//����dict,����instance


    public Dictionary<string, int> keptFishBasket = new Dictionary<string, int>()
    {
        { "qingYu", 0 },
        { "jinQiangYu", 0 },
        { "xueYu", 0 },
        { "sanWenYu", 0 }
    };//����dict,����instance


    public void IncreaseDictionaryValue(Dictionary<string,int> dict, string key)
    {

        // ����������Ƿ����
        if (dict.ContainsKey(key))
        {
            dict[key]++;
        }
    }


    public void DecreaseDictionaryValue(Dictionary<string, int> dict, string key)
    {
        // ����������Ƿ����
        if (dict.ContainsKey(key))
        {
            //Debug.Log("Ye");
            dict[key]--;
        }
    }


    public void ClearBasket(Dictionary<string, int> dict)//�������
    {
        List<string> keys = new List<string>(dict.Keys); //�½�һ��list����ҵ�����key

        foreach (string key in keys)//ʹ��foreach��ȡ���list�������
        {
            currentFishBasket[key] = 0;
        }

    }
    public void CloseBasket()//�ر���¨
    {
        ClearBasket(currentFishBasket);

        fishBasketCount.ClearCount();

        GameObject[] currentFishModel = GameObject.FindGameObjectsWithTag("FishModel");//����tag�ҵ���ǰ���������е���ģ��-���ص���һ��array[]
        foreach (GameObject model in currentFishModel) //ɾ����ǰ�������е���ģ��
        {
            Destroy(model);
        }
    }
}
    
