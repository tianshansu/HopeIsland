using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;


///<summary>
///
///</summary>

public class SpawnSingleFish : MonoBehaviour
{
    public GameObject[] fishLib;

    [HideInInspector]
    public GameObject fish;
    [HideInInspector]
    public int fishId;
    [HideInInspector]
    public FishCollectionPanel ui;

    public GameObject water;
    public Vector3 size;
    public float fishGenerateNumber;

    [HideInInspector]
    public GameObject fishPrefab;
    private Vector3 pos;
   

    private void Start()
    {
        
        SpawnFishFunction();//生成鱼
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(water.transform.position, size);
    }

    public void SpawnFishFunction()
    {
        
        for (int i = 0; i < fishGenerateNumber; i++)
        {
            
            fishPrefab = GenerateFish();
            pos = water.transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), -1.5f, Random.Range(-size.z / 2, size.z / 2));
            GameObject fish= Instantiate(fishPrefab, pos, Quaternion.identity);
            fish.name = fishPrefab.name;
        }
    }
 


    public int ChooseFish()
    {
        int num = Random.Range(0, 9);
        if (num < 5) { return 0; }else
        if(4<num && num<8) { return 1; }else
        if (num > 7) { return 2; }
        return -1;
    }


    public GameObject GenerateFish()
    {
        fishId = ChooseFish();
        switch (fishId)
        {
            case 0:
                fish = fishLib[0];
                //fish.name = "金鱼";
                break;
            case 1:
                fish = fishLib[1];
                //ui.ChangeFishName("河豚");
                break;
            case 2:
                fish = fishLib[2];
                //ui.ChangeFishName("带鱼");
                break;
           
        }
        return fish;
    }

    
    
}
