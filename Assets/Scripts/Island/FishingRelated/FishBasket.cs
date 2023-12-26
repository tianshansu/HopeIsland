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
    };//����dict,����instance


    public void IncreaseDictionaryValue(string key)
    {

        // ����������Ƿ����
        if (currentFishBasket.ContainsKey(key))
        {
            // Increase the value associated with the key
            currentFishBasket[key]++;
        }
    }


    public void DecreaseDictionaryValue(string key)
    {
        // ����������Ƿ����
        if (currentFishBasket.ContainsKey(key))
        {
            // Increase the value associated with the key
            currentFishBasket[key]--;
        }
    }



    //public void ClearBasket()//�������
    //{
    //    currentFishBasket.Clear();
    //}


}
