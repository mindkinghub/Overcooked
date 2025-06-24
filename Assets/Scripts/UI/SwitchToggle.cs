using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
    //把手RectTransform
    public RectTransform handleRect;
    //开关背景开启颜色
    [SerializeField] private Color backgroundActiveColor;
    //动画时间
    [SerializeField] private float duration = 0.5f;

    private Vector2 handlePos;
    private Toggle toggle;
    private Image backgroundImage;  //开关背景与把手的图片
    private Color backgroundColor;  //开关背景与把手的默认颜色

    private void Awake()
    {
        toggle = GetComponent<Toggle>();

        backgroundImage = handleRect.parent.GetComponent<Image>();
        backgroundColor = backgroundImage.color;

        handlePos = handleRect.anchoredPosition;
        toggle.onValueChanged.AddListener(OnSwitch);
        toggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("mode", 0));

        OnSwitch(toggle.isOn);
    }

    private void OnSwitch(bool on)
    {
        handleRect.DOAnchorPos(on ? -handlePos : handlePos, duration).SetEase(Ease.InOutBack).SetUpdate(true);
        backgroundImage.DOColor(on ? backgroundActiveColor : backgroundColor, duration).SetUpdate(true);
    }

    private void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}
