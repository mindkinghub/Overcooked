using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
<<<<<<< Updated upstream:Assets/Scripts/ClearCounter.cs
    [SerializeField] private GameObject selectedCounter;
=======
>>>>>>> Stashed changes:Assets/Scripts/Counter/ClearCounter.cs

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream:Assets/Scripts/ClearCounter.cs
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] private GameObject kitchenObjectPrefab;
    [SerializeField] private Transform topPoint;

    public void Interact()
    {
        GameObject go = GameObject.Instantiate(kitchenObjectPrefab, topPoint);
        go.transform.localPosition = Vector3.zero;
    }
    public void SelectCounter()
    {
        selectedCounter.SetActive(true);
    }
    public void CancelSelect()
    {
        selectedCounter.SetActive(false);
    }
=======
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
>>>>>>> Stashed changes:Assets/Scripts/Counter/ClearCounter.cs

}
