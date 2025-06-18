using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public static SettingsUI Instance { get; private set; }

    [SerializeField] private GameObject uiParent;
    [SerializeField] private Button closeButton;
    [SerializeField] private Toggle modeToggle;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Hide();

        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });

        // 初始化 Toggle 状态（默认玩家2不启用）
        modeToggle.onValueChanged.AddListener((isOn) =>
        {
            if (isOn)   gameManager.SetDoubleMode();
            else    gameManager.SetSingleMode();
        });
    }
    public void Show()
    {
        uiParent.SetActive(true);
    }
    private void Hide()
    {
        uiParent.SetActive(false);
    }
}
