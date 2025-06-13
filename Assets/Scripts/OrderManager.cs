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

    private void Start()
    {
        isStartOrder = true;
    }

    private void Update()
    {
        if (isStartOrder)
        {
            OrderUpdate();
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

        orderCount++;
        int randomIndex = UnityEngine.Random.Range(0, recipeSOList.recipeSOList.Count);
        RecipeSO newRecipe = recipeSOList.recipeSOList[randomIndex];

        if (!orderRecipeSOList.Contains(newRecipe))
        {
            orderRecipeSOList.Add(newRecipe);
            Debug.Log($"New recipe ordered: {newRecipe.name}");
        }
        OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
    }

    public List<RecipeSO> GetOrderList()
    {
        return orderRecipeSOList;
    }
}
