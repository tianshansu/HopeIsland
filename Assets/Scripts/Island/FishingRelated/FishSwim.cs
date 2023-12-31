using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class FishSwim : MonoBehaviour
{
    public float range;
    public float swimSpeed;
    public float stopTime;

    private bool foundPt;
    private bool isMoving;
    private bool turned;
    private Vector3 newPt;
    private float finishedMovingTime;
    private bool timeRecorded;

    private void Update()
    {
       
        if(!foundPt)//找点
        {
            newPt = FindNextPt();
            timeRecorded = false;//可以随时记录到达时间
        }

        if(!turned)//转向
        {
            TurnTowardsPoint(gameObject, newPt);
            isMoving = false;
        }

        if (!isMoving)//移动
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, newPt, swimSpeed * Time.deltaTime*0.5f);
            if (!timeRecorded)//如果没有记录到时间
            {
                if (gameObject.transform.position == newPt)//游到目标点
                {
                    finishedMovingTime = Time.time;//记录时间
                    timeRecorded = true;//记录时间为true

                }

            }
            else if(finishedMovingTime+stopTime<=Time.time) 
            {
                foundPt= false;
                turned=false;
            }
        }
        

        
    }



    public Vector3 FindNextPt()//寻找下一个点
    {
        float x= Random.Range(-range, range);
        float z= Random.Range(-range, range);
        Vector3 newPt= new Vector3(gameObject.transform.position.x+x, gameObject.transform.position.y, gameObject.transform.position.z+z);//随机生成一个半径范围内的点
        foundPt= true;
        return newPt;
    }

    public void TurnTowardsPoint(GameObject objectToRotate, Vector3 pointToLookAt)//转向
    {
        Vector3 directionToTarget = (pointToLookAt - objectToRotate.transform.position).normalized;//获取需要看向的地方的向量

        gameObject.transform.forward= directionToTarget;//更改物体的forward

        turned = true;
    }
}
