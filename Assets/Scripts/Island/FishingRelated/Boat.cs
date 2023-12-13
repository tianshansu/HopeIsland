using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

    ///<summary>
    ///
    ///</summary>

public class Boat : MonoBehaviour
{
    public Button startBoat;
    public Button finishBoat;
    public Button fishing;
 
    public Transform playerPos;

    public PlayerFishingFunction playerFishingFunction;

    public GameObject facingPt;

    private Transform maTou;

    public Canvas cabinCanvas;


    private void Start()
    {
        
    }



    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="MaTou")
        {
            maTou = other.gameObject.transform;
        }
    }

    public void StickWithPlayer()
    {
        playerFishingFunction.MoveToNewPlace(gameObject.transform.position);//改变玩家位置
        playerPos.forward = facingPt.transform.forward;//改变玩家朝向为船头处的那个点的朝向
        startBoat.gameObject.SetActive(false);
        fishing.gameObject.SetActive(true);
        transform.parent=playerPos.transform;

    }


    public void PlayerGetBackToMaTou()
    {
        transform.parent = null;
        playerFishingFunction.MoveToNewPlace(maTou.transform.position);
        finishBoat.gameObject.SetActive(false);
        fishing.gameObject.SetActive(false);

    }


}
