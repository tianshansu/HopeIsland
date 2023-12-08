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
        RectTransform imgRect=fish.GetComponent<RectTransform>();//获取当前鱼的图片
        UI_Fish fishUI=fish.GetComponent<UI_Fish>();//获取当前鱼的script组件，用于获取所占的格子数

        Image fishImg = ResizeFishImg(fishUI, imgRect);//调用下面方法来返回一个缩放之后的图片


        for(int i=0;i<number; i++)//根据篮子里有的鱼数量，生成对应数量的鱼
        {

            Image instantiatedObject = Instantiate(fishImg, gameObject.transform);//生成鱼
            instantiatedObject.transform.localPosition = new Vector3(0f, 800f, 0f);//生成鱼的位置
        }
    }


    public Image ResizeFishImg(UI_Fish fish, RectTransform trans)
    {
        int fishType = fish.fishSizeType;
        Image image=fish.gameObject.GetComponent<Image>();

        switch (fishType)
        {
            case 0://当鱼占1x1格时
                float ratio= image.sprite.bounds.size.x / image.sprite.bounds.size.y;
                float newHeight = grid.cellSizeA / ratio;

                trans.sizeDelta = new Vector2(grid.cellSizeA,newHeight);
                return image;
                
            default:
                return image;
        }
    }

}
