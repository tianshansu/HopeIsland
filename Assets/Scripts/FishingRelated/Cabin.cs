using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class Cabin : MonoBehaviour
{
    public GameObject boat;

    private void Start()
    {
        gameObject.transform.parent=boat.transform;
    }
}
