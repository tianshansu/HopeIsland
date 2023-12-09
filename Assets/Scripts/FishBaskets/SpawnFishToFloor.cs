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
        Gizmos.DrawCube(pos, size);//根据桌子位置画一个自定义的方块
    }

    public void SpawnFish(GameObject fish, int number)
    {
        FishIntoBasket fishScript = fish.GetComponent<FishIntoBasket>();

        GameObject fishMod = ResizeFish(fishScript);//调用下面方法来返回一个缩放之后的图片


        for (int i = 0; i < number; i++)//根据篮子里有的鱼数量，生成对应数量的鱼
        {
            Vector3 pos = gameObject.transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.5f, Random.Range(-size.z / 2, size.z / 2));

            Quaternion rotation = Quaternion.Euler(90, 0, 0);
            GameObject instantiatedObject = Instantiate(fishMod,pos, rotation);//生成鱼
            //instantiatedObject.transform.localPosition = new Vector3(0f, 5f, 0f);//生成鱼的位置
        }
    }


    public GameObject ResizeFish(FishIntoBasket fish)
    {
        int fishType = fish.fishSizeType;


        switch (fishType)
        {
            case 0://当鱼占1x1格时
                float originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//获取当前鱼模型的宽度
                float basketWidth = fishBasket[0].gameObject.GetComponent<Renderer>().bounds.size.x;//获取鱼篓1的宽度
                float ratio = basketWidth / originalWidth;//获取需要放大的比例

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio, fish.gameObject.transform.localScale.y * ratio, fish.gameObject.transform.localScale.z * ratio);
                return fish.gameObject;
            
            case 1://当鱼占1x2格时
                originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//获取当前鱼模型的宽度
                basketWidth = fishBasket[1].gameObject.GetComponent<Renderer>().bounds.size.x;//获取鱼篓2的宽度
                ratio = basketWidth / originalWidth;//获取需要放大的比例

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio, fish.gameObject.transform.localScale.y * ratio, fish.gameObject.transform.localScale.z * ratio);
                return fish.gameObject;

            case 2://当鱼占1x3格时
                originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//获取当前鱼模型的宽度
                basketWidth = fishBasket[2].gameObject.GetComponent<Renderer>().bounds.size.x;//获取鱼篓3的宽度
                ratio = basketWidth / originalWidth;//获取需要放大的比例

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio, fish.gameObject.transform.localScale.y * ratio, fish.gameObject.transform.localScale.z * ratio);
                return fish.gameObject;

            case 3://当鱼占2x2格时
                originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//获取当前鱼模型的宽度
                basketWidth = fishBasket[3].gameObject.GetComponent<Renderer>().bounds.size.x;//获取鱼篓4的宽度
                ratio = basketWidth / originalWidth;//获取需要放大的比例

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio, fish.gameObject.transform.localScale.y * ratio, fish.gameObject.transform.localScale.z * ratio);
                return fish.gameObject;

            default:
                return fish.gameObject;
                
        }
    }
}
