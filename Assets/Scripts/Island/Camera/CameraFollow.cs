using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public Transform playerPos;
    void Update()
    {
        gameObject.transform.position = playerPos.transform.position + offset;//�������ʵʱ�������λ�ã�������һ���ض���offset
    }
}
