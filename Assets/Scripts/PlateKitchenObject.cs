using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validkitchenObjectSOList = new List<KitchenObjectSO>();
    [SerializeField] private PlateCompleteVisual plateCompleteVisual;

    private List<KitchenObjectSO> kitchenObjectSOList = new List<KitchenObjectSO>();

    public bool AddKitchenObjecctSO(KitchenObjectSO kitchenObjectSO)
    {
        if (kitchenObjectSOList.Contains(kitchenObjectSO) ||
            validkitchenObjectSOList.Contains(kitchenObjectSO) == false)
            return false;
        plateCompleteVisual.ShowKitchenObject(kitchenObjectSO);
        kitchenObjectSOList.Add(kitchenObjectSO);
        return true;
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
