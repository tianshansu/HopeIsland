using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>

public class FishBasketCount : MonoBehaviour
{
    public Text text;
    public Text textFull;
    private int totalFishOccupy;


    private void Start()
    {
        int num = 0;
        text.text = num.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
      
        
        if(collision.gameObject.tag=="FishModel")
        {
            int fishOccupy = collision.gameObject.GetComponent<FishIntoBasket>().fishOccupies;

            if (totalFishOccupy + fishOccupy <= 10)
            {
                totalFishOccupy += fishOccupy; //ע����Ҫ��int�����������ֵ
                text.text = totalFishOccupy.ToString(); //�ٽ���ֵToString
            }
            else
            {
                textFull.gameObject.SetActive(true);
                collision.gameObject.GetComponent<FishIntoBasket>().ResetFishPos();
            }

            
          
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        int fishOccupy = collision.gameObject.GetComponent<FishIntoBasket>().fishOccupies;

        if (totalFishOccupy + fishOccupy <= 10)
        {
            totalFishOccupy -= fishOccupy; //ע����Ҫ��int�����������ֵ
            text.text = totalFishOccupy.ToString(); //�ٽ���ֵToString
        }
      
    }

}
