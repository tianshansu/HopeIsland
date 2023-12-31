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

    public Vector3 tableSize;

    public FishBasket fishBasket;

    private void OnEnable()
    {
        SpawnFish(qingYu, fishBasket.currentFishBasket["qingYu"], gameObject.transform.position,tableSize);
        SpawnFish(jinQiangYu, fishBasket.currentFishBasket["jinQiangYu"], gameObject.transform.position, tableSize);
        SpawnFish(xueYu, fishBasket.currentFishBasket["xueYu"], gameObject.transform.position, tableSize);
        SpawnFish(sanWenYu, fishBasket.currentFishBasket["sanWenYu"], gameObject.transform.position, tableSize);
    }
    

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = new Color(1, 0, 0, 0.5f);
        Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.5f, gameObject.transform.position.z);
        Gizmos.DrawCube(pos, tableSize);//根据桌子位置画一个自定义的方块
    }

    public void SpawnFish2(GameObject fish, int number, Vector3 spawnPos, Vector3 size)//每次打开鱼篓界面后生成已经在鱼篓中的鱼，专门用于生成一条后减掉basket里的数值
    {
        //Debug.Log("SpawnFish2");
        Debug.Log("EnableqingYu" + fishBasket.keptFishBasket["qingYu"]);
        Debug.Log("EnablesanWenYu" + fishBasket.keptFishBasket["sanWenYu"]);
        Debug.Log("EnablejinQiangYu" + fishBasket.keptFishBasket["jinQiangYu"]);
        Debug.Log("EnablexueYu" + fishBasket.keptFishBasket["xueYu"]);


        FishIntoBasket fishScript = fish.GetComponent<FishIntoBasket>();

        GameObject fishMod = ResizeFish(fishScript);//调用下面方法来返回一个缩放之后的模型


        for (int i = 0; i < number; i++)//根据篮子里有的鱼数量，生成对应数量的鱼
        {
            //Vector3 pos = gameObject.transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.5f, Random.Range(-size.z / 2, size.z / 2));
            Vector3 newPos = GeneratePosForSpawn(spawnPos, size);
            Quaternion rotation = Quaternion.Euler(90, 0, 0);
            GameObject instantiatedFish = Instantiate(fishMod, newPos, rotation);//生成鱼

            fishBasket.DecreaseDictionaryValue(fishBasket.keptFishBasket, fish.name);//专门用于生成一条后减掉basket里的数值
            instantiatedFish.gameObject.name = fish.name;//将生成的鱼名字改为鱼名字（去掉Clone）
            instantiatedFish.gameObject.tag = "FishModel";
        }

    }

    public void SpawnFish(GameObject fish, int number, Vector3 spawnPos, Vector3 size)
    {
        FishIntoBasket fishScript = fish.GetComponent<FishIntoBasket>();

        GameObject fishMod = ResizeFish(fishScript);//调用下面方法来返回一个缩放之后的模型


        for (int i = 0; i < number; i++)//根据篮子里有的鱼数量，生成对应数量的鱼
        {
            //Vector3 pos = gameObject.transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.5f, Random.Range(-size.z / 2, size.z / 2));
            Vector3 newPos = GeneratePosForSpawn(spawnPos, size);
            Quaternion rotation = Quaternion.Euler(90, 0, 0);
            GameObject instantiatedFish = Instantiate(fishMod,newPos, rotation);//生成鱼
            instantiatedFish.gameObject.name=fish.name;//将生成的鱼名字改为鱼名字（去掉Clone）
            instantiatedFish.gameObject.tag = "FishModel";
        }
    }

    public Vector3 GeneratePosForSpawn(Vector3 pos,Vector3 size)
    {
        Vector3 newPos = pos + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.5f, Random.Range(-size.z / 2, size.z / 2));
        return newPos;
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
