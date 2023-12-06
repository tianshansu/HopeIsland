using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class UI_Cabin : MonoBehaviour
{
    //public GameObject boat;
    private void Start()
    {
        //gameObject.transform.SetParent(boat.transform);
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                          Camera.main.transform.rotation * Vector3.up);
    }
}
