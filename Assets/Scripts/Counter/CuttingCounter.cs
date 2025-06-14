using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;
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

    public override void InteractOperate(Player player)
    {
        if (IsHaveKitchenObject())
        {
            KitchenObjectSO output = cuttingRecipeList.GetOutput(GetKitchenObject().GetKitchenObjectSO());

            if(output != null)
            {
                DestroyKitchenObject();
                CreateKitchenObject(output.prefab);
            }
        }
    }
}
