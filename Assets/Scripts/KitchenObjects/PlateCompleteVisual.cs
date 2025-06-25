using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable] class KitchenObjectSO_Model
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject model;
    }

    [SerializeField] private List<KitchenObjectSO_Model> modelMap;

    public void ShowKitchenObject(KitchenObjectSO kitchenObjectSO)
    {
        foreach(KitchenObjectSO_Model item in modelMap)
        {
            if (item.kitchenObjectSO == kitchenObjectSO)
            {
                item.model.SetActive(true);
                return;
            }
        }
    }
}
