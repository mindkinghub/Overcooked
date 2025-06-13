using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private Transform KitchenObjectParent;
    [SerializeField] private UnityEngine.UI.Image iconUITemplate;

    private void Start()
    {
        iconUITemplate.gameObject.SetActive(false);
    }
    public void UpdateUI(RecipeSO recipeSO)
    {
        recipeNameText.text = recipeSO.recipeName;
        foreach (KitchenObjectSO kitchenObjectSO in recipeSO.kitchenObjectSOList)
        {
            UnityEngine.UI.Image iconUI = GameObject.Instantiate(iconUITemplate);
            iconUI.transform.SetParent(KitchenObjectParent);
            iconUI.sprite = kitchenObjectSO.sprite;
            iconUI.gameObject.SetActive(true);
        }
    }
}
