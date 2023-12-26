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


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "FishModel")
        {
            int fishOccupy = other.gameObject.GetComponent<FishIntoBasket>().fishOccupies;

            if (totalFishOccupy + fishOccupy <= 10)
            {
                totalFishOccupy += fishOccupy; //ע����Ҫ��int�����������ֵ
                text.text = totalFishOccupy.ToString(); //�ٽ���ֵToString
            }
            else
            {
                textFull.gameObject.SetActive(true);
                other.gameObject.GetComponent<FishIntoBasket>().ResetFishPos();
            }



        }
    }
    private void OnTriggerExit(Collider other)
    {
        int fishOccupy = other.gameObject.GetComponent<FishIntoBasket>().fishOccupies;

        totalFishOccupy -= fishOccupy; //ע����Ҫ��int�����������ֵ
        text.text = totalFishOccupy.ToString(); //�ٽ���ֵToString
      
    }




}
