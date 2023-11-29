using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class SpawnSingleFish : MonoBehaviour
{
    public GameObject[] fishLib;
    //private int[] ints = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };//创建用于随机的数组）

    public GameObject fish;
    public int fishId;
    public FishCollectionPanel ui;

   

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
                ui.ChangeFishName("金鱼");
                break;
            case 1:
                fish = fishLib[1];
                ui.ChangeFishName("河豚");
                break;
            case 2:
                fish = fishLib[2];
                ui.ChangeFishName("带鱼");
                break;
           
        }
        return fish;
    }

    
}
