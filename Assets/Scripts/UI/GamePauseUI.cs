using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button menuButton;
    private void Start()
    {
        Hide();
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameMnager_OnGameUnpaused;
        resumeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.ToggleGame();
        });
        settingsButton.onClick.AddListener(() =>
        {
            SettingsUI.Instance.Show();
        });
        //menuButton.onClick.AddListener(() =>
        //{
        //    Loader.Load(LoaderOptimization.Scene.GameMenuScene);
        //});
    }

    private void GameMnager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        uiParent.SetActive(true);
    }
    private void Hide() { 
        uiParent.SetActive(false);
    }

}
