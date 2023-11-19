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
    public Button finishBoat;
    public Transform playerPos;
    public BoxCollider col;
    public GameObject maTou;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            startBoat.gameObject.SetActive(true);

        }

        if(other.gameObject.tag=="MaTou")
        {
            finishBoat.gameObject.SetActive(true);
            Debug.Log("aaa");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            startBoat.gameObject.SetActive(false);
         
        }
        if (other.gameObject.tag == "MaTou")
        {
            finishBoat.gameObject.SetActive(false);
        }
    }

    public void StickWithPlayer()
    {
        startBoat.gameObject.SetActive(false);
        transform.parent=playerPos.transform;
        col.isTrigger = false;
    }

    public void PlayerGetBackToMaTou()
    {
        transform.parent = null;
        playerPos.transform.position=maTou.transform.position;
    }

    

}
