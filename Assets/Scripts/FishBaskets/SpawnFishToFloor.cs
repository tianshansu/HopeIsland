using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.PlayerSettings;


///<summary>
///
///</summary>

public class SpawnFishToFloor : MonoBehaviour
{
    //public FishBasket currentFishCollected;

    public GameObject qingYu;
    public GameObject jinQiangYu;
    public GameObject sanWenYu;
    public GameObject xueYu;

    public GameObject basket;

    public Vector3 size;

    public FishBasket fishbasket;

    private void Start()
    {
        SpawnFish(qingYu, fishbasket.currentFishBasket["qingYu"]);
        SpawnFish(jinQiangYu, fishbasket.currentFishBasket["jinQiangYu"]);
        SpawnFish(xueYu, fishbasket.currentFishBasket["xueYu"]);
        SpawnFish(sanWenYu, fishbasket.currentFishBasket["sanWenYu"]);

        Debug.Log("����"+fishbasket.currentFishBasket["qingYu"]);
        Debug.Log("������" + fishbasket.currentFishBasket["sanWenYu"]);
        Debug.Log("����" + fishbasket.currentFishBasket["xueYu"]);
        Debug.Log("��ǹ��" + fishbasket.currentFishBasket["jinQiangYu"]);



    }
    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = new Color(1, 0, 0, 0.5f);
        Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.5f, gameObject.transform.position.z);
        Gizmos.DrawCube(pos, size);//��������λ�û�һ���Զ���ķ���
    }

    public void SpawnFish(GameObject fish, int number)
    {
        FishIntoBasket fishScript = fish.GetComponent<FishIntoBasket>();

        GameObject fishMod = ResizeFish(fishScript);//�������淽��������һ������֮���ģ��


        for (int i = 0; i < number; i++)//�����������е������������ɶ�Ӧ��������
        {
            Vector3 pos = gameObject.transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.5f, Random.Range(-size.z / 2, size.z / 2));

            Quaternion rotation = Quaternion.Euler(90, 0, 0);
            GameObject instantiatedObject = Instantiate(fishMod,pos, rotation);//������
            //instantiatedObject.transform.localPosition = new Vector3(0f, 5f, 0f);//�������λ��
        }
    }


    public GameObject ResizeFish(FishIntoBasket fish)
    {
        int fishType = fish.fishOccupies;


        switch (fishType)
        {
            case 1://����ռ1��ʱ
                float originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//��ȡ��ǰ��ģ�͵Ŀ��
                float basketWidth = basket.gameObject.GetComponent<Renderer>().bounds.size.x;//��ȡ��¨1�Ŀ��
                float ratio = basketWidth / originalWidth;//��ȡ��Ҫ�Ŵ�ı���

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio*0.5f, fish.gameObject.transform.localScale.y * ratio * 0.5f, fish.gameObject.transform.localScale.z * ratio * 0.5f);
                return fish.gameObject;

            case 2://����ռ2��ʱ
                originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//��ȡ��ǰ��ģ�͵Ŀ��
                basketWidth = basket.gameObject.GetComponent<Renderer>().bounds.size.x;//��ȡ��¨2�Ŀ��
                ratio = basketWidth / originalWidth;//��ȡ��Ҫ�Ŵ�ı���

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio * 0.8f, fish.gameObject.transform.localScale.y * ratio * 0.8f, fish.gameObject.transform.localScale.z * ratio * 0.8f);
                return fish.gameObject;

            case 3://����ռ3��ʱ
                originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//��ȡ��ǰ��ģ�͵Ŀ��
                basketWidth = basket.gameObject.GetComponent<Renderer>().bounds.size.x;//��ȡ��¨3�Ŀ��
                ratio = basketWidth / originalWidth;//��ȡ��Ҫ�Ŵ�ı���

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio, fish.gameObject.transform.localScale.y * ratio, fish.gameObject.transform.localScale.z * ratio);
                return fish.gameObject;

            case 4://����ռ4��ʱ
                originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//��ȡ��ǰ��ģ�͵Ŀ��
                basketWidth = basket.gameObject.GetComponent<Renderer>().bounds.size.x;//��ȡ��¨4�Ŀ��
                ratio = basketWidth / originalWidth;//��ȡ��Ҫ�Ŵ�ı���

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio * 1.2f, fish.gameObject.transform.localScale.y * ratio * 1.2f, fish.gameObject.transform.localScale.z * ratio * 1.2f);
                return fish.gameObject;

            default:
                return fish.gameObject;
                
        }
    }
}
