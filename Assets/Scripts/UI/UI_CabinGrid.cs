using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class UI_CabinGrid : MonoBehaviour
{
    public bool isEmpty;

    //private BoxCollider2D col;
    //private RectTransform rectTrans;

    public UI_Fish fish;



    private void Start()
    {
        //col=gameObject.GetComponent<BoxCollider2D>();

        //col.size = new Vector2(rectTrans.rect.width,rectTrans.rect.height);

        //rectTrans = GetComponent<RectTransform>();
        //col.size = new Vector2(rectTrans.rect.width, rectTrans.rect.height);//�����collider�ĳߴ�����Ϊ��cellһ����


        isEmpty= true;//��ʼ��ʱ�����еĸ�����Ϊ����װ����
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    fish.collisionCount++;
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    fish.collisionCount--;
    //}
}
