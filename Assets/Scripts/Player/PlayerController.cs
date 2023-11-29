using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;

///<summary>
///
///</summary>

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;//��ȡcontroller���
    public float playerSpeed = 2.0f;//���������ʼֵ�������༭�����޸ģ�
    private PlayerInput playerInput;//����input��

    public float fishingSpeed;


    public GameObject hook;
    public bool isFishing;
    public Button startFishing;
    public Button finishFishing;
    public Vector3 fishPt;
    public GameObject lastBone;
    public Rigidbody lastBoneRb;
    public GameObject fishingPole;
    private Animation poleAnim;
    public Animation buoy;
    private Vector3 ropeInitialPos;
    public Canvas touchCanvas;

    

    public bool findFish;
    public bool fishCreated;
    public GameObject fishAttachPt;
    public SpawnFish yuQun;


    public GameObject panel;


    private SpawnSingleFish spawnSingleFish;

    private GameObject fish;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        lastBoneRb = lastBone.GetComponent<Rigidbody>();
        poleAnim= fishingPole.GetComponent<Animation>();
        ropeInitialPos = lastBone.transform.localPosition;
        yuQun=GameObject.Find("Ocean").GetComponent<SpawnFish>();
        spawnSingleFish=GameObject.Find("Ocean").GetComponent<SpawnSingleFish>();
       
    }

    void Update()
    {
        if (isFishing == false)
        {
            Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();//��ȡinput system��move��ʵʱֵ
            Vector3 move = new Vector3(input.x, 0, input.y);//����moveֵ

            move.y = 0f;//��������Ծ
            controller.Move(move * Time.deltaTime * playerSpeed);//�ý�ɫ�ƶ�

            if (move != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(move);//�����ƶ�����
            }
        }
        else
        {
            Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();//��ȡinput system��move��ʵʱֵ
            Vector3 move = new Vector3(input.x, 0, input.y);//����moveֵ

            move.y = 0f;//��������Ծ

            Vector3 playerCt = new Vector3(transform.position.x, hook.transform.position.y, transform.position.z);
            if (Vector3.Distance(hook.transform.position, playerCt) <= 7)
            {
                hook.transform.Translate(move * Time.deltaTime * fishingSpeed);//�ù����ƶ�
                if (playerInput.actions["Move"].WasReleasedThisFrame())//���ɿ�ʱ
                {
                    fishPt = hook.transform.position;
                    poleAnim.Play("FishingPole");
                    MoveRope(fishPt);
                    hook.SetActive(false);
                    playerInput.DeactivateInput();//��ֹ����
                    touchCanvas.gameObject.SetActive(false);
                    
                }
            }
            else
            {
                hook.transform.position -= (hook.transform.position - playerCt).normalized * 0.01f;
            }
        }

        if(findFish==true)
        {
            buoy.Play();

            if (Input.touchCount > 0)//�������Ļ
            {
                buoy.Stop();

                poleAnim.Play("FindFish");
                if (fishCreated == false)
                {
                    CreateFish();
                }
                findFish = false;
            }
                
               



        }
    }


    public void MoveToNewPlace(Vector3 pos)
    {
        gameObject.transform.position = new Vector3(pos.x,transform.position.y,pos.z);

    }

    public void Fishing()
    {
        isFishing = true;
        hook.transform.position=new Vector3(transform.position.x, hook.transform.position.y, transform.position.z);
        hook.SetActive(true);
        startFishing.gameObject.SetActive(false);
        finishFishing.gameObject.SetActive(true);
    }

    public void FinishFishing()
    {
        isFishing = false;
        lastBone.gameObject.transform.localPosition = ropeInitialPos;
        finishFishing.gameObject.SetActive(false);
        startFishing.gameObject.SetActive(true);
        playerInput.ActivateInput();//��������
        touchCanvas.gameObject.SetActive(true);
        hook.SetActive(false);
    }

    public void MoveRope(Vector3 pt)
    {
        lastBoneRb.AddForce(0, 200, 0);
        lastBone.gameObject.transform.position = pt;
        lastBoneRb.constraints = RigidbodyConstraints.FreezeAll;
        
    }


    public void CreateFish()
    {
        fish = Instantiate(spawnSingleFish.GenerateFish(), fishAttachPt.transform.position, Quaternion.identity);
        fish.transform.parent = fishAttachPt.transform;

        lastBoneRb.AddForce(0, 300, 0);
        StartCoroutine("ShowCollectPanel");
    }

    IEnumerator ShowCollectPanel()
    {
        yield return new WaitForSeconds(1);
        panel.SetActive(true);
        yuQun.DestroyFishGroup();
        Destroy(fish);
    }


    public void HideCollectPanel()
    {
        panel.SetActive(false);
        FinishFishing();

    }
}
