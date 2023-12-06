using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class UI_Cabin : MonoBehaviour
{
    public GameObject boat;
    private void Start()
    {
        gameObject.transform.SetParent(boat.transform);
    }
}
