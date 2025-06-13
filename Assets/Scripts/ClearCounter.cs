using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    // 以下代码用于测试食材转移
    //[SerializeField] private bool testing = false;
    //[SerializeField] private ClearCounter transferTargetCounter;
    //private void Update()
    //{
    //    if(testing && Input.GetMouseButtonDown(0))
    //    {
    //        TransferKitchenObject(this, transferTargetCounter);
    //    }
    //}

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {// 手上有食材
            if (IsHaveKitchenObject()) return;
            TransferKitchenObject(player, this);
        }
        else
        {// 手上无食材
            if (IsHaveKitchenObject() == false) return;
            TransferKitchenObject(this, player);
        }
    }

}
