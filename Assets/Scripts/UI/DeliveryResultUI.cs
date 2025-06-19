using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryResultUI : MonoBehaviour
{
    private const string IS_SHOW = "IsShow";

    [SerializeField] private Animator deliverSucessUIAnimator;
    [SerializeField] private Animator deliverFailUIAnimator;

    private void Start()
    {
        OrderManager.Instance.OnRecipeCompleted += OrderManager_OnRecipeCompleted;
        OrderManager.Instance.OnRecipeFailed += OrderManager_OnRecipeFailed;
    }

    private void OrderManager_OnRecipeCompleted(object sender, System.EventArgs e)
    {
        deliverSucessUIAnimator.gameObject.SetActive(true);
        deliverSucessUIAnimator.SetTrigger(IS_SHOW);
    }
    private void OrderManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        deliverFailUIAnimator.gameObject.SetActive(true);
        deliverFailUIAnimator.SetTrigger(IS_SHOW);
    }
}
