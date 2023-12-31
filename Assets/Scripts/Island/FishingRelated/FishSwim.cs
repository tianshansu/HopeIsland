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
       
        if(!foundPt)//�ҵ�
        {
            newPt = FindNextPt();
            timeRecorded = false;//������ʱ��¼����ʱ��
        }

        if(!turned)//ת��
        {
            TurnTowardsPoint(gameObject, newPt);
            isMoving = false;
        }

        if (!isMoving)//�ƶ�
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, newPt, swimSpeed * Time.deltaTime*0.5f);
            if (!timeRecorded)//���û�м�¼��ʱ��
            {
                if (gameObject.transform.position == newPt)//�ε�Ŀ���
                {
                    finishedMovingTime = Time.time;//��¼ʱ��
                    timeRecorded = true;//��¼ʱ��Ϊtrue

                }

            }
            else if(finishedMovingTime+stopTime<=Time.time) 
            {
                foundPt= false;
                turned=false;
            }
        }
        

        
    }



    public Vector3 FindNextPt()//Ѱ����һ����
    {
        float x= Random.Range(-range, range);
        float z= Random.Range(-range, range);
        Vector3 newPt= new Vector3(gameObject.transform.position.x+x, gameObject.transform.position.y, gameObject.transform.position.z+z);//�������һ���뾶��Χ�ڵĵ�
        foundPt= true;
        return newPt;
    }

    public void TurnTowardsPoint(GameObject objectToRotate, Vector3 pointToLookAt)//ת��
    {
        Vector3 directionToTarget = (pointToLookAt - objectToRotate.transform.position).normalized;//��ȡ��Ҫ����ĵط�������

        gameObject.transform.forward= directionToTarget;//���������forward

        turned = true;
    }
}
