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





    //public void ClearBasket()//�������
    //{
    //    currentFishBasket.Clear();
    //}

    
}
