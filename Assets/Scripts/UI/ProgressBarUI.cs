using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image progressImage;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void UpdateProgress(float progress)
    {
        Show();
        progressImage.fillAmount = progress;

        if (progress == 1)
        {
            Invoke(nameof(Hide), 0.5f); // Hide after 0.5 second when progress is complete
        }
    }
}
