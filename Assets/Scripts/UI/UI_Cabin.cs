using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class UI_Cabin : MonoBehaviour
{
    //public GameObject boat;
    public Canvas UICabinMainStorage;
    public Canvas inputStick;

    private void Start()
    {
        //gameObject.transform.SetParent(boat.transform);
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                          Camera.main.transform.rotation * Vector3.up);
    }

    public void OpenCabinBody()//´ò¿ª´¬²Õ
    {
        inputStick.gameObject.SetActive(false);
        UICabinMainStorage.gameObject.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    
}
