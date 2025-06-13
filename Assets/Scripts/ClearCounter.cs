using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private GameObject selectedCounter;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform topPoint;
    [SerializeField] private bool testing = false;
    [SerializeField] private ClearCounter transferTargetCounter;

    private KitchenObject kitchenObject;

    private void Update()
    {
        if(testing && Input.GetMouseButtonDown(0))
        {
            TransferKitchenObject(this, transferTargetCounter);
        }
    }

    public void Interact()
    {
        if (kitchenObject == null)
        {
            kitchenObject = GameObject.Instantiate(kitchenObjectSO.prefab, topPoint).GetComponent<KitchenObject>();
            kitchenObject.transform.localPosition = Vector3.zero;
        }
        else
        {
            Debug.LogWarning(gameObject.name+"����ʳ��");

        }

    }
    public void SelectCounter()
    {
        selectedCounter.SetActive(true);
    }
    public void CancelSelect()
    {
        selectedCounter.SetActive(false);
    }                                                          

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void TransferKitchenObject(ClearCounter soureCounter, ClearCounter targetCounter)
    {
        if (soureCounter.GetKitchenObject() == null)
        {
            Debug.LogWarning("Դ��̨��ʳ��");
            return;
        }
        if (targetCounter.GetKitchenObject() != null)
        {
            Debug.LogWarning("Ŀ���̨����ʳ��");
            return;
        }
        targetCounter.AddKitchenObject(soureCounter.GetKitchenObject());
        soureCounter.ClearKitchenObject();
    }
    public void AddKitchenObject(KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(topPoint);
        kitchenObject.transform.localPosition = Vector3.zero;
        this.kitchenObject = kitchenObject;
    }
    public void ClearKitchenObject()
    {
        this.kitchenObject = null;
    }
}
