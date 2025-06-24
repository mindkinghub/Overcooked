using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverUI3 : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private TMPro.TextMeshProUGUI numberText;
    [SerializeField] private TMPro.TextMeshProUGUI highScoreText;
    [SerializeField] private Button BackButton;
    private int score;
    private int highScore;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
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
        score = OrderManager.Instance.GetSucessfulDeliveryCount();
        score += PlayerPrefs.GetInt("score1",0) + PlayerPrefs.GetInt("score2", 0);
        numberText.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = highScore.ToString();
        uiParent.SetActive(true);
        if(score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    private void Hide()
    {
        uiParent.SetActive(false);
    }
}
