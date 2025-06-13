using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    [SerializeField] private Transform holdPoint;
    private KitchenObject kitchenObject;

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        kitchenObject.transform.localPosition = Vector3.zero;
    }
    public Transform GetHoldPoint()
    {
        return holdPoint;
    }

    public void TransferKitchenObject(KitchenObjectHolder soureHolder, KitchenObjectHolder targetHolder)
    {
        if (soureHolder.GetKitchenObject() == null)
        {
            Debug.LogWarning("源无食材");
            return;
        }
        if (targetHolder.GetKitchenObject() != null)
        {
            Debug.LogWarning("目标柜台已有食材");
            return;
        }
        targetHolder.AddKitchenObject(soureHolder.GetKitchenObject());
        soureHolder.ClearKitchenObject();
    }
    public void AddKitchenObject(KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(holdPoint);
        kitchenObject.transform.localPosition = Vector3.zero;
        this.kitchenObject = kitchenObject;
    }
    public void ClearKitchenObject()
    {
        this.kitchenObject = null;
    }

}
