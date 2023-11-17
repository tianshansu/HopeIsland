using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class Ocean : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player= GetComponent<GameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {

        }
    }
}
