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

    public GameObject[] fishBasket;

    public Vector3 size;

    private void Start()
    {
        SpawnFish(qingYu, FishBasket.currentFishBasket["qingYu"]);
        SpawnFish(jinQiangYu, FishBasket.currentFishBasket["jinQiangYu"]);
        SpawnFish(xueYu, FishBasket.currentFishBasket["xueYu"]);
        SpawnFish(sanWenYu, FishBasket.currentFishBasket["sanWenYu"]);

        //Debug.Log(FishBasket.currentFishBasket["qingYu"]);

    }
    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = new Color(1, 0, 0, 0.5f);
        Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.7f, gameObject.transform.position.z);
        Gizmos.DrawCube(pos, size);//��������λ�û�һ���Զ���ķ���
    }

    public void SpawnFish(GameObject fish, int number)
    {
        FishIntoBasket fishScript = fish.GetComponent<FishIntoBasket>();

        GameObject fishMod = ResizeFish(fishScript);//�������淽��������һ������֮���ͼƬ


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
        int fishType = fish.fishSizeType;


        switch (fishType)
        {
            case 0://����ռ1x1��ʱ
                float originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//��ȡ��ǰ��ģ�͵Ŀ���
                float basketWidth = fishBasket[0].gameObject.GetComponent<Renderer>().bounds.size.x;//��ȡ��¨1�Ŀ���
                float ratio = basketWidth / originalWidth;//��ȡ��Ҫ�Ŵ�ı���

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio, fish.gameObject.transform.localScale.y * ratio, fish.gameObject.transform.localScale.z * ratio);
                return fish.gameObject;
            
            case 1://����ռ1x2��ʱ
                originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//��ȡ��ǰ��ģ�͵Ŀ���
                basketWidth = fishBasket[1].gameObject.GetComponent<Renderer>().bounds.size.x;//��ȡ��¨2�Ŀ���
                ratio = basketWidth / originalWidth;//��ȡ��Ҫ�Ŵ�ı���

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio, fish.gameObject.transform.localScale.y * ratio, fish.gameObject.transform.localScale.z * ratio);
                return fish.gameObject;

            case 2://����ռ1x3��ʱ
                originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//��ȡ��ǰ��ģ�͵Ŀ���
                basketWidth = fishBasket[2].gameObject.GetComponent<Renderer>().bounds.size.x;//��ȡ��¨3�Ŀ���
                ratio = basketWidth / originalWidth;//��ȡ��Ҫ�Ŵ�ı���

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio, fish.gameObject.transform.localScale.y * ratio, fish.gameObject.transform.localScale.z * ratio);
                return fish.gameObject;

            case 3://����ռ2x2��ʱ
                originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//��ȡ��ǰ��ģ�͵Ŀ���
                basketWidth = fishBasket[3].gameObject.GetComponent<Renderer>().bounds.size.x;//��ȡ��¨4�Ŀ���
                ratio = basketWidth / originalWidth;//��ȡ��Ҫ�Ŵ�ı���

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio, fish.gameObject.transform.localScale.y * ratio, fish.gameObject.transform.localScale.z * ratio);
                return fish.gameObject;

            default:
                return fish.gameObject;
                
        }
    }
}