using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class PlayerBackpack : MonoBehaviour
{
    public Backpack playerBackpack = new Backpack();//new一个Backpack类的，生成一个backpack（内含add和remove方法）

    public void PickUpItem(BackpackItem item)//调用此方法来添加物件
    {
        playerBackpack.AddItem(item);
    }

    public void UseItem(BackpackItem item)//调用此方法来移除物件
    {
        playerBackpack.RemoveItem(item);
    }
}
