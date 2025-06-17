using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI countDownText;
    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void Update()
    {
        if (GameManager.Instance.IsCountDownState())
        {
            countDownText.text = Mathf.CeilToInt(GameManager.Instance.GetCountDownToStartTimer()).ToString();
        }
    }
    private void GameManager_OnGameStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountDownState())
        {
            countDownText.gameObject.SetActive(true);
        }
        else
        {
            countDownText.gameObject.SetActive(false);
        }
    }
}
