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
    };//创建dict,做成instance


    public Dictionary<string, int> keptFishBasket = new Dictionary<string, int>()
    {
        { "qingYu", 0 },
        { "jinQiangYu", 0 },
        { "xueYu", 0 },
        { "sanWenYu", 0 }
    };//创建dict,做成instance


    public void IncreaseDictionaryValue(Dictionary<string,int> dict, string key)
    {

        // 检查这个类别是否存在
        if (dict.ContainsKey(key))
        {
            dict[key]++;
        }
    }


    public void DecreaseDictionaryValue(Dictionary<string, int> dict, string key)
    {
        // 检查这个类别是否存在
        if (dict.ContainsKey(key))
        {
            //Debug.Log("Ye");
            dict[key]--;
        }
    }


    public void ClearBasket(Dictionary<string, int> dict)//篮子清空
    {
        List<string> keys = new List<string>(dict.Keys); //新建一个list存放我的所有key

        foreach (string key in keys)//使用foreach读取这个list里的内容
        {
            currentFishBasket[key] = 0;
        }

    }
    public void CloseBasket()//关闭鱼篓
    {
        ClearBasket(currentFishBasket);

        fishBasketCount.ClearCount();

        GameObject[] currentFishModel = GameObject.FindGameObjectsWithTag("FishModel");//根据tag找到当前场面上所有的鱼模型-返回的是一个array[]
        foreach (GameObject model in currentFishModel) //删除当前场上所有的鱼模型
        {
            Destroy(model);
        }
    }
}
    
