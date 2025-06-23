using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverUI3 : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private TMPro.TextMeshProUGUI gameOverText;
    [SerializeField] private Button NextButton;
    [SerializeField] private Button BackButton;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        NextButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene3);
        });
        BackButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameMenuScene);
        });
    }

    private void GameManager_OnGameStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOverState())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Show()
    {
        gameOverText.text = OrderManager.Instance.GetSucessfulDeliveryCount().ToString();
        uiParent.SetActive(true);
    }

    private void Hide()
    {
        uiParent.SetActive(false);
    }
}
