using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;

///<summary>
///
///</summary>

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;//获取controller组件
    public float playerSpeed = 2.0f;//设置任意初始值（后续编辑器中修改）
    private PlayerInput playerInput;//创建input类

    public float fishingSpeed;

    public float fishingRange;

    [HideInInspector]
    public GameObject hook;

    [HideInInspector]
    public bool isFishing;
    [HideInInspector]
    public Button startFishing;
    [HideInInspector]
    public Button finishFishing;
    [HideInInspector]
    public Vector3 fishPt;
    [HideInInspector]
    public GameObject lastBone;
    [HideInInspector]
    public Rigidbody lastBoneRb;
    [HideInInspector]
    public GameObject fishingPole;
    [HideInInspector]
    public Animation poleAnim;
    [HideInInspector]
    public Animation buoy;
    private Vector3 ropeInitialPos;
    [HideInInspector]
    public Canvas touchCanvas;



    [HideInInspector]
    public bool findFish;
    [HideInInspector]
    public bool fishCreated;


    public bool positionRod;

    private GameObject panel;




    [HideInInspector]
    public GameObject currentFish;

    [HideInInspector]
    public bool isCatchingFish;

    [HideInInspector]
    public bool canPlayStartAnim;

    [HideInInspector]
    public Boat boat;

    [HideInInspector]
    public bool canOpenCabin;

    //Hook
    [HideInInspector]
    public HookMovement hookMovement;
    [HideInInspector]
    public bool startMovingHook;
    [HideInInspector]
    public FishingLineRenderer fishLine;


    public FishBasket fishBasket;

    private bool isPut;//检测是否已经把鱼放进虚拟basket了

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        //lastBoneRb = lastBone.GetComponent<Rigidbody>();
        poleAnim = fishingPole.GetComponent<Animation>();
        ropeInitialPos = lastBone.transform.localPosition;
        panel = GameObject.Find("InGameCanvas").transform.Find("P_FindFish").gameObject;



    }

    void Update()
    {
        if (isFishing == false)
        {
            Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();//获取input system中move的实时值
            Vector3 move = new Vector3(input.x, 0, input.y);//设置move值

            move.y = 0f;//不允许跳跃
            controller.Move(move * Time.deltaTime * playerSpeed);//让角色移动

            if (move != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(move);//看向移动方向
            }
        }

        
    }

    private void FixedUpdate()
    {

        if (findFish == true)
        {

            if (currentFish != null)
            {
                currentFish.GetComponent<Fish>().FishStickOnRod();//将碰到的鱼粘在钓鱼竿上
                //buoy.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                //buoy.gameObject.transform.position=new Vector3(buoy.gameObject.transform.position.x,-1,buoy.gameObject.transform.position.z) ;
                buoy.Play();

                if(isPut== false)
                {
                    PutFishIntoBasket(currentFish.gameObject.name);//将当前鱼名字传进去，用于往鱼筐里加鱼
                }
                

            }



            if (Input.touchCount > 0)//如果按屏幕
            {
                buoy.Stop();
                RepositionRod();


                if (currentFish != null)
                {
                    currentFish.transform.GetChild(1).gameObject.SetActive(false);//把阴影鱼隐藏
                    currentFish.transform.GetChild(0).gameObject.SetActive(true);//把彩色鱼显示
                }


                if (fishCreated == false)
                {
                    StartCoroutine("ShowCollectPanel");
                    findFish = false;
                }

            }

        }
        else
        {
            if (positionRod == true)
            {
                if (Input.touchCount > 0)
                {
                    buoy.Stop();
                    RepositionRod();
                    currentFish= null;
                    isCatchingFish= false;
                    positionRod = false;

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
        isFishing = true;
        fishLine.gameObject.transform.parent.gameObject.SetActive(true);
        hook.transform.position = new Vector3(transform.position.x, hook.transform.position.y, transform.position.z);
        hook.SetActive(true);
        startFishing.gameObject.SetActive(false);
        finishFishing.gameObject.SetActive(true);
        canOpenCabin = false;
    }

    public void FinishFishing()
    {
        isFishing = false;
        lastBone.gameObject.transform.localPosition = ropeInitialPos;
        finishFishing.gameObject.SetActive(false);
        startFishing.gameObject.SetActive(true);
        playerInput.ActivateInput();//允许输入
        touchCanvas.gameObject.SetActive(true);
        hook.SetActive(false);
        canOpenCabin = true;//可以打开船舱
        fishLine.gameObject.transform.parent.gameObject.SetActive(false);

        isPut = false;
        
        
    }

    IEnumerator MoveRope(Vector3 pt)
    {
        yield return new WaitForSeconds(0.5f);
        lastBone.transform.position = Vector3.Lerp(lastBone.transform.position, new Vector3(pt.x, -2, pt.z), 0.5f);
        //lastBoneRb.MovePosition(new Vector3(pt.x, -1, pt.z));
        //lastBone.transform.position = new Vector3(pt.x, -1, pt.z);
        //lastBoneRb.constraints = RigidbodyConstraints.FreezePositionY;
        canPlayStartAnim = false;
    }



    public void RepositionRod()
    {
        //Vector3.Lerp(lastBone.transform.position,Vector3.zero,0.2f);
        lastBoneRb.transform.localPosition = Vector3.zero;
        poleAnim.Play("FindFish");
    }


    IEnumerator ShowCollectPanel()
    {
        yield return new WaitForSeconds(1);
        panel.SetActive(true);
        if (currentFish != null)
        {
            
            Destroy(currentFish);
        }
        

    }


    public void HideCollectPanel()
    {
        panel.SetActive(false);
        FinishFishing();
        isCatchingFish = false;

    }

    private void PutFishIntoBasket(string name)
    {
      
        switch (name)
        {
            case "青鱼":
                IncreaseDictionaryValue(fishBasket.currentFishBasket, "qingYu", 1);
                isPut = true;
                break;
            case "金枪鱼":
                IncreaseDictionaryValue(fishBasket.currentFishBasket, "jinQiangYu", 1);
                isPut = true;
                break;
            case "鳕鱼":
                IncreaseDictionaryValue(fishBasket.currentFishBasket, "xueYu", 1);
                isPut = true;
                break;
            case "三文鱼":
                IncreaseDictionaryValue(fishBasket.currentFishBasket, "sanWenYu", 1);
                isPut = true;
                break;
        }
    }

    static void IncreaseDictionaryValue(Dictionary<string, int> dictionary, string key, int increment)
    {
        // 检查这个类别是否存在
        if (dictionary.ContainsKey(key))
        {
            // Increase the value associated with the key
            dictionary[key] += increment;
        }
    }
}
