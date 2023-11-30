using System;
using System.Collections;
using System.Collections.Generic;
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

  
    public GameObject hook;

    [HideInInspector]
    public bool isFishing;
    [HideInInspector]
    public Button startFishing;
    [HideInInspector]
    public Button finishFishing;
    [HideInInspector]
    public Vector3 fishPt;
    //[HideInInspector]
    public GameObject lastBone;
    //[HideInInspector]
    public Rigidbody lastBoneRb;
    //[HideInInspector]
    public GameObject fishingPole;
    [HideInInspector]
    private Animation poleAnim;
    //[HideInInspector]
    public Animation buoy;
    private Vector3 ropeInitialPos;
    [HideInInspector]
    public Canvas touchCanvas;


    [HideInInspector]
    public bool findFish;
    [HideInInspector]
    public bool fishCreated;
 



    private GameObject panel;



    [HideInInspector]
    public GameObject currentFish;

    [HideInInspector]
    public bool isCatchingFish;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        //lastBoneRb = lastBone.GetComponent<Rigidbody>();
        poleAnim= fishingPole.GetComponent<Animation>();
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
        else
        {
            Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();//获取input system中move的实时值
            Vector3 move = new Vector3(input.x, 0, input.y);//设置move值

            move.y = 0f;//不允许跳跃

            Vector3 playerCt = new Vector3(transform.position.x, hook.transform.position.y, transform.position.z);
            if (Vector3.Distance(hook.transform.position, playerCt) <= fishingRange)
            {
                hook.transform.Translate(move * Time.deltaTime * fishingSpeed);//让钩子移动
                if (playerInput.actions["Move"].WasReleasedThisFrame())//当松开时
                {
                    fishPt = hook.transform.position;
                    poleAnim.Play("FishingPole");
                    MoveRope(fishPt);
                    hook.SetActive(false);
                    playerInput.DeactivateInput();//禁止输入
                    touchCanvas.gameObject.SetActive(false);
                    
                }
            }
            else
            {
                hook.transform.position -= (hook.transform.position - playerCt).normalized * 0.01f;
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
                buoy.Play();
            }

            

            if (Input.touchCount > 0)//如果按屏幕
            {
                buoy.Stop();
                //lastBone.transform.localPosition = Vector3.zero;
                lastBoneRb.transform.localPosition= Vector3.zero;
                poleAnim.Play("FindFish");
                
                if(currentFish!=null)
                {
                    currentFish.transform.GetChild(1).gameObject.SetActive(false);
                }
                

                
                if (fishCreated == false)
                {
                    StartCoroutine("ShowCollectPanel");
                }
                findFish = false;
            }



        }
    }

    public void MoveToNewPlace(Vector3 pos)
    {
        gameObject.transform.position = new Vector3(pos.x,transform.position.y,pos.z);

    }

    public void Fishing()
    {
        isFishing = true;
        hook.transform.position=new Vector3(transform.position.x, hook.transform.position.y, transform.position.z);
        hook.SetActive(true);
        startFishing.gameObject.SetActive(false);
        finishFishing.gameObject.SetActive(true);
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
    }

    public void MoveRope(Vector3 pt)
    {
        lastBone.transform.position = pt;

    }


    IEnumerator ShowCollectPanel()
    {
        yield return new WaitForSeconds(1);
        panel.SetActive(true);
        
        Destroy(currentFish);
    }


    public void HideCollectPanel()
    {
        panel.SetActive(false);
        FinishFishing();
        isCatchingFish = false;

    }
}
