using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


    ///<summary>
    ///
    ///</summary>

public class Fish : MonoBehaviour
{

    private PlayerController player;
    private float sec;
    private FixedJoint joint;

    private Rigidbody rg;

  


    private void Start()
    {
        joint= GetComponent<FixedJoint>();
        rg= gameObject.GetComponent<Rigidbody>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (player.isCatchingFish == false)
        {
            if (other.gameObject.tag == "YuGan")
            {
                player.isCatchingFish = true;
                sec = Random.Range(3, 10);
                StartCoroutine("WaitFor");
                player.currentFish = transform.gameObject;
                
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="YuGan")
        {
            StopCoroutine("WaitFor");
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

    public void FishStickOnRod()
    {
        
        transform.position=player.lastBone.transform.position;
        transform.parent = player.lastBone.transform;
        ChangeUIName();

    }

    public void ChangeUIName()
    {
        FishCollectionPanel ui = GameObject.Find("InGameCanvas").transform.Find("P_FindFish").gameObject.GetComponent<FishCollectionPanel>();
        ui.ChangeFishName(gameObject.name);
    }

  
}
