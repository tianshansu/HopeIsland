using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class Fish : MonoBehaviour
{

    public PlayerController player;
    private float sec;
    private bool runned;
    

    private void Start()
    {
       player=GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(runned==false)
        {
            if (other.gameObject.tag == "YuGan")
            {
                //Debug.Log("Yes");
                sec = Random.Range(3, 10);
                StartCoroutine("WaitFor");
                runned = true;
                player.currentYuQun = transform.gameObject;
            }
        }
        
    }


    IEnumerator WaitFor()
    {
        if(player.fishCreated== false)
        {
            yield return new WaitForSeconds(sec);
            player.findFish = true;
        }
        
       
    }

  
}
