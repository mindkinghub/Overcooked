using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    public static event EventHandler OnDrop;
    public static event EventHandler OnPickup;

    [SerializeField] private Transform holdPoint;
    private KitchenObject kitchenObject;

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObject.GetKitchenObjectSO();
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        if (this.kitchenObject!=kitchenObject&&kitchenObject!=null&& this is BaseCounter)
        {
            OnDrop?.Invoke(this, EventArgs.Empty);  
        }else if (this.kitchenObject != kitchenObject && kitchenObject != null && this is Player)
        {
            OnPickup?.Invoke(this, EventArgs.Empty);
        }
        this.kitchenObject = kitchenObject;
        kitchenObject.transform.localPosition = Vector3.zero;
       
    }
    public Transform GetHoldPoint()
    {
        return holdPoint;
    }
    public bool IsHaveKitchenObject()
    {
        return kitchenObject != null;
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
        SetKitchenObject(kitchenObject);
    }
    public void ClearKitchenObject()
    {
        this.kitchenObject = null;
    }

    public void DestroyKitchenObject()
    {
        Destroy(kitchenObject.gameObject);
        ClearKitchenObject();
    }
    public void CreateKitchenObject(GameObject kitchenObjectPrefab)
    {
        KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectPrefab, GetHoldPoint()).GetComponent<KitchenObject>();
        SetKitchenObject(kitchenObject);
    }
}
