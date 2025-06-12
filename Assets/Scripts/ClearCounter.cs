using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private GameObject selectedCounter;

    // Start is called before the first frame update
    void Start()
    {
        
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

}
