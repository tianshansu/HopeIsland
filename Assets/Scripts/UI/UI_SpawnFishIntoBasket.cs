using System.Collections;
using System.Collections.Generic;
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


    private void Start()
    {
        SpawnFish(qingYu, currentFishCollected.currentFishBasket["qingYu"]);

    }

    public void SpawnFish(GameObject fish, int number)
    {
        Image fishImg=fish.GetComponent<Image>();
        for(int i=0;i<number; i++)
        {

            Image instantiatedObject = Instantiate(fishImg, gameObject.transform);//生成鱼
            instantiatedObject.transform.localPosition = new Vector3(0f, 800f, 0f);//生成鱼的位置
        }
    }


    //private void Update()
    //{
    //    if (Input.touchCount>0)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //            //Ray ray = Camera.main.ScreenPointToRay(touch.position);
    //            //RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction,1000);

          

    //            //Debug.Log("runned");
    //            //if (hit.collider != null && hit.collider.gameObject.CompareTag("FishImg"))
    //            //{
    //            //    Debug.Log("touched");
    //            //    hit.collider.gameObject.transform.position = touch.position;
    //            //}
           
    //    }
    //}
}
