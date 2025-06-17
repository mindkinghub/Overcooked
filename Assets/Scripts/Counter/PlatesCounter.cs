using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    [SerializeField] private float spawnRate = 3;
    [SerializeField] private KitchenObjectSO plateSO;
    [SerializeField] private int plateCountMax = 5;

    private float timer = 0;
    private List<KitchenObject> platesList = new List<KitchenObject>();

    private void Update()
    {
        if(platesList.Count < plateCountMax) timer += Time.deltaTime;

        if (timer >= spawnRate && platesList.Count < plateCountMax)
        {
            CreatePlate();
            timer = 0;
        }
    }

    public void CreatePlate()
    {
        KitchenObject kitchenObject = GameObject.Instantiate(plateSO.prefab, GetHoldPoint()).GetComponent<KitchenObject>();

        kitchenObject.transform.localPosition = Vector3.zero + Vector3.up * 0.2f * platesList.Count;
        platesList.Add(kitchenObject);
    }

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject() == false)
        {// 手上无食材
            if(platesList.Count > 0)
            {
                player.AddKitchenObject(platesList[platesList.Count -1]);   // 玩家取走最上面的一个盘子
                platesList.RemoveAt(platesList.Count - 1);
            }
        }
        else
        {
            KitchenObject playerKitchenObject = player.GetKitchenObject();
            if (playerKitchenObject.TryGetComponent<PlateKitchenObject>
                (out PlateKitchenObject plateKitchenObject) == false)
            {// 手上是普通食材
                if(platesList[platesList.Count - 1].GetComponent<PlateKitchenObject>().
                    AddKitchenObjecctSO(playerKitchenObject.GetKitchenObjectSO()))
                {// 添加成功
                    player.DestroyKitchenObject();
                    player.AddKitchenObject(platesList[platesList.Count - 1]);   // 玩家取走最上面的一个盘子
                    platesList.RemoveAt(platesList.Count - 1);
                }
                
            }
        }
    }
}
