using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class UI_CabinGrid : MonoBehaviour
{
    public bool isEmpty;

    private BoxCollider2D col;
    private RectTransform rectTrans;

    private void Start()
    {
        col=gameObject.AddComponent<BoxCollider2D>();
        rectTrans = GetComponent<RectTransform>();
        col.size = new Vector2(rectTrans.rect.width, rectTrans.rect.height);//将这个collider的尺寸设置为和cell一样的


        isEmpty= true;//初始化时将所有的格子设为可以装东西
    }
}
