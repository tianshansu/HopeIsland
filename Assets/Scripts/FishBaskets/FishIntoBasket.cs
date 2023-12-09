using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;


///<summary>
///
///</summary>

public class FishIntoBasket : MonoBehaviour
{
    //�㱾��
    public int fishSizeType;//���С�����
    [HideInInspector]
    public int fishOccupies;//����ռ�ĸ�����
    private Vector3 fishInitialPos;

    GameObject selectedObject;

    private void Start()
    {
        fishOccupies = fishOccupyGrids(fishSizeType);//������������Ҫռ����   
        fishInitialPos = gameObject.transform.position;
    }

    private void Update()
    {
        if(Input.touchCount>0)
        {
            UnityEngine.Touch touch=Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)//���״̬��began
            {
                // Convert touch position to ray
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Perform raycast
                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the raycast hit the target object
                    if (hit.collider != null && hit.collider.gameObject.CompareTag("FishModel"))
                    {
                        selectedObject = hit.collider.gameObject;//������������ΪselectedObject
                        
                    }
                }
                
            }
            else if (touch.phase == TouchPhase.Moved)//������ƶ���
            {
                if (selectedObject != null)//�����ǰ��ѡ�е�����
                {
                    // Move your object
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));//��touchPosת��Ϊ��������

                    float desiredHeight = 1.0f; // Set this to the desired height
                    touchPosition.y = desiredHeight;

                    selectedObject.transform.position = touchPosition;

                    //selectedObject.transform.position = touchPosition;//�������λ��
                    selectedObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;//����y���ƶ�
                }
            }
            else if (touch.phase == TouchPhase.Ended)//������뿪��
            {
                // Reset selected object
                if(selectedObject != null)
                {
                    selectedObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;//����y���ƶ�
                    selectedObject = null;//��ѡ��������Ϊnull
                }
                
            }
        }

        if(gameObject.transform.position.y<-1)
        {
            ResetFishPos();
        }
    }

    public int fishOccupyGrids(int type)
    {
        switch (type)
        {
            case 0:
                return 1;
            case 1:
                return 2;
            case 2:
                return 3;
            case 3:
                return 4;
            default:
                return 0;
        }
    }

    public void ResetFishPos()
    {
        gameObject.transform.position = fishInitialPos;
    }
}
