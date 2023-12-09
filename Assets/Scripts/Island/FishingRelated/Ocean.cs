using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class Ocean : MonoBehaviour
{
    public BoxCollider[] col;
    public Boat boat;

    private void Start()
    {
        col=GetComponents<BoxCollider>();
    }

    private void Update()
    {
        //if(boat.isonboat==true)
        //{
        //    for(int i=0;i<col.length;i++)
        //    {
                //col[i].istrigger = false;
        //    }
        //}
    }

}
