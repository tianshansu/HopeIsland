using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
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


    public GameObject hook;
    public bool isFishing;
    public Button startFishing;
    public Button finishFishing;
    public Vector3 fishPt;
    public GameObject lastBone;
    private Rigidbody lastBoneRb;
    public GameObject fishingPole;
    private Animation fishing;
    private Vector3 ropeInitialPos;
    public Canvas touchCanvas;
   


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        lastBoneRb = lastBone.GetComponent<Rigidbody>();
        fishing = fishingPole.GetComponent<Animation>();
        ropeInitialPos = lastBone.transform.localPosition;
    }

    void Update()
    {
        if (isFishing == false){
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

            hook.transform.Translate(move * Time.deltaTime * fishingSpeed);//让钩子移动

            if (playerInput.actions["Move"].WasReleasedThisFrame())//当松开时
            {
                fishPt = hook.transform.position;
                fishing.Play();
                MoveRope(fishPt);
                hook.SetActive(false);
                playerInput.DeactivateInput();//禁止输入
                touchCanvas.gameObject.SetActive(false);
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
    }

    public void MoveRope(Vector3 pt)
    {
        lastBoneRb.AddForce(0, 200, 0);
        lastBone.gameObject.transform.position = pt;
        lastBoneRb.constraints = RigidbodyConstraints.FreezeAll;
        
    }

 

    

}
