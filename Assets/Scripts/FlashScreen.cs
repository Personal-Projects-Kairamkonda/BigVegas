using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlashScreen : MonoBehaviour
{
    private SceneData sceneData;

    public static FlashScreen instance;

    private int score;

    void Awake()
    {
        if(instance==null)
            instance = this;

        ClearScenes();
    }

    void Start()
    {
        SceneManager.LoadSceneAsync(SceneData.MapScene.ToString(), LoadSceneMode.Additive);
        sceneData = SceneData.MapScene;
    }

    void SwitchScenes()
    {
        if (sceneData == SceneData.MiniGameOne)
            MapScene();
        else
            MiniGameOne();
    }

    public void MapScene()
    {
        SceneManager.UnloadSceneAsync(SceneData.MiniGameOne.ToString());
        SceneManager.LoadSceneAsync(SceneData.MapScene.ToString(), LoadSceneMode.Additive);
        sceneData = SceneData.MapScene;
        Debug.Log("Map Scene Loaded");
    }

    public void MiniGameOne()
    {
        SceneManager.UnloadSceneAsync(SceneData.MapScene.ToString());
        SceneManager.LoadSceneAsync(SceneData.MiniGameOne.ToString(), LoadSceneMode.Additive);
        sceneData = SceneData.MiniGameOne;
        Debug.Log("Mini Game One Loaded");
    }

    public void ClearScenes()
    {
       

    }
}
