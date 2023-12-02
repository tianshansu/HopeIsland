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



    public PlayerInput playerInput;//����input��
    public PlayerController player;

    private float currentDistance = 0;
    private float currentAngle = 0;

    public Vector3 playerCt;


    public FishingLineRenderer fishLine;

    void Update()
    {
        
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();//��ȡinput system��move��ʵʱֵ
        Vector3 move = new Vector3(input.x, 0, input.y);//����moveֵ

        move.y = 0f;//��������Ծ

        transform.Translate(move * Time.deltaTime * player.fishingSpeed);//�ù����ƶ�

        playerCt = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        

        currentDistance = Vector3.Distance(playerCt, transform.position);
 
        Vector3 self = transform.position - playerCt;
        Vector3 playerPos = currentDistance * player.transform.forward;

        currentAngle = Vector3.Angle(self, playerPos);

        if (currentAngle < -angle || currentAngle > angle || currentDistance > radius)
        {
            //��hook���ز���������һ��
            //Debug.Log("������");
            //

           if(currentAngle < -angle || currentAngle > angle)//����Ƕ�����С��
            {
                Vector3 newPt = playerCt + Vector3.Distance(playerCt, transform.position) * player.transform.forward;//���������ǰ�����Ǹ���ľ���
                Vector3 newDir = newPt - transform.position;
                transform.position += newDir.normalized * player.fishingSpeed * Time.deltaTime;
            }
            else if(currentDistance > radius)//����Ǿ��볬����
            {
                transform.position -= (transform.position - playerCt).normalized * player.fishingSpeed * Time.deltaTime;
            }
        }


        if (playerInput.actions["Move"].WasReleasedThisFrame())//���ɿ�ʱ
        {
            fishLine.gameObject.transform.parent.gameObject.SetActive(false);//����������


            player.fishPt = transform.position;
            player.poleAnim.Play("FishingPole");
            player.canPlayStartAnim = true;
            playerInput.DeactivateInput();//��ֹ����
            player.touchCanvas.gameObject.SetActive(false);
            player.positionRod = true;//���¸�
            gameObject.SetActive(false);
            



        }


      



    }

  
}
