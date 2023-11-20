using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>

public class MaTouShangChuan : MonoBehaviour
{
    public Button startBoat;
    public Button finishBoat;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            startBoat.gameObject.SetActive(true);

        }

        if (other.gameObject.tag == "Boat")
        {
            finishBoat.gameObject.SetActive(true);
            
  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            startBoat.gameObject.SetActive(false);

        }
        if (other.gameObject.tag == "Boat")
        {
            finishBoat.gameObject.SetActive(false);
        }
    }



}
