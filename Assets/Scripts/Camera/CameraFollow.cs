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
        gameObject.transform.position = playerPos.transform.position + offset;//让摄像机实时跟随玩家位置，并且有一个特定的offset
    }
}
