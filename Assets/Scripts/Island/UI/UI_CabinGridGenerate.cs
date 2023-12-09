using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


///<summary>
///
///</summary>

public class UI_CabinGridGenerate : MonoBehaviour
{
    public GameObject gridPrefab;
    public int gridsNumber = 3; 

    public int spacing = 0;

    private RectTransform rectTrans;


    public Canvas UICabinMainStorage;
    public Canvas inputStick;
 

    [HideInInspector]
    public float cellSizeA;

    void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        GenerateGrid();
    }

    void GenerateGrid()
    {
        GridLayoutGroup gridLayout = GetComponent<GridLayoutGroup>();

        
        int totalGrids = gridsNumber * gridsNumber;//计算一共要生成多少个grid

        cellSizeA = (rectTrans.rect.width - (gridsNumber + 1) * spacing)/ gridsNumber;//计算出合理的一个cell的大小

        gridLayout.cellSize = new Vector2(cellSizeA,cellSizeA);//设置cellSize为新算出来的

        gridLayout.spacing = new Vector2(spacing,spacing);

        gridLayout.padding.left = (int)gridLayout.spacing.x;
        gridLayout.padding.top = (int)gridLayout.spacing.x;


        for (int i = 0; i < totalGrids; i++)
        {
            GameObject gridElement = Instantiate(gridPrefab, transform);

            //这里可以增加对于grid的调整
            gridLayout.constraintCount = gridsNumber;
        }

        // Update the layout to ensure the grids are properly positioned
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }


    public void CloseCabinBody()//关闭船舱
    {
        inputStick.gameObject.SetActive(true);
        UICabinMainStorage.gameObject.SetActive(false);
       
    }
}
