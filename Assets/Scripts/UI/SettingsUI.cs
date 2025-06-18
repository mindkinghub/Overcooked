using System;
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
    [SerializeField] private InputField timeSetInput;

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

        // 初始化 TimeSet 的值为总游戏时长
        timeSetInput.text = gameManager.GetGamePlayTimeTotal().ToString();
        // 限制只能输入数字
        timeSetInput.contentType = InputField.ContentType.DecimalNumber;
        // 监听输入变化
        timeSetInput.onValueChanged.AddListener(OnTimeSetValueChanged);
    }

    private void OnTimeSetValueChanged(string newValue)
    {
        if (float.TryParse(newValue, out float time))
            gameManager.UpdateGamePlayTimer(time);
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
