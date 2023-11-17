using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

///<summary>
///
///</summary>

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;//��ȡcontroller���
    public float playerSpeed = 2.0f;//���������ʼֵ�������༭�����޸ģ�
    private PlayerInput playerInput;//����input��

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
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
