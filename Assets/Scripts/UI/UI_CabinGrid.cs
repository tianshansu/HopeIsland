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
        col.size = new Vector2(rectTrans.rect.width, rectTrans.rect.height);//�����collider�ĳߴ�����Ϊ��cellһ����


        isEmpty= true;//��ʼ��ʱ�����еĸ�����Ϊ����װ����
    }
}
