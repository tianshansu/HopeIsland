using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>

public class FishBasket : MonoBehaviour
{
    //public FishBasket Instance;

    public Dictionary<string, int> currentFishBasket = new Dictionary<string, int>()
    {
        { "qingYu", 0 },
        { "jinQiangYu", 0 },
        { "xueYu", 0 },
        { "sanWenYu", 0 }
    };//创建dict,做成instance


    public void IncreaseDictionaryValue(string key)
    {

        // 检查这个类别是否存在
        if (currentFishBasket.ContainsKey(key))
        {
            // Increase the value associated with the key
            currentFishBasket[key]++;
        }
    }


    public void DecreaseDictionaryValue(string key)
    {
        // 检查这个类别是否存在
        if (currentFishBasket.ContainsKey(key))
        {
            // Increase the value associated with the key
            currentFishBasket[key]--;
        }
    }



    //public void ClearBasket()//篮子清空
    //{
    //    currentFishBasket.Clear();
    //}


}
