using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;
using UnityEngine.UI;

///<summary>
///
///</summary>

public class PlayerFishingFunction : MonoBehaviour
{
    public float fishingSpeed;

    public float fishingRange;

    private PlayerInput playerInput;//创建input类

    public GameObject hook;


    public bool isPlacingFishingSpot;//是否开始钓鱼正在摆放抛竿点

    public Vector3 fishPt;//用于获取Hook的位置，从而抛竿

    public GameObject lastBone;//用于让鱼贴到鱼线上

    private Rigidbody lastBoneRb;

    public GameObject fishingPole;//存储用于获取鱼竿动画

    public Animation buoy;//获取晃动动画

    private Vector3 ropeInitialPos;//记录鱼竿原本的点，用于鱼竿归位

    public Canvas touchCanvas;//在结束钓鱼后把圆盘显示回来

    private GameObject panel;//获取钓到鱼的panelUI

    public GameObject currentFish;//记录当前咬钩的鱼

    public bool canPlayStartAnim;//可以播放开始抛竿动画

    public Boat boat;//获取船脚本

    public HookMovement hookMovement;//获取鱼漂

    public FishingLineRenderer fishLine;//显示render line

    public FishBasket fishBasket;//获取basket，用于在钓上鱼之后往里存储

    private bool isPut;//检测是否已经把鱼放进虚拟basket了


    public bool isWaitingForFish;//鱼是可以咬钩的状态

    public bool findFish;//有鱼咬钩

    public bool hookPlaced;//放下杆子了

    public bool hookIsRePlaced;//杆子已经被重置了


    public bool fishCreated;







    private void Start()
    {
        lastBoneRb=lastBone.GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        ropeInitialPos = lastBone.transform.localPosition;
        panel = GameObject.Find("InGameCanvas").transform.Find("P_FindFish").gameObject;
    }

    private void Update()
    {
        if (findFish == true)
        {

            if (currentFish != null)
            {
                currentFish.GetComponent<Fish>().FishStickOnRod();//将碰到的鱼粘在钓鱼竿上
                
                buoy.Play();

                


                if (Input.touchCount > 0)//如果按屏幕
                {
                    buoy.Stop();

                    if (isPut == false)//只有当isPut是false，才能往dict里加数据，所以别忘记在按屏幕钓上鱼的时候设置false
                    {
                        PutFishIntoBasket(currentFish.gameObject.name);//将当前鱼名字传进去，用于往鱼筐里加鱼
                    }

                    if (hookIsRePlaced == false)
                    {
                        RepositionRod();
                    }


                    if (currentFish != null)
                    {
                        currentFish.transform.GetChild(1).gameObject.SetActive(false);//把阴影鱼隐藏
                        currentFish.transform.GetChild(0).gameObject.SetActive(true);//把彩色鱼显示
                    }


                    if (fishCreated == false)
                    {
                        StartCoroutine("ShowCollectPanel");

                    }

                }

            }



        }
        else
        {
            if (hookPlaced == true)
            {
                if (Input.touchCount > 0)
                {
                    buoy.Stop();
                    if(hookIsRePlaced==false)
                    {
                        RepositionRod();
                    }
                    isPut = false;
                    currentFish = null;
                    isWaitingForFish = false;
                    hookPlaced = false;

                }
            }

        }

        if (canPlayStartAnim == true)
        {
            StartCoroutine(MoveRope(fishPt));
        }
    }

    public void MoveToNewPlace(Vector3 pos)
    {
        gameObject.transform.position = new Vector3(pos.x, transform.position.y, pos.z);

    }

    public void Fishing()
    {
        isPlacingFishingSpot = true;//点击开始钓鱼时，将正在摆放设为true，使用button event
        

        fishLine.gameObject.transform.parent.gameObject.SetActive(true);
        hook.transform.position = new Vector3(transform.position.x, hook.transform.position.y, transform.position.z);
        hook.SetActive(true);
        

    }



    public void FinishFishing()
    {
        isPlacingFishingSpot = false;//点击结束钓鱼时，将正在摆放设为false
        hookPlaced = false;


        lastBone.gameObject.transform.localPosition = ropeInitialPos;
    
        playerInput.ActivateInput();//允许输入
        touchCanvas.gameObject.SetActive(true);
        hook.SetActive(false);

        fishLine.gameObject.transform.parent.gameObject.SetActive(false);

        isPut = false;


    }

  

    IEnumerator MoveRope(Vector3 pt)
    {
        yield return new WaitForSeconds(0.5f);
        lastBone.transform.position = Vector3.Lerp(lastBone.transform.position, new Vector3(pt.x, -2, pt.z), 0.5f);
        canPlayStartAnim = false;
    }



    public void RepositionRod()
    {
        lastBoneRb.transform.localPosition = Vector3.zero;
        fishingPole.GetComponent<Animation>().Play("FindFish");
        hookIsRePlaced = true;
        KeepFishing();
    }


    IEnumerator ShowCollectPanel()
    {

        yield return new WaitForSeconds(1);
        panel.SetActive(true);
        Destroy(currentFish);
        findFish = false;
        currentFish = null;

    }


    public void HideCollectPanel()//在关闭找到鱼的面板后，调用
    {
        panel.SetActive(false);
        KeepFishing();

    }

    public void KeepFishing()
    {
        playerInput.ActivateInput();//允许输入
        fishLine.gameObject.transform.parent.gameObject.SetActive(true);
        hook.SetActive(true);
        hook.gameObject.transform.position = new Vector3(transform.position.x, hook.gameObject.transform.position.y, transform.position.z);
        touchCanvas.gameObject.SetActive(true);
        isWaitingForFish = false;
        
    }

    private void PutFishIntoBasket(string name)
    {

        switch (name)
        {
            case "青鱼":
                fishBasket.IncreaseDictionaryValue("qingYu");
                isPut = true;

                break;
            case "金枪鱼":
                fishBasket.IncreaseDictionaryValue("jinQiangYu");
                isPut = true;

                break;
            case "鳕鱼":
                fishBasket.IncreaseDictionaryValue("xueYu");
                isPut = true;

                break;
            case "三文鱼":
                fishBasket.IncreaseDictionaryValue("sanWenYu"); 
                isPut = true;

                break;
        }
    }

    
}
