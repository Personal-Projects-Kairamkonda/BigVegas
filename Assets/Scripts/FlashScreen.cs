using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlashScreen : MonoBehaviour
{
    private SceneData sceneData;

    public static FlashScreen instance;

    public int score;

    void Awake()
    {
        instance = this;

        SceneManager.LoadScene(SceneData.PrototypeOldInputs.ToString(),LoadSceneMode.Additive);
        sceneData = SceneData.PrototypeOldInputs;
    }

    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space))
            SwitchScenes();*/

        if(score>2)
        {
            MapScene();
        }
    }

    void SwitchScenes()
    {
        if (sceneData == SceneData.MiniGameOne)
            MapScene();
        else
            GameOne();
    }

    public void MapScene()
    {
        SceneManager.UnloadSceneAsync(SceneData.MiniGameOne.ToString());
        SceneManager.LoadSceneAsync(SceneData.PrototypeOldInputs.ToString(), LoadSceneMode.Additive);
        sceneData = SceneData.PrototypeOldInputs;
        Debug.Log("Prototyped loaded");
    }

    public void GameOne()
    {
        SceneManager.UnloadSceneAsync(SceneData.PrototypeOldInputs.ToString());
        SceneManager.LoadSceneAsync(SceneData.MiniGameOne.ToString(), LoadSceneMode.Additive);
        sceneData = SceneData.MiniGameOne;
        Debug.Log("mini game loaded");
    }
}
