using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class PlayerBackpack : MonoBehaviour
{
    public Backpack playerBackpack = new Backpack();//newһ��Backpack��ģ�����һ��backpack���ں�add��remove������

    public void PickUpItem(BackpackItem item)//���ô˷�����������
    {
        playerBackpack.AddItem(item);
    }

    public void UseItem(BackpackItem item)//���ô˷������Ƴ����
    {
        playerBackpack.RemoveItem(item);
    }
}
