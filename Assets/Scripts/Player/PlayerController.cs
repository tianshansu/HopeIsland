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
    private CharacterController controller;//��ȡcontroller���
    public float playerSpeed = 2.0f;//���������ʼֵ�������༭�����޸ģ�
    private PlayerInput playerInput;//����input��

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


    public bool canPlayStartAnim;

    //Hook
    public HookMovement hookMovement;
    public bool startMovingHook;

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
            Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();//��ȡinput system��move��ʵʱֵ
            Vector3 move = new Vector3(input.x, 0, input.y);//����moveֵ

            move.y = 0f;//��������Ծ
            controller.Move(move * Time.deltaTime * playerSpeed);//�ý�ɫ�ƶ�

            if (move != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(move);//�����ƶ�����
            }
        }

       
    }

    private void FixedUpdate()
    {
        
        if (findFish == true)
        {
            
            if (currentFish != null)
            {
                currentFish.GetComponent<Fish>().FishStickOnRod();//����������ճ�ڵ������
                //buoy.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                //buoy.gameObject.transform.position=new Vector3(buoy.gameObject.transform.position.x,-1,buoy.gameObject.transform.position.z) ;
                buoy.Play();
                
            }

            

            if (Input.touchCount > 0)//�������Ļ
            {
                buoy.Stop();
                RepositionRod();
                
                
                if(currentFish!=null)
                {
                    currentFish.transform.GetChild(1).gameObject.SetActive(false);
                }
                
                
                if (fishCreated == false)
                {
                    StartCoroutine("ShowCollectPanel");
                    findFish = false;
                }
                
            }

        }else
        {
            if(positionRod==true)
            {
                if (Input.touchCount > 0)
                {
                    RepositionRod();
                positionRod = false;
                }
            }
            
        }

        if(canPlayStartAnim== true)
        {
            StartCoroutine(MoveRope(fishPt));
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
        playerInput.ActivateInput();//��������
        touchCanvas.gameObject.SetActive(true);
        hook.SetActive(false);
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
        lastBoneRb.transform.localPosition = Vector3.zero;
        poleAnim.Play("FindFish");
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
