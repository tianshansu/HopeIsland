using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

///<summary>
///
///</summary>

public class CabinCanvasController : MonoBehaviour
{
    public Boat boat;
    public PlayerController player;
    public Button openCabin;

    private float originalTime;
    public float closeTime;


    public PlayerFishingFunction playerFishingFunction;



    private void Update()
    {
        if (playerFishingFunction.isPlacingFishingSpot == false)
        {
            if (UnityEngine.Input.touchCount > 0)
            {
                UnityEngine.Touch touch = Input.GetTouch(0);

                if (Camera.main != null)
                {

                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {

                        if (hit.collider != null && hit.collider.CompareTag("Boat"))
                        {
                             
                            openCabin.gameObject.SetActive(true);
                            originalTime= Time.time;//从打开船舱开始计时
                        }

                    }
                }

            }

        }

        if(originalTime+closeTime<Time.time)
        {
            openCabin.gameObject.SetActive(false);
        }

    }

    void LateUpdate()
    {
        if (Camera.main != null)
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                          Camera.main.transform.rotation * Vector3.up);
        }

    }




}
