using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

///<summary>
///
///</summary>

public class HookMovement : MonoBehaviour
{

    public float angle = 10f; // Angle in degrees
    public float radius = 5f;



    public PlayerInput playerInput;//创建input类
    public PlayerFishingFunction playerFishingFunction;

    private float currentDistance = 0;
    private float currentAngle = 0;

    public Vector3 playerCt;



    public FishingLineRenderer fishLine;


    private void Start()
    {

      
    }



    void Update()
    {
        
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();//获取input system中move的实时值
        Vector3 move = new Vector3(input.x, 0, input.y);//设置move值

        move.y = 0f;//不允许跳跃

        transform.Translate(move * Time.deltaTime * playerFishingFunction.fishingSpeed);//让钩子移动

        playerCt = new Vector3(playerFishingFunction.transform.position.x, transform.position.y, playerFishingFunction.transform.position.z);
        

        currentDistance = Vector3.Distance(playerCt, transform.position);
 
        Vector3 self = transform.position - playerCt;
        Vector3 playerPos = currentDistance * playerFishingFunction.transform.forward;

        currentAngle = Vector3.Angle(self, playerPos);

        if (currentAngle < -angle || currentAngle > angle || currentDistance > radius)
        {
            //让hook往回并且往里移一点
            //Debug.Log("超出了");
            //

           if(currentAngle < -angle || currentAngle > angle)//如果角度往下小了
            {
                Vector3 newPt = playerCt + Vector3.Distance(playerCt, transform.position) * playerFishingFunction.transform.forward;//计算玩家正前方的那个点的距离
                Vector3 newDir = newPt - transform.position;
                transform.position += newDir.normalized * playerFishingFunction.fishingSpeed * Time.deltaTime;
            }
            else if(currentDistance > radius)//如果是距离超过了
            {
                transform.position -= (transform.position - playerCt).normalized * playerFishingFunction.fishingSpeed * Time.deltaTime;
            }
        }


        if (playerInput.actions["Move"].WasReleasedThisFrame())//当松开时
        {
            fishLine.gameObject.transform.parent.gameObject.SetActive(false);//隐藏限制线


            playerFishingFunction.fishPt = transform.position;
            playerFishingFunction.fishingPole.GetComponent<Animation>().Play("FishingPole");




            playerFishingFunction.canPlayStartAnim = true;
            playerInput.DeactivateInput();//禁止输入
            playerFishingFunction.touchCanvas.gameObject.SetActive(false);

            playerFishingFunction.isWaitingForFish = true;//开始让鱼可以咬钩
            playerFishingFunction.hookPlaced = true;//已下杆

            gameObject.SetActive(false);
            



        }


      



    }

  
}
