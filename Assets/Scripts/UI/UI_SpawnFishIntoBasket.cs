using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

///<summary>
///
///</summary>

public class UI_SpawnFishIntoBasket : MonoBehaviour
{
    public FishBasket currentFishCollected;

    public GameObject qingYu;
    public GameObject jinQiangYu;
    public GameObject sanWenYu;
    public GameObject xueYu;

    public UI_CabinGridGenerate grid;



    private void Start()
    {
        SpawnFish(qingYu, currentFishCollected.currentFishBasket["qingYu"]);

    }

    public void SpawnFish(GameObject fish, int number)
    {
        RectTransform imgRect=fish.GetComponent<RectTransform>();//��ȡ��ǰ���ͼƬ
        UI_Fish fishUI=fish.GetComponent<UI_Fish>();//��ȡ��ǰ���script��������ڻ�ȡ��ռ�ĸ�����

        Image fishImg = ResizeFishImg(fishUI, imgRect);//�������淽��������һ������֮���ͼƬ


        for(int i=0;i<number; i++)//�����������е������������ɶ�Ӧ��������
        {

            Image instantiatedObject = Instantiate(fishImg, gameObject.transform);//������
            instantiatedObject.transform.localPosition = new Vector3(0f, 800f, 0f);//�������λ��
        }
    }


    public Image ResizeFishImg(UI_Fish fish, RectTransform trans)
    {
        int fishType = fish.fishSizeType;
        Image image=fish.gameObject.GetComponent<Image>();

        switch (fishType)
        {
            case 0://����ռ1x1��ʱ
                float ratio= image.sprite.bounds.size.x / image.sprite.bounds.size.y;
                float newHeight = grid.cellSizeA / ratio;

                trans.sizeDelta = new Vector2(grid.cellSizeA,newHeight);
                return image;
                
            default:
                return image;
        }
    }

}
