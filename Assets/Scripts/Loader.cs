using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    public enum Scene
    {
        GameMenuScene,
        LoadingScene,
        GameScene
    }
    private static Scene tagetScene;
    public static void Load(Scene taget)
    {
        tagetScene = taget;
        SceneManager.LoadScene((int)Scene.LoadingScene);
    }
    public static void LoadBack()
    {
        SceneManager.LoadScene((int)tagetScene);
    }
}
