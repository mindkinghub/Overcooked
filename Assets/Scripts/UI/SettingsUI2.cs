using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI2 : SettingsUI
{
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
            if (isOn)
            {
                PlayerPrefs.SetInt("mode", Convert.ToInt32(isOn));
            }
            else
            {
                PlayerPrefs.SetInt("mode", Convert.ToInt32(isOn));
            }
        });

        timeSetInput.text = PlayerPrefs.GetFloat("gamePlayTimeTotal", 200).ToString();
        // 限制只能输入数字
        timeSetInput.contentType = InputField.ContentType.DecimalNumber;
        // 监听输入变化
        timeSetInput.onValueChanged.AddListener(OnTimeSetValueChanged);
    }
    private void OnTimeSetValueChanged(string newValue)
    {
        if (float.TryParse(newValue, out float time))
        {
            PlayerPrefs.SetFloat("gamePlayTimeTotal", time);
        }
    }
}
