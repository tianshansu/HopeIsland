using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class Fish1 : MonoBehaviour
{

    private GameObject fish1Prefab;
    
    private PlayerController player;



    private void Start()
    {
        fish1Prefab= GetComponent<GameObject>();
        player=GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

 

  
}
