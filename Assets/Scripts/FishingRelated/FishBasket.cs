using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>

public class FishBasket : MonoBehaviour
{
    public Dictionary<string,int> currentFishBasket = new Dictionary<string,int>();//����dict

    private void Start()//�������ݣ�ֵ��Ϊ0
    {
        currentFishBasket.Add("qingYu", 0);
        currentFishBasket.Add("sanWenYu", 0);
        currentFishBasket.Add("jinQiangYu", 0);
        currentFishBasket.Add("xueYu", 0);
    }


    public void ClearBasket()//�������
    {
        currentFishBasket.Clear();
    }

    
}