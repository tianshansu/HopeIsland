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

        Debug.Log("青鱼"+fishbasket.currentFishBasket["qingYu"]);
        Debug.Log("三文鱼" + fishbasket.currentFishBasket["sanWenYu"]);
        Debug.Log("鳕鱼" + fishbasket.currentFishBasket["xueYu"]);
        Debug.Log("金枪鱼" + fishbasket.currentFishBasket["jinQiangYu"]);



    }
    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = new Color(1, 0, 0, 0.5f);
        Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.5f, gameObject.transform.position.z);
        Gizmos.DrawCube(pos, size);//根据桌子位置画一个自定义的方块
    }

    public void SpawnFish(GameObject fish, int number)
    {
        FishIntoBasket fishScript = fish.GetComponent<FishIntoBasket>();

        GameObject fishMod = ResizeFish(fishScript);//调用下面方法来返回一个缩放之后的模型


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
        int fishType = fish.fishOccupies;


        switch (fishType)
        {
            case 1://当鱼占1格时
                float originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//获取当前鱼模型的宽度
                float basketWidth = basket.gameObject.GetComponent<Renderer>().bounds.size.x;//获取鱼篓1的宽度
                float ratio = basketWidth / originalWidth;//获取需要放大的比例

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio*0.5f, fish.gameObject.transform.localScale.y * ratio * 0.5f, fish.gameObject.transform.localScale.z * ratio * 0.5f);
                return fish.gameObject;

            case 2://当鱼占2格时
                originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//获取当前鱼模型的宽度
                basketWidth = basket.gameObject.GetComponent<Renderer>().bounds.size.x;//获取鱼篓2的宽度
                ratio = basketWidth / originalWidth;//获取需要放大的比例

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio * 0.8f, fish.gameObject.transform.localScale.y * ratio * 0.8f, fish.gameObject.transform.localScale.z * ratio * 0.8f);
                return fish.gameObject;

            case 3://当鱼占3格时
                originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//获取当前鱼模型的宽度
                basketWidth = basket.gameObject.GetComponent<Renderer>().bounds.size.x;//获取鱼篓3的宽度
                ratio = basketWidth / originalWidth;//获取需要放大的比例

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio, fish.gameObject.transform.localScale.y * ratio, fish.gameObject.transform.localScale.z * ratio);
                return fish.gameObject;

            case 4://当鱼占4格时
                originalWidth = fish.gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;//获取当前鱼模型的宽度
                basketWidth = basket.gameObject.GetComponent<Renderer>().bounds.size.x;//获取鱼篓4的宽度
                ratio = basketWidth / originalWidth;//获取需要放大的比例

                fish.gameObject.transform.localScale = new Vector3(fish.gameObject.transform.localScale.x * ratio * 1.2f, fish.gameObject.transform.localScale.y * ratio * 1.2f, fish.gameObject.transform.localScale.z * ratio * 1.2f);
                return fish.gameObject;

            default:
                return fish.gameObject;
                
        }
    }
}
