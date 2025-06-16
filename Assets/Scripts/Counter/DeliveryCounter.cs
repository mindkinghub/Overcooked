using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player)
    {
       if(player .IsHaveKitchenObject()
            && player.GetKitchenObject()
            .TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plateKitchenObject))
        {
            player.DestroyKitchenObject();
        }
    }
}
