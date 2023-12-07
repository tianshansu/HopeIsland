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
        fishOccupies = fishOccupyGrids(fishSizeType);//返回这条鱼需要占几格   
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
            gameObject.transform.position = Input.GetTouch(0).position;//更改鱼本身的位置
        }
    }

    public void OnPointerDown(PointerEventData eventData)//当被手指按下时
    {
        // Finger is pressing on the image
        isPressed = true;
        //Debug.Log("Finger Down on Image");
    }

    public void OnPointerUp(PointerEventData eventData)//当手指离开时
    {
        // Finger is lifted from the image
        isPressed = false;
        //Debug.Log("Finger Up from Image");
    }


}
