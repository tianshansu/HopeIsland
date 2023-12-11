using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
///
///</summary>

public class UI_Cabin : MonoBehaviour
{
    //public GameObject boat;
    //public Canvas UICabinMainStorage;
    //public Canvas inputStick;

    //public int closeTime;

    //private void Start()
    //{
        
    //}

    void LateUpdate()
    {
        if(Camera.main!= null)
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                          Camera.main.transform.rotation * Vector3.up);
        }
        
    }

    //public void OpenCabinBody()//´ò¿ª´¬²Õ
    //{
    //    //inputStick.gameObject.SetActive(false);
    //    //UICabinMainStorage.gameObject.SetActive(true);
    //    //gameObject.transform.parent.gameObject.SetActive(false);
    //    SceneManager.LoadScene("FishBaskets");

    //}

    
}
