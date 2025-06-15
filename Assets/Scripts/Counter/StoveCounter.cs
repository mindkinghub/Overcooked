using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecipeListSO fryingRecipeList;
    [SerializeField] private StoveCounterVisual stoveCounterVisual;
    public enum StoveState
    {
        Idle,
        Frying
    }
    private FryingRecipe fryingRecipe;
    private float fryingTimer = 0;
    private StoveState state = StoveState.Idle;

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {// 手上有食材
            if (IsHaveKitchenObject() || 
                fryingRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(),
                out fryingRecipe) == false) return;
            TransferKitchenObject(player, this);
            // 开始煎肉
            StartFrying(fryingRecipe);
        }
        else
        {// 手上无食材
            if (IsHaveKitchenObject() == false) return;
            StopFrying();
            TransferKitchenObject(this, player);
        }
    }

    private void StartFrying(FryingRecipe fryingRecipe)
    {
        stoveCounterVisual.ShowStoveEffect();
        fryingTimer = 0;
        this.fryingRecipe = fryingRecipe;
        state = StoveState.Frying;
    }
    private void StopFrying()
    {
        stoveCounterVisual.HideStoveEffect();
        fryingTimer = 0;
        this.fryingRecipe = null;
        state = StoveState.Idle;
    }

    private void Update()
    {
        switch (state)
        {
            case StoveState.Idle:
                break;
            case StoveState.Frying:
                fryingTimer += Time.deltaTime;
                if(fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    // 重新获取煎肉食谱
                    if (fryingRecipeList.TryGetFryingRecipe(GetKitchenObject().GetKitchenObjectSO(), out fryingRecipe))
                        StartFrying(fryingRecipe);
                    else StopFrying();
                }
                break;
            default:
                break;
        }
    }
}
