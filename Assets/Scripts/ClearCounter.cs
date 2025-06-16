using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

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
        if (GetKitchenObject() == null)
        {
            KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectSO.prefab, GetHoldPoint()).GetComponent<KitchenObject>();
            SetKitchenObject(kitchenObject);
        }
        else
        {
            TransferKitchenObject(this, player);
        }

    }

}
