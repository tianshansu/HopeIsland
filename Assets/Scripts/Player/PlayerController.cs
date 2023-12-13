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

    private PlayerFishingFunction playerFishingFunction;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        playerFishingFunction = GetComponent<PlayerFishingFunction>();
    }

    void Update()
    {
        if (playerFishingFunction.isPlacingFishingSpot == false)//如果玩家没有正在摆放抛竿点，就可以进行移动
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

}
