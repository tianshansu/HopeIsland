using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


    ///<summary>
    ///
    ///</summary>

public class Fish : MonoBehaviour
{
    //�������
    private float sec;
    private FixedJoint joint;
    private Rigidbody rg;
    private Animator fishAnimator;

    private PlayerFishingFunction playerFishingFunction;


    private void Start()
    {
        joint= GetComponent<FixedJoint>();
        rg= gameObject.GetComponent<Rigidbody>();
        fishAnimator = transform.GetChild(1).GetComponent<Animator>();
        playerFishingFunction=GameObject.Find("Player").GetComponent<PlayerFishingFunction>();

    }


    

    private void OnTriggerEnter(Collider other)
    {
        if (playerFishingFunction.isWaitingForFish)//����׸������ڵȴ����ʱ��
        {
            if (other.gameObject.tag == "YuGan")//������tagΪYuGan��collider����ʼ��������׼���Ϲ�
            {
                playerFishingFunction.isWaitingForFish= false;
                sec = Random.Range(3, 10);
                StartCoroutine("WaitFor");
                playerFishingFunction.currentFish = transform.gameObject;
                
            }
        }
        
    }

    private void OnTriggerExit(Collider other)//��������ǰ̧�����ˣ�����ֹ
    {
        if(other.gameObject.tag=="YuGan")
        {
            StopCoroutine("WaitFor");
        }
    }


    IEnumerator WaitFor()
    {
        if(playerFishingFunction.fishCreated== false)
        {
            yield return new WaitForSeconds(sec);
            playerFishingFunction.findFish = true;
            fishAnimator.SetBool("Jumping", true);

        }
        
       
    }

    public void FishStickOnRod()
    {
        
        transform.position=new Vector3(playerFishingFunction.lastBone.transform.position.x, playerFishingFunction.lastBone.transform.position.y-0.6f, playerFishingFunction.lastBone.transform.position.z);
        transform.parent = playerFishingFunction.lastBone.transform;
        ChangeUIName();

    }

    public void ChangeUIName()
    {
        FishCollectionPanel ui = GameObject.Find("InGameCanvas").transform.Find("P_FindFish").gameObject.GetComponent<FishCollectionPanel>();
        ui.ChangeFishName(gameObject.name);
    }

   

}
