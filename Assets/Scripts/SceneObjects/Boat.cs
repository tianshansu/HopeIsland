using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    ///<summary>
    ///
    ///</summary>

public class Boat : MonoBehaviour
{
    public Button startBoat;
    public Transform playerPOs;

    private PlayerState playerState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            startBoat.gameObject.SetActive(true);
            Debug.Log("aaa");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            startBoat.gameObject.SetActive(false);
            Debug.Log("bbb");
        }
    }

    public void StickWithPlayer()
    {
        //playerState.isOnBoat= true;
        startBoat.gameObject.SetActive(false);
        transform.parent=playerPOs.transform;
    }

}
