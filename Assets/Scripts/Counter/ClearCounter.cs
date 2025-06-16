using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClearCounter : BaseCounter
{

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
