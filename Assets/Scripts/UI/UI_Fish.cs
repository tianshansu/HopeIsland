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


    public int collisionCount = 0;

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
        //CheckForOverlaps();

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
    }

    public void OnPointerDown(PointerEventData eventData)//当被手指按下时
    {
        // Finger is pressing on the image
        isPressed = true;
        Debug.Log(collisionCount);
    }

    public void OnPointerUp(PointerEventData eventData)//当手指离开时
    {
        // Finger is lifted from the image
        isPressed = false;
        //Debug.Log("Finger Up from Image");



        if(collisionCount== fishOccupyGrids(fishSizeType))
        {
            gameObject.transform.position=Input.GetTouch(0).position;
        }else
        {
            ResetPos();
        }
    }

    public void ResetPos()
    {
        gameObject.transform.position = new Vector3(fishInitialPos.x, fishInitialPos.y, 0);
    }

    private RectTransform currentRectTransform;

   

    //private void CheckForOverlaps()
    //{
    //    // Get all UI objects with RectTransform components in the Canvas
    //    RectTransform[] allRectTransforms = FindObjectsOfType<RectTransform>();

    //    // Counter for overlapping UI elements
    //    int overlappingCount = 0;

    //    foreach (RectTransform otherRectTransform in allRectTransforms)
    //    {
    //        // Skip the current RectTransform
    //        if (otherRectTransform == currentRectTransform)
    //            continue;

    //        // Check for overlap using Rect.Overlap method
    //        if (Rect.Overlaps(currentRectTransform.rect, otherRectTransform.rect))
    //        {
    //            // Overlap detected
    //            overlappingCount++;
    //        }
    //    }

    //    // Print or use the overlappingCount as needed
    //    Debug.Log("Overlapping UI elements: " + overlappingCount);
    //}

}
