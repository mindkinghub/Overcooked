using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;
    private int cuttingCount = 0;
    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {// 手上有食材
            if (IsHaveKitchenObject()) return;
            cuttingCount = 0;
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
            if(cuttingRecipeList.TryGetCuttingRecipe(GetKitchenObject().GetKitchenObjectSO(), 
                out CuttingRecipe cuttingRecipe))
            {
                cuttingCount++;
                if(cuttingCount >= cuttingRecipe.cuttingCountMax)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(cuttingRecipe.output.prefab);
                }
            }
        }
    }
}
