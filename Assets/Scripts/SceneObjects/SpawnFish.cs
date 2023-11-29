using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class SpawnFish : MonoBehaviour
{

    public GameObject FishPrefab;
    public GameObject currentFishGroup;
    public GameObject water;
    public Vector3 size;

    private void Start()
    {
        SpawnFishFunction();
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(water.transform.position, size);
    }

    public void SpawnFishFunction()
    {
        Vector3 pos = water.transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(FishPrefab, pos, Quaternion.identity);
        
    }

    public void DestroyFishGroup()
    {
        Destroy(currentFishGroup);
    }
}
