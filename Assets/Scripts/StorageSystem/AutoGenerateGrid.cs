using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class AutoGenerateGrid : MonoBehaviour
{
    public GameObject grid;
    public int generateNumber;

    private void Start()
    {
        for(int i = 0; i<generateNumber; i++)
        {
            Instantiate(grid,gameObject.transform);//�Դ�������Ϊ������instantiate
            
        }
        
    }
}
