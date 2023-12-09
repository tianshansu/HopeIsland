using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;


///<summary>
///
///</summary>

public class FishIntoBasket : MonoBehaviour
{
    //鱼本身
    public int fishSizeType;//鱼大小的类别
    [HideInInspector]
    public int fishOccupies;//鱼所占的格子数
    private Vector3 fishInitialPos;

    GameObject selectedObject;

    private void Start()
    {
        fishOccupies = fishOccupyGrids(fishSizeType);//返回这条鱼需要占几格   
        fishInitialPos = gameObject.transform.position;
    }

    private void Update()
    {
        if(Input.touchCount>0)
        {
            UnityEngine.Touch touch=Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)//如果状态是began
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
                        selectedObject = hit.collider.gameObject;//将碰到的鱼设为selectedObject
                        
                    }
                }
                
            }
            else if (touch.phase == TouchPhase.Moved)//如果手移动了
            {
                if (selectedObject != null)//如果当前有选中的物体
                {
                    // Move your object
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));//将touchPos转变为世界坐标

                    float desiredHeight = 1.0f; // Set this to the desired height
                    touchPosition.y = desiredHeight;

                    selectedObject.transform.position = touchPosition;

                    //selectedObject.transform.position = touchPosition;//更改鱼的位置
                    selectedObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;//锁定y轴移动
                }
            }
            else if (touch.phase == TouchPhase.Ended)//如果手离开了
            {
                // Reset selected object
                if(selectedObject != null)
                {
                    selectedObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;//可以y轴移动
                    selectedObject = null;//将选中物体设为null
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
