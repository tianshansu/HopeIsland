using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



///<summary>
///
///</summary>

public class UI_Fish : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int fishSizeType;

    private bool isPressed;

    [HideInInspector]
    public int fishOccupies;

    private void Start()
    {
        fishOccupies = fishOccupyGrids(fishSizeType);//������������Ҫռ����   
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

    private void Update()
    {
        if (isPressed)
        {
            // Handle continuous press logic here
            //Debug.Log("Finger is still pressing on Image");
            gameObject.transform.position = Input.GetTouch(0).position;//�����㱾���λ��
        }
    }

    public void OnPointerDown(PointerEventData eventData)//������ָ����ʱ
    {
        // Finger is pressing on the image
        isPressed = true;
        //Debug.Log("Finger Down on Image");
    }

    public void OnPointerUp(PointerEventData eventData)//����ָ�뿪ʱ
    {
        // Finger is lifted from the image
        isPressed = false;
        //Debug.Log("Finger Up from Image");
    }


}
