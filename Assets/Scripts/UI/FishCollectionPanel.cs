using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    ///<summary>
    ///
    ///</summary>

public class FishCollectionPanel : MonoBehaviour
{
    public Text fishName;

 

    public void ChangeFishName(string newFishName)
    {
        
        fishName.text =  newFishName;
    }
}
