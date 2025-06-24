using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuUI : MonoBehaviour
{
    [SerializeField]private Button startButton;
    [SerializeField]private Button quitButton;
    [SerializeField] private Button SettingButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        SettingButton.onClick.AddListener(() =>
        {
            SettingsUI.Instance.Show();
        });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
