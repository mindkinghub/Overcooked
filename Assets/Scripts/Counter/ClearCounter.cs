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
            if (player.GetKitchenObject().TryGetComponent<PlateKitchenObject>
                (out PlateKitchenObject plateKitchenObject))
            {// 手上有盘子
                if (IsHaveKitchenObject() == false)
                {// 桌上无食材
                    TransferKitchenObject(player, this);
                }
            }
            else
            {// 手上是普通食材
                if (IsHaveKitchenObject())
                {// 桌上有食材
                    if (GetKitchenObject().TryGetComponent<PlateKitchenObject>(out plateKitchenObject))
                    //桌上是盘子
                        if (plateKitchenObject.AddKitchenObjecctSO(player.GetKitchenObjectSO()))
                        // 添加食材成功
                            player.DestroyKitchenObject();
                }
            }
        }
        else
        {// 手上无食材
            if (IsHaveKitchenObject() == false) return;
            TransferKitchenObject(this, player);
        }
    }

}
