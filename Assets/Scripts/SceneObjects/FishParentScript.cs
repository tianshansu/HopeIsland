using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class FishParentScript : MonoBehaviour
{
    
    public void DestroyCurrentFish(GameObject currentFish)
    {
        Destroy(currentFish);
    }
}
