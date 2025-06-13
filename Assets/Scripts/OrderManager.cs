using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private RecipeListSO recipeSOList;
    [SerializeField] private int orderMaxCount = 5;
    [SerializeField] private float orderRate = 2;

    private List<RecipeSO> orderRecipeSOList = new List<RecipeSO>();

    private float orderTimer = 0;
    private bool isStartOrder = false;
    private int orderCount = 0;

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
        int randomIndex = Random.Range(0, recipeSOList.recipeSOList.Count);
        RecipeSO newRecipe = recipeSOList.recipeSOList[randomIndex];

        if (!orderRecipeSOList.Contains(newRecipe))
        {
            orderRecipeSOList.Add(newRecipe);
            Debug.Log($"New recipe ordered: {newRecipe.name}");
        }
    }
}
