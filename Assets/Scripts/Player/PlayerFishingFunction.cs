using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;
using UnityEngine.UI;

///<summary>
///
///</summary>

public class PlayerFishingFunction : MonoBehaviour
{
    public float fishingSpeed;

    public float fishingRange;

    private PlayerInput playerInput;//����input��

    public GameObject hook;


    public bool isPlacingFishingSpot;//�Ƿ�ʼ�������ڰڷ��׸͵�

    public Vector3 fishPt;//���ڻ�ȡHook��λ�ã��Ӷ��׸�

    public GameObject lastBone;//������������������

    private Rigidbody lastBoneRb;

    public GameObject fishingPole;//�洢���ڻ�ȡ��Ͷ���

    public Animation buoy;//��ȡ�ζ�����

    private Vector3 ropeInitialPos;//��¼���ԭ���ĵ㣬������͹�λ

    public Canvas touchCanvas;//�ڽ���������Բ����ʾ����

    private GameObject panel;//��ȡ�������panelUI

    public GameObject currentFish;//��¼��ǰҧ������

    public bool canPlayStartAnim;//���Բ��ſ�ʼ�׸Ͷ���

    public Boat boat;//��ȡ���ű�

    public HookMovement hookMovement;//��ȡ��Ư

    public FishingLineRenderer fishLine;//��ʾrender line

    public FishBasket fishBasket;//��ȡbasket�������ڵ�����֮������洢

    private bool isPut;//����Ƿ��Ѿ�����Ž�����basket��


    public bool isWaitingForFish;//���ǿ���ҧ����״̬

    public bool findFish;//����ҧ��

    public bool hookPlaced;//���¸�����

    public bool hookIsRePlaced;//�����Ѿ���������


    public bool fishCreated;







    private void Start()
    {
        lastBoneRb=lastBone.GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        ropeInitialPos = lastBone.transform.localPosition;
        panel = GameObject.Find("InGameCanvas").transform.Find("P_FindFish").gameObject;
    }

    private void Update()
    {
        if (findFish == true)
        {

            if (currentFish != null)
            {
                currentFish.GetComponent<Fish>().FishStickOnRod();//����������ճ�ڵ������
                
                buoy.Play();

                


                if (Input.touchCount > 0)//�������Ļ
                {
                    buoy.Stop();

                    if (isPut == false)//ֻ�е�isPut��false��������dict������ݣ����Ա������ڰ���Ļ�������ʱ������false
                    {
                        PutFishIntoBasket(currentFish.gameObject.name);//����ǰ�����ִ���ȥ����������������
                    }

                    if (hookIsRePlaced == false)
                    {
                        RepositionRod();
                    }


                    if (currentFish != null)
                    {
                        currentFish.transform.GetChild(1).gameObject.SetActive(false);//����Ӱ������
                        currentFish.transform.GetChild(0).gameObject.SetActive(true);//�Ѳ�ɫ����ʾ
                    }


                    if (fishCreated == false)
                    {
                        StartCoroutine("ShowCollectPanel");

                    }

                }

            }



        }
        else
        {
            if (hookPlaced == true)
            {
                if (Input.touchCount > 0)
                {
                    buoy.Stop();
                    if(hookIsRePlaced==false)
                    {
                        RepositionRod();
                    }
                    isPut = false;
                    currentFish = null;
                    isWaitingForFish = false;
                    hookPlaced = false;

                }
            }

        }

        if (canPlayStartAnim == true)
        {
            StartCoroutine(MoveRope(fishPt));
        }
    }

    public void MoveToNewPlace(Vector3 pos)
    {
        gameObject.transform.position = new Vector3(pos.x, transform.position.y, pos.z);

    }

    public void Fishing()
    {
        isPlacingFishingSpot = true;//�����ʼ����ʱ�������ڰڷ���Ϊtrue��ʹ��button event
        

        fishLine.gameObject.transform.parent.gameObject.SetActive(true);
        hook.transform.position = new Vector3(transform.position.x, hook.transform.position.y, transform.position.z);
        hook.SetActive(true);
        

    }



    public void FinishFishing()
    {
        isPlacingFishingSpot = false;//�����������ʱ�������ڰڷ���Ϊfalse
        hookPlaced = false;


        lastBone.gameObject.transform.localPosition = ropeInitialPos;
    
        playerInput.ActivateInput();//��������
        touchCanvas.gameObject.SetActive(true);
        hook.SetActive(false);

        fishLine.gameObject.transform.parent.gameObject.SetActive(false);

        isPut = false;


    }

  

    IEnumerator MoveRope(Vector3 pt)
    {
        yield return new WaitForSeconds(0.5f);
        lastBone.transform.position = Vector3.Lerp(lastBone.transform.position, new Vector3(pt.x, -2, pt.z), 0.5f);
        canPlayStartAnim = false;
    }



    public void RepositionRod()
    {
        lastBoneRb.transform.localPosition = Vector3.zero;
        fishingPole.GetComponent<Animation>().Play("FindFish");
        hookIsRePlaced = true;
        KeepFishing();
    }


    IEnumerator ShowCollectPanel()
    {

        yield return new WaitForSeconds(1);
        panel.SetActive(true);
        Destroy(currentFish);
        findFish = false;
        currentFish = null;

    }


    public void HideCollectPanel()//�ڹر��ҵ�������󣬵���
    {
        panel.SetActive(false);
        KeepFishing();

    }

    public void KeepFishing()
    {
        playerInput.ActivateInput();//��������
        fishLine.gameObject.transform.parent.gameObject.SetActive(true);
        hook.SetActive(true);
        hook.gameObject.transform.position = new Vector3(transform.position.x, hook.gameObject.transform.position.y, transform.position.z);
        touchCanvas.gameObject.SetActive(true);
        isWaitingForFish = false;
        
    }

    private void PutFishIntoBasket(string name)
    {

        switch (name)
        {
            case "����":
                fishBasket.IncreaseDictionaryValue("qingYu");
                isPut = true;

                break;
            case "��ǹ��":
                fishBasket.IncreaseDictionaryValue("jinQiangYu");
                isPut = true;

                break;
            case "����":
                fishBasket.IncreaseDictionaryValue("xueYu");
                isPut = true;

                break;
            case "������":
                fishBasket.IncreaseDictionaryValue("sanWenYu"); 
                isPut = true;

                break;
        }
    }

    
}
