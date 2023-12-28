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
        Gizmos.DrawCube(pos, size);//根据桌子位置画一个自定义的方块
    }

    private void OnEnable()//每次打开鱼篓界面时，恢复目前鱼篓里的鱼（从保留的dict鱼篓里生成对应鱼）
    {
        spawnFish.SpawnFish(spawnFish.qingYu, fishBasket.keptFishBasket["qingYu"],gameObject.transform.position,size);
        spawnFish.SpawnFish(spawnFish.sanWenYu, fishBasket.keptFishBasket["sanWenYu"], gameObject.transform.position, size);
        spawnFish.SpawnFish(spawnFish.jinQiangYu, fishBasket.keptFishBasket["jinQiangYu"], gameObject.transform.position, size);
        spawnFish.SpawnFish(spawnFish.xueYu, fishBasket.keptFishBasket["xueYu"], gameObject.transform.position, size);
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "FishModel")
        {
            int fishOccupy = other.gameObject.GetComponent<FishIntoBasket>().fishOccupies;

            if (totalFishOccupy + fishOccupy <= 10)
            {
                totalFishOccupy += fishOccupy; //注意需要用int来接受这个数值
                text.text = totalFishOccupy.ToString(); //再将数值ToString
                //Debug.Log(other.gameObject.name);
                fishBasket.IncreaseDictionaryValue(fishBasket.keptFishBasket, other.gameObject.name);//将放进鱼篓里的鱼记录到keptFishBasket里
            }
            else
            {
                textFull.gameObject.SetActive(true);
                other.gameObject.GetComponent<FishIntoBasket>().ResetFishPos();
                totalFishOccupy += fishOccupy; //注意需要用int来接受这个数值
                text.text = totalFishOccupy.ToString(); //再将数值ToString
            }

            //PrintDictionary(fishBasket.keptFishBasket);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        int fishOccupy = other.gameObject.GetComponent<FishIntoBasket>().fishOccupies;

        totalFishOccupy -= fishOccupy; //注意需要用int来接受这个数值
        text.text = totalFishOccupy.ToString(); //再将数值ToString
        fishBasket.DecreaseDictionaryValue(fishBasket.keptFishBasket, other.gameObject.name);//将拿出鱼篓里的鱼记录到keptFishBasket里
        
    }

  public void ClearCount()
    {
        totalFishOccupy =0; //注意需要用int来接受这个数值
        text.text = totalFishOccupy.ToString(); //再将数值ToString
    }


}
