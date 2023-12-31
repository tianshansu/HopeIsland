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
    public FishBasket fishBasket;

    public Vector3 size;

    public SpawnFishToFloor spawnFish;
    private void Start()
    {
        int num = 0;
        text.text = num.ToString();
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = new Color(1, 0, 0, 0.5f);
        Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.6f, gameObject.transform.position.z);
        Gizmos.DrawCube(pos, size);//��������λ�û�һ���Զ���ķ���
    }

    private void OnEnable()//ÿ�δ���¨����ʱ���ָ�Ŀǰ��¨����㣨�ӱ�����dict��¨�����ɶ�Ӧ�㣩
    {
        spawnFish.SpawnFish2(spawnFish.qingYu, fishBasket.keptFishBasket["qingYu"],gameObject.transform.position,size);
        spawnFish.SpawnFish2(spawnFish.sanWenYu, fishBasket.keptFishBasket["sanWenYu"], gameObject.transform.position, size);
        spawnFish.SpawnFish2(spawnFish.jinQiangYu, fishBasket.keptFishBasket["jinQiangYu"], gameObject.transform.position, size);
        spawnFish.SpawnFish2(spawnFish.xueYu, fishBasket.keptFishBasket["xueYu"], gameObject.transform.position, size);//���ɵ�ʱ���Ĭ�Ͻ���triggerEnter���Ӷ������������һ���㣬������Ҫ��ÿ������֮���������
        //Debug.Log("EnableqingYu"+fishBasket.keptFishBasket["qingYu"]);
        //Debug.Log("EnablesanWenYu" + fishBasket.keptFishBasket["sanWenYu"]);
        //Debug.Log("EnablejinQiangYu" + fishBasket.keptFishBasket["jinQiangYu"]);
        //Debug.Log("EnablexueYu" + fishBasket.keptFishBasket["xueYu"]);
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
                //Debug.Log(other.gameObject.name);
                fishBasket.IncreaseDictionaryValue(fishBasket.keptFishBasket, other.gameObject.name);//���Ž���¨������¼��keptFishBasket��
            }
            else
            {
                textFull.gameObject.SetActive(true);
                other.gameObject.GetComponent<FishIntoBasket>().ResetFishPos();
                totalFishOccupy += fishOccupy; //ע����Ҫ��int�����������ֵ
                text.text = totalFishOccupy.ToString(); //�ٽ���ֵToString
            }

            //PrintDictionary(fishBasket.keptFishBasket);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        int fishOccupy = other.gameObject.GetComponent<FishIntoBasket>().fishOccupies;

        totalFishOccupy -= fishOccupy; //ע����Ҫ��int�����������ֵ
        text.text = totalFishOccupy.ToString(); //�ٽ���ֵToString
        
        if(other.gameObject!= null)
        {
            fishBasket.DecreaseDictionaryValue(fishBasket.keptFishBasket, other.gameObject.name);//���ó���¨������¼��keptFishBasket��
            //Debug.Log("decreased");
        }
        
        //Debug.Log("qingYu" + fishBasket.keptFishBasket["qingYu"]);
        //Debug.Log("sanWenYu" + fishBasket.keptFishBasket["sanWenYu"]);
        //Debug.Log("jinQiangYu" + fishBasket.keptFishBasket["jinQiangYu"]);
        //Debug.Log("xueYu" + fishBasket.keptFishBasket["xueYu"]);

    }

  public void ClearCount()
    {
        totalFishOccupy =0; //ע����Ҫ��int�����������ֵ
        text.text = totalFishOccupy.ToString(); //�ٽ���ֵToString
    }


}
