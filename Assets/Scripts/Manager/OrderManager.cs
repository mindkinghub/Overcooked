using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance { get; private set; }
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    [SerializeField] private RecipeListSO recipeSOList;
    [SerializeField] private int orderMaxCount = 5;
    [SerializeField] private float orderRate = 2;

    private List<RecipeSO> orderRecipeSOList = new List<RecipeSO>();

    private float orderTimer = 0;
    private bool isStartOrder = false;
    private int orderCount = 0;
    private int sucessfulDeliveryCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isStartOrder)
        {
            OrderUpdate();
        }
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(object sender, EventArgs e)
    {

        if (GameManager.Instance.IsGamePlayingState())
        {
            StartOrder();
        }
    }

    private void OrderUpdate()
    {
        orderTimer += Time.deltaTime;

        if (orderTimer >= orderRate)
        {
            orderTimer = 0;
            OrderANewRecipe();
        }
    }

    private void OrderANewRecipe()
    {
        if (recipeSOList == null || recipeSOList.recipeSOList.Count == 0)
        {
            Debug.LogWarning("Recipe list is empty or not assigned.");
            return;
        }

        if (orderCount >= orderMaxCount) return;

        int randomIndex = UnityEngine.Random.Range(0, recipeSOList.recipeSOList.Count);
        RecipeSO newRecipe = recipeSOList.recipeSOList[randomIndex];


        orderRecipeSOList.Add(newRecipe);
        orderCount++;
        Debug.Log($"New recipe ordered: {newRecipe.name}");
        OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
    }

    public List<RecipeSO> GetOrderList()
    {
        return orderRecipeSOList;
    }

    public void DeliveryRecipe(PlateKitchenObject plateKitchenObject)
    {
        RecipeSO recipeToComplete = null;
        foreach (RecipeSO recipe in orderRecipeSOList)
        {
            if (IsCorrect(recipe, plateKitchenObject))
            {
                recipeToComplete = recipe;
                break;
            }
        }

        if (recipeToComplete == null)
        {
            Debug.LogWarning("No matching recipe found for the delivered plate.");
            return;
        }
        else
        {
            Debug.Log($"Recipe completed: {recipeToComplete.name}");
            orderRecipeSOList.Remove(recipeToComplete);
            OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
            sucessfulDeliveryCount++;
            orderCount--;
        }
    }

    private bool IsCorrect(RecipeSO recipe, PlateKitchenObject plateKitchenObject)
    {
        List<KitchenObjectSO> list1 = recipe.kitchenObjectSOList;
        List<KitchenObjectSO> list2 = plateKitchenObject.GetKitchenObjectSOList();

        if (list1.Count != list2.Count)
        {
            return false;
        }

        foreach (KitchenObjectSO kitchenObjectSO in list1)
        {
            if (!list2.Contains(kitchenObjectSO))
            {
                return false;
            }
        }
        return true;
    }

    public void StartOrder()
    {
        isStartOrder = true;
    }

    public int GetSucessfulDeliveryCount()
    {
        return sucessfulDeliveryCount;
    }
}
