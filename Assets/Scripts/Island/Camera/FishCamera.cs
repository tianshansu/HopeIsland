using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class FishCamera : MonoBehaviour
{
    private void Update()
    {

        if(gameObject.GetComponent<Camera>().enabled)
        {

            Transform parentTransform = transform;


            foreach (Transform child in parentTransform)
            {
           
               child.gameObject.SetActive(true);
            }

        
         
        }
        else
        {
            Transform parentTransform = transform;


            foreach (Transform child in parentTransform)
            {

                child.gameObject.SetActive(false);
            }
        }
    }
}
