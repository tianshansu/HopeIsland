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

    private Vector2 fishInitialPos;


    private int overlappingCount = 0;

    private bool canCheck;


    List<RectTransform> allRect = new List<RectTransform>();

    private void Start()
    {
        fishOccupies = fishOccupyGrids(fishSizeType);//返回这条鱼需要占几格   
        fishInitialPos=gameObject.transform.position;

        // Get the RectTransform component
        currentRectTransform = GetComponent<RectTransform>();
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
        // Check for overlaps at the start (you may want to do this continuously in Update)

        if(canCheck)
        {
            CheckForOverlaps();
        }
            


        if (isPressed)
        {
            // Handle continuous press logic here
            //Debug.Log("Finger is still pressing on Image");
            gameObject.transform.position = Input.GetTouch(0).position;//更改鱼本身的位置
        }

        if (gameObject.transform.position.y < -400)
        {
            ResetPos();
        }

        Debug.Log(overlappingCount);
        
    }

    public void OnPointerDown(PointerEventData eventData)//当被手指按下时
    {
        // Finger is pressing on the image
        isPressed = true;
        ClearAll();

    }

    public void OnPointerUp(PointerEventData eventData)//当手指离开时
    {
        // Finger is lifted from the image
        isPressed = false;
        //Debug.Log("Finger Up from Image");

        canCheck = true;


        if (overlappingCount == fishOccupyGrids(fishSizeType))//如果位置合适
        {
            gameObject.transform.position = Input.GetTouch(0).position;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;//定住
            ClearAll();
            canCheck= false;

        }
        else
        {
            ResetPos();
        }
    }

    public void ResetPos()
    {
        gameObject.transform.position = new Vector3(fishInitialPos.x, fishInitialPos.y, 0);
        ClearAll();
    }

    private RectTransform currentRectTransform;



    private void CheckForOverlaps()
    {
        // Get all UI objects with RectTransform components in the Canvas
        RectTransform[] allRectTransforms = FindObjectsOfType<RectTransform>();


        foreach (RectTransform otherRectTransform in allRectTransforms)
        {
            
            // Skip the current RectTransform
            if (otherRectTransform == currentRectTransform)
                continue;

            // Check if the other UI element has the specified tag
            if (otherRectTransform.CompareTag("Grid")&& allRect.Contains(otherRectTransform)==false)//如果当前tag为grid，且这个当前的rectTrans不在已经碰到的列表中，就可以下一步）
            {
                // Check for overlap using RectTransformUtility
                if (RectTransformUtility.RectangleContainsScreenPoint(otherRectTransform, RectTransformUtility.WorldToScreenPoint(null, currentRectTransform.position)))
                {
                    allRect.Add(otherRectTransform);
                    // Overlap detected
                    overlappingCount++;
                }
               
            }
        }
    }

    private void ClearAll()
    {
        allRect.Clear();
        overlappingCount = 0;
    }
}
